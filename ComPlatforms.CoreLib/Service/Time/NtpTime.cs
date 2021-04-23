using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ComPlatforms.CoreLib.Service.Time
{
    public static class NtpTime
    {
        private static readonly List<string> NtpServersList = new List<string>
        {
            "ntp3.stratum2.ru",
            "time.windows.com",
            "pool.ntp.org",
            "europe.pool.ntp.org",
            "asia.pool.ntp.org"
        };

        public delegate void Time();

        public static event Time TimeChanged;

        public static DateTime CurrentNtpTime;

        public static bool NtpTimeFetchError;

        public static void Initialize()
        {
            int trackedErrors = 0;

            foreach (string server in NtpServersList)
            {
                try
                {
                    CurrentNtpTime = GetNetworkTime(server);
                }
                catch (Exception)
                {
                    trackedErrors++;
                }
            }

            NtpTimeFetchError = NtpServersList.Count == trackedErrors;

            Thread ntpUpdateTimer = new Thread(NtpUpdateTimer_Tick) { IsBackground = true };

            ntpUpdateTimer.Start();
        }

        private static void NtpUpdateTimer_Tick()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                int trackedErrors = 0;

                foreach (string server in NtpServersList)
                {
                    try
                    {
                        CurrentNtpTime = GetNetworkTime(server);
                        TimeChanged?.Invoke();
                        break;
                    }
                    catch (Exception)
                    {
                        trackedErrors++;
                    }
                }

                NtpTimeFetchError = NtpServersList.Count == trackedErrors;

                Thread.Sleep(100);
            }
        }
        
        private static DateTime GetNetworkTime(string ntpServer)
        {
            var ntpData = new byte[48];

            ntpData[0] = 0x1B;

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            var ipEndpoint = new IPEndPoint(addresses[0], 123);

            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            
            socket.Connect(ipEndpoint);

            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            const byte serverReplyTime = 40;

            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            ulong fractalPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            intPart = SwapEndianness(intPart);
            fractalPart = SwapEndianness(fractalPart);
            
            var milliseconds = (intPart * 1000) + ((fractalPart * 1000)/ 0x100000000L);
            
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            if (networkDateTime.ToLocalTime() == DateTime.MinValue)
                throw new Exception("Invalid NTP server time!");

            return networkDateTime.ToLocalTime();
        }

        private static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                          ((x & 0x0000ff00) << 8) +
                          ((x & 0x00ff0000) >> 8) +
                          ((x & 0xff000000) >> 24));
        }
    }
}
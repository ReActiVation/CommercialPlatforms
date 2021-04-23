using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ComPlatforms.CoreLib.Service.Security
{
    public class CertificateStore
    {
        public readonly List<Certificate> CertificatesContainer;

        public CertificateStore()
        {
            CertificatesContainer = new List<Certificate>();

            foreach (KeyValuePair<string, X509Certificate2> certificate in GetSignature())
            {
                CertificatesContainer.Add(new Certificate(certificate.Key, certificate.Value));
            }
        }
        
        private IDictionary<string, X509Certificate2> GetSignature()
        {
            var certificateDictionary = new Dictionary<string, X509Certificate2>();

            var localCertificateStorage = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            
            localCertificateStorage.Open(OpenFlags.ReadOnly);
            var certificateCollection = localCertificateStorage.Certificates;

            foreach (var certificate in certificateCollection)
            {
                var parts = certificate.Subject.Split(',');
                var map = new Dictionary<string, string>();
                
                foreach (var pair in parts.Select(p => p.Split('=')).Where(p => p.Length == 2))
                    map[pair[0].Trim()] = pair[1];
                
                string displayName = GetValue(map, "SN") + " " 
                                                         + GetValue(map, "G") + " " 
                                                         + GetValue(map, "O") + " " 
                                                         + certificate.NotBefore + " - " 
                                                         + certificate.NotAfter;

                if (certificateDictionary.Count > 0 && certificateDictionary.ContainsKey(displayName))
                    continue;
                
                certificateDictionary.Add(displayName, certificate);
            }

            return certificateDictionary;
        }

        private string GetValue(Dictionary<string, string> map, string key)
        {
            return !map.ContainsKey(key) ? "" : map[key];
        }
    }
}
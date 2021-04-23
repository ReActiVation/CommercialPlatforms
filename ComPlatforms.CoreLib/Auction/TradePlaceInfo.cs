using System;
using System.Collections.Generic;

namespace ComPlatforms.CoreLib.Auction
{
    public interface ITradePlaceInfo
    {
        public bool IsInGame { get; set; }
        public AuctionStatus Status { get; set; }
        public TimeSpan TimeBeforeEnd { get; set; }
        public TimeSpan Duration { get; set; }
        public int Position { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal LastMadeBet { get; set; }
        public string DeclinePercentage { get; set; }
        public decimal MinStep { get; set; }
        public decimal MaxStep { get; set; }
        public List<Rival> Rivals { get; }
    }
    
    /// <summary>
    /// Class describes mutable data during the game
    /// </summary>
    public class TradePlaceInfo : ITradePlaceInfo
    {
        private bool _isInGame = false;
        /// <summary>
        /// Shows either the game started or not
        /// </summary>
        public bool IsInGame
        {
            get => _isInGame;
            set => _isInGame = value;
        }

        private AuctionStatus _status;
        /// <summary>
        /// Current trade status
        /// </summary>
        public AuctionStatus Status
        {
            get => _status;
            set => _status = value;
        }

        private TimeSpan _timeBeforeEnd = TimeSpan.FromMinutes(10);
        /// <summary>
        /// Time remaining before the auction end
        /// </summary>
        public TimeSpan TimeBeforeEnd
        {
            get => _timeBeforeEnd;
            set => _timeBeforeEnd = value;
        }
        
        private TimeSpan _duration = TimeSpan.Zero;
        /// <summary>
        /// Duration of the game
        /// </summary>
        public TimeSpan Duration
        {
            get => _duration;
            set => _duration = value;
        }

        private int _position = 0;
        /// <summary>
        /// Player position among participants
        /// </summary>
        public int Position
        {
            get => _position;
            set => _position = value;
        }

        private decimal _startingPrice = 0;
        /// <summary>
        /// Price from which game has started
        /// </summary>
        public decimal StartingPrice
        {
            get => _startingPrice;
            set => _startingPrice = value;
        }

        private decimal _currentPrice = 0;
        /// <summary>
        /// Current price knockdown
        /// </summary>
        public decimal CurrentPrice
        {
            get => _currentPrice;
            set => _currentPrice = value;
        }

        private decimal _lastMadeBet = 0;
        /// <summary>
        /// Player's last bet in game
        /// </summary>
        public decimal LastMadeBet
        {
            get => _lastMadeBet;
            set => _lastMadeBet = value;
        }

        private string _declinePercentage = "0%";
        /// <summary>
        /// Current price knockdown in percent representation
        /// </summary>
        public string DeclinePercentage
        {
            get => _declinePercentage;
            set => _declinePercentage = value;
        }

        private decimal _minStep = 0;
        /// <summary>
        /// Minimal auction step (lower bet price limit)
        /// </summary>
        public decimal MinStep
        {
            get => _minStep;
            set => _minStep = value;
        }

        private decimal _maxStep = 0;
        /// <summary>
        /// Maximum auction step (high bet price limit)
        /// </summary>
        public decimal MaxStep
        {
            get => _maxStep;
            set => _maxStep = value;
        }

        private List<Rival> _rivals;
        /// <summary>
        /// List of game rivals and information about them
        /// </summary>
        public List<Rival> Rivals
        {
            get => _rivals;
            private init => _rivals = value;
        }

        public TradePlaceInfo()
        {
            Rivals = new List<Rival>();
        }
    }
}
using System;

namespace ComPlatforms.CoreLib.Auction
{
    public interface IAuction
    {
        public string Index { get; set; }
        public string Title { get; set; }
        public string Announcer { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime RequestSubmissionStartDate { get; set; }
        public DateTime RequestSubmissionEndDate { get; set; }
        public DateTime StartDate { get; set; }
        public TradePlaceInfo GameInfo { get; }
    }
    
    /// <summary>
    /// Class represents trading auction object.
    ///
    /// Class contains basic information about the auction taking place
    /// at digital platforms as well as objects for storing information
    /// about game process and rivals bets during the game. 
    /// </summary>
    public class Auction : IAuction
    {
        private string _index;
        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Index
        {
            get => _index;
            set => _index = value;
        }

        private string _title;
        /// <summary>
        /// Short subject description 
        /// </summary>
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        private string _announcer;
        /// <summary>
        /// Auction organizer
        /// </summary>
        public string Announcer
        {
            get => _announcer;
            set => _announcer = value;
        }

        private DateTime _publishedDate;
        /// <summary>
        /// Timestamp of publication at a platform
        /// </summary>
        public DateTime PublishedDate
        {
            get => _publishedDate;
            set => _publishedDate = value;
        }
        
        private DateTime _requestSubmissionStartDate;
        /// <summary>
        /// Time of application submission start
        /// </summary>
        public DateTime RequestSubmissionStartDate
        {
            get => _requestSubmissionStartDate;
            set => _requestSubmissionStartDate = value;
        }

        private DateTime _requestSubmissionEndDate;
        /// <summary>
        /// Time before application submission end
        /// </summary>
        public DateTime RequestSubmissionEndDate
        {
            get => _requestSubmissionEndDate;
            set => _requestSubmissionEndDate = value;
        }

        private DateTime _startDate;
        /// <summary>
        /// Auction commencement time
        /// </summary>
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        private TradePlaceInfo _gameInfo;
        /// <summary>
        /// Structure containing information about
        /// during the game auction parameters
        /// </summary>
        public TradePlaceInfo GameInfo
        {
            get => _gameInfo;
            private init => _gameInfo = value;
        }

        public Auction()
        {
            GameInfo = new TradePlaceInfo();
        }
    }
}
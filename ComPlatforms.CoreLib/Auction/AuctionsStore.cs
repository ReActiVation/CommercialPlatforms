using System.Collections.Generic;

namespace ComPlatforms.CoreLib.Auction
{
    /// <summary>
    /// Class represents global auction container
    ///
    /// Container is filled during client's application initialization
    /// it provides access to auction entities during runtime
    /// </summary>
    public class AuctionsStore
    {
        /// <summary>
        /// Private field containing class instance
        /// </summary>
        private static AuctionsStore _instance;
        
        /// <summary>
        /// Publicly accessible property for gaining access to class instance
        /// </summary>
        public static AuctionsStore Instance => _instance ?? (new AuctionsStore());
        
        private List<ComPlatforms.CoreLib.Auction.Auction> _onParticipation;
        /// <summary>
        /// List of auction moved for participation
        /// </summary>
        public List<ComPlatforms.CoreLib.Auction.Auction> OnParticipation
        {
            get => _onParticipation;
            private init => _onParticipation = value;
        }

        private List<ComPlatforms.CoreLib.Auction.Auction> _found;
        /// <summary>
        /// List of auctions obtained during the search
        /// </summary>
        public List<ComPlatforms.CoreLib.Auction.Auction> Found
        {
            get => _found;
            private init => _found = value;
        }
        
        private AuctionsStore()
        {
            OnParticipation = new List<ComPlatforms.CoreLib.Auction.Auction>();
            Found = new List<ComPlatforms.CoreLib.Auction.Auction>();
        }
    }
}
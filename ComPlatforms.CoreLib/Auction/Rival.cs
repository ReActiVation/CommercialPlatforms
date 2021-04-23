using System.Collections.Generic;

namespace ComPlatforms.CoreLib.Auction
{
    public interface IRival
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<decimal> Bets { get; }
    }
    
    /// <summary>
    /// Class describes information about game opponents and their bet history
    /// </summary>
    public class Rival : IRival
    {
        private int _id;
        /// <summary>
        /// Rival identifier
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private string _title;
        /// <summary>
        /// Rival short description
        /// </summary>
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        private int _position;
        /// <summary>
        /// Rival position in game
        /// </summary>
        public int Position
        {
            get => _position;
            set => _position = value;
        }

        private List<decimal> _bets;
        /// <summary>
        /// List of rival's bets in historical order starting from first
        /// </summary>
        public List<decimal> Bets
        {
            get => _bets;
            private init => _bets = value;
        }

        public Rival()
        {
            Bets = new List<decimal>();
        }
    }
}
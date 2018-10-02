namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class Player
    {

        private Spot _currentlocation;

        public Player()
        {
            this.InJail = false;
            this.GetOutOfJailFreeCards = new List<Card>();
            //this.CurrentLocation = this.Properties[0];   // Set CurrentLocation to Go
            this.Money = 1500;  // Set Money to default value
        }
        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="playerId">The player's id</param>
        /// <param name="playerName">The player's name</param>
        /// <param name="color">The player's color - way to identify player on board</param>
        public Player(int playerId, string playerName, Color color)
        {
            this.PlayerId = playerId;
            this.PlayerName = playerName;
            this.Color = color;
            this.InJail = false;
            this.GetOutOfJailFreeCards = new List<Card>();
            //this.CurrentLocation = this.Properties[0];   // Set CurrentLocation to Go
            this.Money = 1500;  // Set Money to default value
        }

        /// <summary>
        /// Gets or sets the player's id
        /// </summary>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the player's name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the player's color - way to identify player on board
        /// Or create an enum for pawns
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the current location of player's pawn
        /// </summary>
        public Spot CurrentLocation
        {
            set
            {
                if(_currentlocation != value)
                {
                    _currentlocation = value;
                }
            }
            get
            {
                return _currentlocation;
            }
        }

        /// <summary>
        /// Player has landed on chance card.
        /// </summary>
        public bool OnChanceCard { get; set; }

        /// <summary>
        /// Player has landed on cmnty card.
        /// </summary>
        public bool OnCmntyCard { get; set; }

        /// <summary>
        /// Gets or sets how much money a player has
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the current player is in jail
        /// </summary>
        public bool InJail { get; set; }

        /// <summary>
        /// Gets or sets the list containing the "get out of jail free" cards a player may have 
        /// </summary>
        public List<Card> GetOutOfJailFreeCards { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is ai
        /// </summary>
        public bool IsAi { get; set; }
    }
}

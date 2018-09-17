namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
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
            this.Properties = new List<Spot>();
            this.GetOutOfJailFreeCards = new List<Card>();
            this.CurrentLocation = this.Properties[0];   // Set CurrentLocation to Go
            this.Money = 1500;  // Set Money to default value
        }

        /// <summary>
        /// Gets the player's id
        /// </summary>
        public int PlayerId { get; }

        /// <summary>
        /// Gets the player's name
        /// </summary>
        public string PlayerName { get; }

        /// <summary>
        /// Gets the player's color - way to identify player on board
        /// Or create an enum for pawns
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// Gets or sets the current location of player's pawn
        /// </summary>
        public Spot CurrentLocation { get; set; }

        /// <summary>
        /// Gets or sets how much money a player has
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the current player is in jail
        /// </summary>
        public bool InJail { get; set; }

        /// <summary>
        /// Gets or sets the list of properties a player owns
        /// </summary>
        public List<Spot> Properties { get; set; }

        /// <summary>
        /// Gets or sets the list containing the "get out of jail free" cards a player may have 
        /// </summary>
        public List<Card> GetOutOfJailFreeCards { get; set; }
    }
}

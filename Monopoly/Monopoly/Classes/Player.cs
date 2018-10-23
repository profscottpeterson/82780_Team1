//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The class for a player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class. 
        /// </summary>
        public Player()
        {
            this.InJail = false;
            this.GetOutOfJailFreeCards = new List<Card>();
            this.PlayerPictureBox = new PictureBox();

            // Set Money to default value
            this.Money = 1500;

            this.IsActive = true;
            this.TurnsInJail = 0;
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

            // Set Money to default value
            this.Money = 1500;

            this.IsActive = true;
            this.TurnsInJail = 0;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a Player has landed on chance card.
        /// </summary>
        public bool OnChanceCard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a Player has landed on community card.
        /// </summary>
        public bool OnComCard { get; set; }

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
        /// The number of turns a player has been in jail
        /// </summary>
        public int TurnsInJail { get; set; }

        /// <summary>
        /// Gets or sets the list containing the "get out of jail free" cards a player may have 
        /// </summary>
        public List<Card> GetOutOfJailFreeCards { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is ai
        /// </summary>
        public bool IsAi { get; set; }

        /// <summary>
        /// Gets or sets the players image
        /// </summary>
        public PictureBox PlayerPictureBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns a bool indicating whether a player needs more money
        /// </summary>
        /// <returns>A bool indicating whether a player needs more money</returns>
        public bool NeedMoreMoney()
        {
            // True if a player's money is less than zero
            return this.Money < 0;
        }
    }
}

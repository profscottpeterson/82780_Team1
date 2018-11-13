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
        /// Gets or sets The number of turns a player has been in jail
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

        /// <summary>
        /// Gets the list of properties a given player owns
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <returns>The list of properties the player owns</returns>
        public List<Spot> GetPlayersPropertyList(List<Spot> board)
        {
            // Declare and initialize a list of Spots
            List<Spot> playersPropertyList = new List<Spot>();

            // Loop through all the spots on the board
            foreach (Spot spot in board)
            {
                // if the spot's owner is the given player
                if (spot.Owner == this)
                {
                    // add that spot to the list
                    playersPropertyList.Add(spot);
                }
            }

            // return the list
            return playersPropertyList;
        }

        /// <summary>
        /// Finds a player's total net worth
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <returns>The player's net worth</returns>
        public int TotalNetWorth(List<Spot> board)
        {
            // Get the amount the player has in cash
            int total = this.Money;

            // Get the player's list of properties
            List<Spot> propertyList = this.GetPlayersPropertyList(board);

            // Loop through the player's list of properties
            foreach (var p in propertyList)
            {
                // Add the property's mortgage value to total
                if (!p.IsMortgaged)
                {
                    total += p.Mortgage;
                }

                // Check for hotel or houses
                if (p.HasHotel)
                {
                    // Add the cost of the hotel if it has a hotel
                    total += p.HotelCost;
                }
                else if (p.NumberOfHouses > 0)
                {
                    // Add the cost of a house time the number of houses the property has
                    total += p.HouseCost * p.NumberOfHouses;
                }
            }

            // return the total value
            return total;
        }

        /// <summary>
        /// Sends player to Jail
        /// </summary>
        /// <param name="jail">Spot passed in (should be jail)</param>
        public void SendToJail(Spot jail)
        {
            // Set current player's location to jail
            this.CurrentLocation = jail;

            // Set player's in jail boolean to true
            this.InJail = true;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="BuyProp.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The class for the form for buying properties
    /// </summary>
    public partial class BuyProp : Form
    {
        /// <summary>
        /// The current player
        /// </summary>
        private Player currentPlayer;

        /// <summary>
        /// A temporary spot, holds selected spot
        /// </summary>
        private Spot s;

        /// <summary>
        /// A temporary game variable
        /// </summary>
        private Game game;

        /*
        public BuyProp()
        {
            InitializeComponent();
        }
        */

        /// <summary>
        /// Initializes a new instance of the <see cref="BuyProp"/> class.
        /// </summary>
        /// <param name="spot">The spot that was selected</param>
        /// <param name="p">The current player</param>
        /// <param name="g">The game</param>
        public BuyProp(Spot spot, Player p, Game g)
        {
            // Copy the info from the MonPopUp to display card info
            this.InitializeComponent();
            this.colorPicBox.BackColor = spot.Color;
            this.spotNameLabel.Text = spot.SpotName;

            // this.BackColor = spot.Color;
            this.priceLabel.Text = "Price: " + spot.Price.ToString("C");
            this.rentLabel.Text = "Rent: " + spot.Rent.ToString("C");
            this.rent1Label.Text = "Rent with 1 House: " + spot.Rent1House.ToString("C");
            this.rent2Label.Text = "Rent with 2 Houses: " + spot.Rent2Houses.ToString("C");
            this.rent3Label.Text = "Rent with 3 Houses: " + spot.Rent3Houses.ToString("C");
            this.rent4Label.Text = "Rent with 4 Houses: " + spot.Rent4Houses.ToString("C");
            this.rentHotelLabel.Text = "Rent with a Hotel: " + spot.HotelCost.ToString("C");
            this.mortgageLabel.Text = "Mortgage: " + spot.Mortgage.ToString("C");

            // Output the players balance
            this.lblYourMoney.Text = p.Money.ToString();

            // Check to see if the player is even able to purchase the property
            if (p.Money < spot.Price)
            {
                // If they aren't able to purchase it, then close the form
                this.Close();
            }

            // Set a temporary variable in this form to store the spot s and the currentPlayer p
            this.s = spot;
            this.currentPlayer = p;

            // Use the same version of game.
            this.game = g;
        }

        /// <summary>
        /// The click event for if a player does not want to buy a property.
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnNo_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        /// <summary>
        /// The click event for if a player does want to buy a property
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnYes_Click(object sender, EventArgs e)
        {
            // Update the player and spot info in the game class.
            this.game.Board[this.s.SpotId].Owner = this.currentPlayer;
            this.game.Board[this.s.SpotId].IsAvailable = false;
            this.game.Players[this.currentPlayer.PlayerId].Money = this.currentPlayer.Money - this.s.Price;

            // Close the form *facepalm*
            this.Close();
        }
    }
}

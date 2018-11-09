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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Copy the info from the MonPopUp to display card info
            this.InitializeComponent();
            this.spotNameLabel.Text = spot.SpotName;
            this.spotNameLabel.BackColor = spot.Color;

            // Adjust text color so it is visible against the background
            if (spot.Color == Color.Purple || spot.Color == Color.Green || spot.Color == Color.DarkBlue || spot.Color == Color.Black || spot.Color == Color.Red || spot.Color == Color.MediumVioletRed)
            {
                this.spotNameLabel.ForeColor = Color.White;
            }
            else
            {
                this.spotNameLabel.ForeColor = Color.Black;
            }
            
            this.priceLabel.Text = "Price: " + spot.Price.ToString("C0");
            this.mortgageLabel.Text = "Mortgage: " + spot.Mortgage.ToString("C0");

            this.rentLabel.Text = string.Empty;

            if (spot.Type == SpotType.Property)
            {
                this.rentLabel.Text += "Rent: " + spot.Rent.ToString("C0") + '\n';
                this.rentLabel.Text += "Rent with 1 House: " + spot.Rent1House.ToString("C0") + '\n';
                this.rentLabel.Text += "Rent with 2 Houses: " + spot.Rent2Houses.ToString("C0") + '\n';
                this.rentLabel.Text += "Rent with 3 Houses: " + spot.Rent3Houses.ToString("C0") + '\n';
                this.rentLabel.Text += "Rent with 4 Houses: " + spot.Rent4Houses.ToString("C0") + '\n';
                this.rentLabel.Text += "Rent with a Hotel: " + spot.RentHotel.ToString("C0");
            }
            else if (spot.Type == SpotType.Railroad)
            {
                this.rentLabel.Text += "Rent: " + spot.Rent.ToString("C0") + '\n';
                this.rentLabel.Text += "If 2 are owned: " + (spot.Rent * 2).ToString("C0") + '\n';
                this.rentLabel.Text += "If 3 are owned: " + (spot.Rent * 4).ToString("C0") + '\n';
                this.rentLabel.Text += "If 4 are owned: " + (spot.Rent * 8).ToString("C0");
            }
            else if (spot.Type == SpotType.Utility)
            {
                this.rentLabel.Text += "If one Utility is owned, rent is 4 times amount shown on dice." + '\n';
                this.rentLabel.Text += "If both Utilities are owned, rent is 10 times amount shown on dice.";
            }

            // Output the players balance
            this.lblYourMoney.Text = p.Money.ToString("c0");

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

            if (p.IsAi == true)
            {
                if (p.Money >= spot.Price)
                {
                    this.BtnYes_Click(p, EventArgs.Empty);
                }
                else
                {
                    this.BtnNo_Click(p, EventArgs.Empty);
                }
            }
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

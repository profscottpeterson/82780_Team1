using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class BuyProp : Form
    {
        private Player currentPlayer;
        private Spot s;
        private Game game;

        public BuyProp()
        {
            InitializeComponent();
        }

        public BuyProp(Spot spot, Player p, Game g)
        {
            // Copy the info from the MonPopUp to display card info
            InitializeComponent();
            ColorPicBox.BackColor = spot.Color;
            SpotNameLabel.Text = spot.SpotName;
            //this.BackColor = spot.Color;
            PriceLabel.Text = "Price: " + spot.Price.ToString("C");
            RentLabel.Text = "Rent: " + spot.Rent.ToString("C");
            Rent1Label.Text = "Rent with 1 House: " + spot.Rent1House.ToString("C");
            Rent2Label.Text = "Rent with 2 Houses: " + spot.Rent2Houses.ToString("C");
            Rent3Label.Text = "Rent with 3 Houses: " + spot.Rent3Houses.ToString("C");
            Rent4Label.Text = "Rent with 4 Houses: " + spot.Rent4Houses.ToString("C");
            RentHotelLabel.Text = "Rent with a Hotel: " + spot.HotelCost.ToString("C");
            MortgageLabel.Text = "Mortgage: " + spot.Mortgage.ToString("C");

            // Output the players balance
            lblYourMoney.Text = p.Money.ToString();

            // Check to see if the player is even able to purchase the property
            if (p.Money < spot.Price)
            {
                // If they aren't able to purchase it, then close the form
                this.Close();
            }

            // Set a temporary variable in this form to store the spot s and the currentPlayer p
            s = spot;
            currentPlayer = p;

            // Use the same version of game.
            game = g;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            // Update the player and spot info in the game class.
            game.Board[s.SpotId].Owner = currentPlayer;
            game.Board[s.SpotId].IsAvailable = false;
            game.Players[currentPlayer.PlayerId].Money = currentPlayer.Money - s.Price;

            // Close the form *facepalm*
            this.Close();
        }
    }
}

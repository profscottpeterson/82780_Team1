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
    public partial class MonPopUp : Form
    {
        private Spot spot;
        public MonPopUp()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
        }

        public MonPopUp(Spot s)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.spot = s;
            InitializeComponent();

        }

        private void MonPopUp_Load(object sender, EventArgs e)
        {
            this.Text = this.spot.SpotName;
            this.SpotNameLabel.Text = this.spot.SpotName;
            this.SpotNameLabel.BackColor = this.spot.Color;

            // Adjust text color so it is visible against the background
            if (this.spot.Color == Color.Brown || this.spot.Color == Color.Green || this.spot.Color == Color.DarkBlue)
            {
                this.SpotNameLabel.ForeColor = Color.White;
            }
            else
            {
                this.SpotNameLabel.ForeColor = Color.Black;
            }
            
            this.PriceLabel.Text = "Price: " + this.spot.Price.ToString("C0");
            this.RentLabel.Text = "Rent: " + this.spot.Rent.ToString("C0");
            this.Rent1Label.Text = "Rent with 1 House: ";
            this.Rent1AmountLabel.Text = this.spot.Rent1House.ToString("C0");
            this.Rent2Label.Text = "Rent with 2 Houses: ";
            this.Rent2AmountLabel.Text = this.spot.Rent2Houses.ToString("C0");
            this.Rent3Label.Text = "Rent with 3 Houses: ";
            this.Rent3AmoutLabel.Text = this.spot.Rent3Houses.ToString("C0");
            this.Rent4Label.Text = "Rent with 4 Houses: ";
            this.Rent4AmountLabel.Text = this.spot.Rent4Houses.ToString("C0");
            this.RentHotelLabel.Text = "Rent with a Hotel: " + this.spot.RentHotel.ToString("C0");
            this.MortgageLabel.Text = "Mortgage: " + this.spot.Mortgage.ToString("C0");

            // If property is owned, display owner name
            if (!this.spot.IsAvailable && this.spot.Owner != null)
            {
                this.OwnerLabel.Text = "Property's owner: " + spot.Owner.PlayerName;
            }
            else
            {
                this.OwnerLabel.Text = "This property is not owned.";
            }

            // Check whether property is mortgaged and display results
            if (this.spot.IsMortgaged)
            {
                this.IsMortgagedLabel.Text = "Property is currently mortgaged.";
            }
            else
            {
                this.IsMortgagedLabel.Text = "Property is not currently mortgaged.";
            }

            // Display what buildings the property has
            if (this.spot.HasHotel)
            {
                this.BuildingsLabel.Text = "This property has a hotel.";
            }
            else if (this.spot.NumberOfHouses > 0)
            {
                this.BuildingsLabel.Text = "Number of Houses: " + this.spot.NumberOfHouses;
            }
            else
            {
                this.BuildingsLabel.Text = "No houses/hotels on this property.";
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
            InitializeComponent();
        }

        public MonPopUp(Spot s)
        {
            spot = s;
            InitializeComponent();

        }

        private void MonPopUp_Load(object sender, EventArgs e)
        {
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

        }
    }
}

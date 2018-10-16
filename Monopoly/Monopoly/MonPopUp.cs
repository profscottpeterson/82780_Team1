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
            this.Text = spot.SpotName;
            ColorPicBox.BackColor = spot.Color;
            SpotNameLabel.Text = spot.SpotName;
            //this.BackColor = spot.Color;
            PriceLabel.Text = "Price: " + spot.Price.ToString("C0");
            RentLabel.Text = "Rent: " + spot.Rent.ToString("C0");
            Rent1Label.Text = "Rent with 1 House: " + spot.Rent1House.ToString("C0");
            Rent2Label.Text = "Rent with 2 Houses: " + spot.Rent2Houses.ToString("C0");
            Rent3Label.Text = "Rent with 3 Houses: " + spot.Rent3Houses.ToString("C0");
            Rent4Label.Text = "Rent with 4 Houses: " + spot.Rent4Houses.ToString("C0");
            RentHotelLabel.Text = "Rent with a Hotel: " + spot.HotelCost.ToString("C0");
            MortgageLabel.Text = "Mortgage: " + spot.Mortgage.ToString("C0");

        }
    }
}

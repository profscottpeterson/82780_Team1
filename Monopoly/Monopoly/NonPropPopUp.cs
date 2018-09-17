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
    public partial class NonPropPopUp : Form
    {
        private Spot spot; 
        public NonPropPopUp()
        {
            InitializeComponent();
        }

        public NonPropPopUp(Spot spot)
        {
            this.spot = spot;
            InitializeComponent();
        }

        private void NonPropPopUp_Load(object sender, EventArgs e)
        {
            NameLabel.Text = spot.SpotName;
            PriceLabel.Text = spot.Price.ToString("C");
            AmtOwedLabel.Text = spot.Rent.ToString("C");
        }
    }
}

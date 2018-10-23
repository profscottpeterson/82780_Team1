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
    public partial class MiscCardForm : Form
    {
        // private Card _card;

        public MiscCardForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        public MiscCardForm(string title, Card card)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
            this.Text = title;
            cardTextLabel.Text = card.Description;
        }

        public PictureBox picture { get; set; }

        private void MiscCardForm_Load(object sender, EventArgs e)
        {
            picture = new PictureBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

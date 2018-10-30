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

        private Player p;

        public MiscCardForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        public MiscCardForm(string title, Card card, Player p)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.p = p;

            InitializeComponent();
            this.Text = title;
            cardTextLabel.Text = card.Description;
            cardPictureBox.Image = card.CardImage;
            if (card.Type == CardType.Chance)
            {
                this.BackColor = Color.Orange;
            }
            else
            {
                this.BackColor = Color.Yellow;
            }


        }

        public PictureBox picture { get; set; }

        private void MiscCardForm_Load(object sender, EventArgs e)
        {
            picture = new PictureBox();
            if (p.IsAi == true)
            {
                button1_Click(p, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

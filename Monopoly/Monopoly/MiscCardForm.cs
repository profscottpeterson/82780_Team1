using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
                this.CardTypeLabel.Text = "Chance";
            }
            else
            {
                this.BackColor = Color.Yellow;
                this.CardTypeLabel.Text = "Community Chest";
            }

            if (card.Description.Contains("You have been elected Chairman of the Board"))
            {
                this.DescriptionLabel.Text = "Pay each player " + card.Amount.ToString("c0") + ".";
            }
            else if (card.Description.Contains("It is your birthday") || card.Description.Contains("Grand Opera Night"))
            {
                this.DescriptionLabel.Text = "Collect " + card.Amount.ToString("c0") + " from each player.";
            }
            else if (card.Description.Contains("Your building and loan matures") 
                     || card.Description.Contains("You have won a crossword competition") 
                     || card.Description.Contains("Holiday Fund matures") 
                     || card.Description.Contains("Life insurance matures") 
                     || card.Description.Contains("You have won second prize in a beauty contest"))
            {
                this.DescriptionLabel.Text = "Collect " + card.Amount.ToString("c0") + ".";
            }
            else if (card.Description.Contains("Doctor's fees") || card.Description.Contains("Hospital Fees") || card.Description.Contains("School Fees"))
            {
                this.DescriptionLabel.Text = "Pay " + card.Amount.ToString("c0") + ".";
            }
            else if (card.Description.Contains("general repairs"))
            {
                this.DescriptionLabel.Text = "Pay $25 per house and $100 per hotel.";
            }
            else if (card.Description.Contains("street repairs"))
            {
                this.DescriptionLabel.Text = "Pay $40 per house and $115 per hotel.";
            }
            else if (card.Description.Contains("Advance"))
            {
                if (card.Description.Contains("Go"))
                {
                    this.DescriptionLabel.Text = "Collect $200.";
                }
                else
                {
                    this.DescriptionLabel.Text = "If you pass Go, collect $200.";
                }
            }

        }

        public PictureBox picture { get; set; }

        private void MiscCardForm_Load(object sender, EventArgs e)
        {
            picture = new PictureBox();
            if (p.IsAi == true)
            {
                BtnClose_Click(p, EventArgs.Empty);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

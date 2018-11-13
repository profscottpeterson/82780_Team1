//-----------------------------------------------------------------------
// <copyright file="MiscCardForm.cs" company="null">
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
    using System.Timers;
    using System.Windows.Forms;

    /// <summary>
    /// The MisCardForm extends the form class
    /// </summary>
    public partial class MiscCardForm : Form
    {
        // private Card _card;

        /// <summary>
        /// The current player that is receiving the action of the mis card
        /// </summary>
        private Player p;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiscCardForm"/> class.
        /// </summary>
        public MiscCardForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiscCardForm"/> class.
        /// </summary>
        /// <param name="title">The title of the card</param>
        /// <param name="card">The name of the card</param>
        /// <param name="p">The player who is receiving the effect of the card</param>
        public MiscCardForm(string title, Card card, Player p)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.p = p;

            this.InitializeComponent();
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

        /// <summary>
        /// Gets or sets the properties of picture
        /// </summary>
        public PictureBox Picture { get; set; }

        /// <summary>
        /// The form load event for the MisCardForm
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The eventArguments e</param>
        private void MiscCardForm_Load(object sender, EventArgs e)
        {
            this.Picture = new PictureBox();

            if (this.p.IsAi == true)
            {
                this.BtnClose_Click(this.p, EventArgs.Empty);
            }
        }

        /// <summary>
        /// button Close click event
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The eventArgs for the click event</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

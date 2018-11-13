//-----------------------------------------------------------------------
// <copyright file="Trade.cs" company="null">
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
    /// The Trade class extends the Form class
    /// </summary>
    public partial class Trade : Form
    {
        /// <summary>
        /// The currentPlayer
        /// </summary>
        private Player currentPlayer = new Player();

        /// <summary>
        /// The chosenPlayer
        /// </summary>
        private Player chosenPlayer = new Player();

        /// <summary>
        /// The current game instance
        /// </summary>
        private Game game;

        /// <summary>
        /// The list of players
        /// </summary>
        private List<Player> players;

        /// <summary>
        /// The last valid string
        /// </summary>
        private string lastConfirmed = "0";

        /// <summary>
        /// all of the player initiating the list's not offered spots
        /// </summary>
        private List<Spot> requester = new List<Spot>();

        /// <summary>
        /// The spots the player that initialized the trade is offering
        /// </summary>
        private List<Spot> requesterOffer = new List<Spot>();

        /// <summary>
        /// The spots that the target has that the player initiating the trade hasn't wanted (yet)
        /// </summary>
        private List<Spot> target = new List<Spot>();

        /// <summary>
        /// The spots that are owned by the target that the player initiating the trade wants
        /// </summary>
        private List<Spot> targetOffer = new List<Spot>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="p">The player initiating the trade</param>
        /// <param name="g">The current game instance</param>
        public Trade(Player p, Game g)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
            this.currentPlayer = p;
            this.game = g;
            this.players = g.Players;
        }

        /// <summary>
        /// Fills a given list view with the given list of spots (name and price)
        /// </summary>
        /// <param name="listView">The list view to fill</param>
        /// <param name="spots">The list of spots used to fill list view</param>
        public void FillListView(ListView listView, List<Spot> spots)
        {
            listView.Clear();

            // Add Column Headers only if they don't already exist
            if (listView.Columns.Count == 0)
            {
                listView.Columns.Add("Property Name", 125);
                listView.Columns.Add("Price", 50);
            }

            // Array to hold to contents of each row of the list view
            string[] rowContents = new string[2];

            // Loop through each spot in list of spots given
            foreach (Spot s in spots)
            {
                // Put the spot name in the first column
                rowContents[0] = s.SpotName;

                // Put the price in the second column
                rowContents[1] = s.Price.ToString("c0");

                // Create a list view item that is a row made up of the spot name and price
                var row = new ListViewItem(rowContents);

                // Add created row to list view
                listView.Items.Add(row);
            }

            // Loop through each item in the list view
            foreach (ListViewItem item in listView.Items)
            {
                // Get the spot that corresponds with the spot name
                Spot spot = this.game.GetSpotByName(item.Text);

                // If a spot was found with that name
                if (spot != null)
                {
                    // Set the text color to the property's color
                    item.ForeColor = spot.Color;

                    // Change the color for the lighter colors to darker colors
                    if (spot.Color == Color.LightBlue)
                    {
                        item.ForeColor = Color.DodgerBlue;
                    }
                    else if (spot.Color == Color.Yellow)
                    {
                        item.ForeColor = Color.FromArgb(255, 220, 220, 0);
                    }
                }
            }
        }

        /// <summary>
        /// The load event for the Trade form
        /// </summary>
        /// <param name="sender">The sender for the load event</param>
        /// <param name="e">The eventArgs for the load event</param>
        private void Trade_Load(object sender, EventArgs e)
        {
            // Instantiate and fill a list of the requesters spots
            this.requester = new List<Spot>();

            this.requester = this.currentPlayer.GetPlayersPropertyList(this.game.Board);

            this.FillListView(this.lstRequesterProperties, this.requester);

            // set the requesters money equal to their current money in game
            this.lblRequesterTotal.Text = "/ " + this.currentPlayer.Money.ToString();

            // Add the choice to choose which player the requester wants to trade with
            foreach (Player p in this.players)
            {
                if (this.currentPlayer.PlayerName != p.PlayerName)
                {
                    // If the player isn't the requester, add them to the combo box
                    if (p.IsActive == true)
                    {
                        this.cmboRequestee.Items.Add(p.PlayerName);
                    }
                }
            }

            // Change current players name
            this.lblRequesterName.Text = this.currentPlayer.PlayerName;

            // Set initial jail card settings
            this.lblRequesterBeforeJailCard.Text = this.currentPlayer.GetOutOfJailFreeCards.Count.ToString();
            this.lblRequesterAfterJailCard.Text = this.currentPlayer.GetOutOfJailFreeCards.Count.ToString();
            this.lblTotalJailCard.Text = "/ " + this.currentPlayer.GetOutOfJailFreeCards.Count.ToString();
            this.btnIncreaseJailCard.Enabled = false;
            this.btnLowerJailCard.Enabled = false;
        }

        /// <summary>
        /// The button to close the current form
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The button to submit info about the current form
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // int.Parse SHOULD ALWAYS be ok here because I validate it originally.
            TradeConfirm confirm = new TradeConfirm(this.game, this.currentPlayer, this.chosenPlayer, this.requesterOffer, this.targetOffer, int.Parse(this.lastConfirmed), int.Parse(this.txtJailCard.Text));
            confirm.ShowDialog();

            if (confirm.Reason == "Yes")
            {
                this.Close();
            }
        }

        /// <summary>
        /// An event to check and perform an action when the text is changed for the txtRequesterMoney textbox
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void TxtRequesterMoney_TextChanged(object sender, EventArgs e)
        {
            // Make a variable to store what their offer is
            int moneyChange = 0;

            // First, check to see if they entered the empty string or if they entered a (-) for a negative number
            if (this.txtRequesterMoney.Text == string.Empty || this.txtRequesterMoney.Text == "-")
            {
            }
            else
            {
                // Second, check to see if it is an int. If it is, sent it to the moneyChange variable
                if (int.TryParse(this.txtRequesterMoney.Text, out moneyChange))
                {
                    // Third, check to see if it is within the requesters balance
                    if (moneyChange < 0 && Math.Abs(moneyChange) > this.currentPlayer.Money)
                    {
                        MessageBox.Show("You cannot afford to pay this amount of money");
                        this.txtRequesterMoney.Text = this.lastConfirmed;
                    }
                    else
                    {
                        // Fourth, check to see if it is within the requestees balance
                        if (moneyChange > 0 && Math.Abs(moneyChange) > this.chosenPlayer.Money)
                        {
                            MessageBox.Show("The requestee cannot afford this change.");
                            this.txtRequesterMoney.Text = this.lastConfirmed;
                        }
                        else
                        {
                            // This code changes the requestee information based on the money amount the requester offers
                            // How much the requestees money is changing
                            this.txtRequesteeMoneyOffering.Text = (0 - moneyChange).ToString();

                            // To what the requestees balance is changing to
                            this.lblRequesteeMoneyNew.Text = (this.chosenPlayer.Money - moneyChange).ToString();

                            // How much the requesters money is changing
                            this.txtRequesterMoneyOffering.Text = (0 + moneyChange).ToString();

                            // To what the requesters balance is changing to
                            this.lblRequesterMoneyNew.Text = (this.currentPlayer.Money + moneyChange).ToString();

                            // Set the last successful number entered
                            this.lastConfirmed = this.txtRequesterMoney.Text;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an integer number.");
                    this.txtRequesterMoney.Text = this.lastConfirmed;
                }
            }
        }

        /// <summary>
        /// The button to check if they've chosen a player to trade with
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void CmboRequestee_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (Player p in this.players)
            {
                if (p.PlayerName == (string)this.cmboRequestee.SelectedItem)
                {
                    this.chosenPlayer = p;
                    this.txtRequesterMoney.Enabled = true;
                    this.lstRequesterProperties.Enabled = true;
                    this.lstRequesterOffering.Enabled = true;
                    this.lstRequesteeProperties.Enabled = true;
                    this.lstRequesteeOffering.Enabled = true;
                    this.btnSubmit.Enabled = true;
                    this.lblRequesteeTotal.Text = p.Money.ToString();

                    // Clear the list
                    this.lstRequesteeProperties.Items.Clear();
                    this.lstRequesteeOffering.Items.Clear();

                    // Instantiate and fill a list of the requestees spots
                    this.target = new List<Spot>();

                    this.target = this.chosenPlayer.GetPlayersPropertyList(this.game.Board);

                    this.FillListView(this.lstRequesteeProperties, this.target);

                    // Reset the offer list if a new player is selected
                    this.targetOffer = new List<Spot>();

                    if (this.chosenPlayer.GetOutOfJailFreeCards.Count > 0)
                    {
                        this.btnIncreaseJailCard.Enabled = true;
                    }

                    if (this.currentPlayer.GetOutOfJailFreeCards.Count > 0)
                    {
                        this.btnLowerJailCard.Enabled = true;
                    }

                    this.lblRequesteeJailCardTotal.Text = this.chosenPlayer.GetOutOfJailFreeCards.Count.ToString();
                    this.lblRequesteeBeforeJailCard.Text = this.chosenPlayer.GetOutOfJailFreeCards.Count.ToString();
                    this.txtMessage.Visible = false;
                }
            }
        }

        /// <summary>
        /// The event to check if the user double clicked on the list view
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void LstRequesterProperties_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstRequesterProperties.SelectedItems[0] != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in this.requester)
                {
                    if (s.SpotName == this.lstRequesterProperties.SelectedItems[0].Text)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the requester will keep 
                            // Add it to the list of spots to add to the other
                            this.requester.Remove(s);
                            this.requesterOffer.Add(s);

                            // Remove it from the spots that the requester will keep
                            // Add it to the list of spots to add to the other
                            this.lstRequesterOffering.Items.Add(this.lstRequesterProperties.SelectedItems[0].Text);
                            this.lstRequesterProperties.Items.RemoveAt(this.lstRequesterProperties.SelectedIndices[0]);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The event to check if the user double clicks the requesterOffering list view
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void LstRequesterOffering_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstRequesterOffering.SelectedItem != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in this.requesterOffer)
                {
                    if (s.SpotName == (string)this.lstRequesterOffering.SelectedItem)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the requester will keep 
                            // Add it to the list of spots to add to the other
                            this.requesterOffer.Remove(s);
                            this.requester.Add(s);

                            // Remove it from the spots that the requester will keep
                            // Add it to the list of spots to add to the other
                            // lstRequesterProperties.Items.Add(lstRequesterOffering.SelectedItem.ToString());
                            this.FillListView(this.lstRequesterProperties, this.requester);
                            this.lstRequesterOffering.Items.RemoveAt(this.lstRequesterOffering.SelectedIndex);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The event to check if the user double clicks on the requestee Properties list view
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void LstRequesteeProperties_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstRequesteeProperties.SelectedItems[0] != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in this.target)
                {
                    if (s.SpotName == this.lstRequesteeProperties.SelectedItems[0].Text)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the target will keep
                            // Add it to the list of spots to add to the other
                            this.target.Remove(s);
                            this.targetOffer.Add(s);

                            // Remove if from the listbox of spots that the target will keep
                            // Add it to the listbox of spots to add to the other
                            this.lstRequesteeOffering.Items.Add(this.lstRequesteeProperties.SelectedItems[0].Text);
                            this.lstRequesteeProperties.Items.RemoveAt(this.lstRequesteeProperties.SelectedIndices[0]);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The event to check if the user double clicked on the requestee Offering list view
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void LstRequesteeOffering_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstRequesteeOffering.SelectedItem != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in this.targetOffer)
                {
                    if (s.SpotName == (string)this.lstRequesteeOffering.SelectedItem)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the target will keep
                            // Add it to the list of spots to add to the other
                            this.targetOffer.Remove(s);
                            this.target.Add(s);

                            // Remove if from the listbox of spots that the target will keep
                            // Add it to the listbox of spots to add to the other
                            // lstRequesteeProperties.Items.Add(lstRequesteeOffering.SelectedItem.ToString());
                            this.FillListView(this.lstRequesteeProperties, this.target);
                            this.lstRequesteeOffering.Items.RemoveAt(this.lstRequesteeOffering.SelectedIndex);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The button increase the amount of jail cards the player who initiated the trade is getting by 1
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void BtnIncreaseJailCard_Click(object sender, EventArgs e)
        {
            int currentSelection = int.Parse(this.txtJailCard.Text);
            int newSelection = currentSelection += 1;

            this.lblRequesteeAfterJailCard.Text = (this.chosenPlayer.GetOutOfJailFreeCards.Count - newSelection).ToString();
            this.lblRequesterAfterJailCard.Text = (this.currentPlayer.GetOutOfJailFreeCards.Count + newSelection).ToString();

            this.txtJailCard.Text = newSelection.ToString();

            if (this.chosenPlayer.GetOutOfJailFreeCards.Count - newSelection > 0)
            {
                this.btnIncreaseJailCard.Enabled = true;
            }
            else
            {
                this.btnIncreaseJailCard.Enabled = false;
            }

            if (this.currentPlayer.GetOutOfJailFreeCards.Count + newSelection > 0)
            {
                this.btnLowerJailCard.Enabled = true;
            }
            else
            {
                this.btnLowerJailCard.Enabled = false;
            }
        }

        /// <summary>
        /// The button decrease the amount of jail cards the player who initiated the trade is getting by 1
        /// </summary>
        /// <param name="sender">The sender for the event</param>
        /// <param name="e">The eventArgs for the event</param>
        private void BtnLowerJailCard_Click(object sender, EventArgs e)
        {
            int currentSelection = int.Parse(txtJailCard.Text);
            int newSelection = currentSelection -= 1;

            this.lblRequesteeAfterJailCard.Text = (this.chosenPlayer.GetOutOfJailFreeCards.Count - newSelection).ToString();
            this.lblRequesterAfterJailCard.Text = (this.currentPlayer.GetOutOfJailFreeCards.Count + newSelection).ToString();

            this.txtJailCard.Text = newSelection.ToString();

            if (this.chosenPlayer.GetOutOfJailFreeCards.Count - newSelection > 0)
            {
                this.btnIncreaseJailCard.Enabled = true;
            }
            else
            {
                this.btnIncreaseJailCard.Enabled = false;
            }

            if (this.currentPlayer.GetOutOfJailFreeCards.Count + newSelection > 0)
            {
                this.btnLowerJailCard.Enabled = true;
            }
            else
            {
                this.btnLowerJailCard.Enabled = false;
            }
        }
    }
}

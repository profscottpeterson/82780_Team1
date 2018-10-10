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
    public partial class Trade : Form
    {
        private Player currentPlayer = new Player();
        private Player chosenPlayer = new Player();
        private Game game = new Game();
        private List<Player> players;
        private string lastConfirmed = "0";

        // List for requester and what they are giving up
        private List<Spot> requester = new List<Spot>();
        private List<Spot> requesterOffer = new List<Spot>();

        // List for target and what they are giving up
        private List<Spot> target = new List<Spot>();
        private List<Spot> targetOffer = new List<Spot>();

        public Trade(Player p, Game g)
        {
            InitializeComponent();
            currentPlayer = p;
            game = g;
            this.players = g.Players;
        }

        private void Trade_Load(object sender, EventArgs e)
        {
            //Instantiate and fill a list of the requesters spots
            requester = new List<Spot>();

            requester = game.GetPlayersPropertyList(currentPlayer);

            foreach (Spot s in requester)
            {
                lstRequesterProperties.Items.Add(s.SpotName);
            }

            // set the requesters money equal to their current money in game
            lblRequesterTotal.Text = "/ " + currentPlayer.Money.ToString();

            // Add the choice to choose which player the requester wants to trade with
            foreach (Player p in players)
            {
                if (currentPlayer.PlayerName != p.PlayerName)
                {
                    // If the player isn't the requester, add them to the combo box
                    cmboRequestee.Items.Add(p.PlayerName);
                }
            }

            // Change current players name
            lblRequesterName.Text = currentPlayer.PlayerName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // int.Parse SHOULD ALWAYS be ok here because I validate it originally.
            TradeConfirm confirm = new TradeConfirm(game, currentPlayer, chosenPlayer, requesterOffer, targetOffer, int.Parse(lastConfirmed));
            confirm.ShowDialog();

            if (confirm.reason == "Yes")
            {
                this.Close();
            }
        }

        private void txtRequesterMoney_TextChanged(object sender, EventArgs e)
        {
            // Make a variable to store what their offer is
            int moneyChange = 0;

            // First, check to see if they entered the empty string or if they entered a (-) for a negative number
            if (txtRequesterMoney.Text == "" || txtRequesterMoney.Text == "-")
            {

            }
            else
            {
                // Second, check to see if it is an int. If it is, sent it to the moneyChange variable
                if ((int.TryParse(txtRequesterMoney.Text, out moneyChange)))
                {
                    // Third, check to see if it is within the requesters balance
                    if (moneyChange < 0 && Math.Abs(moneyChange) > currentPlayer.Money)
                    {
                        MessageBox.Show("You cannot afford to pay this amount of money");
                        txtRequesterMoney.Text = lastConfirmed;
                    }
                    else
                    {
                        // Fourth, check to see if it is within the requestees balance
                        if (moneyChange > 0 && Math.Abs(moneyChange) > chosenPlayer.Money)
                        {
                            MessageBox.Show("The requestee cannot afford this change.");
                            txtRequesterMoney.Text = lastConfirmed;
                        }
                        else
                        {
                            //This code changes the requestee information based on the money amount the requester offers
                            // How much the requestees money is changing
                            txtRequesteeMoneyOffering.Text = (0 - moneyChange).ToString();

                            // To what the requestees balance is changing to
                            lblRequesteeMoneyNew.Text = (chosenPlayer.Money - moneyChange).ToString();

                            // How much the requesters money is changing
                            txtRequesterMoneyOffering.Text = (0 + moneyChange).ToString();

                            // To what the requesters balance is changing to
                            lblRequesterMoneyNew.Text = (currentPlayer.Money + moneyChange).ToString();

                            // Set the last successful number entered
                            lastConfirmed = txtRequesterMoney.Text;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter an integer number.");
                    txtRequesterMoney.Text = lastConfirmed;
                }
            }
        }

        private void cmboRequestee_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (Player p in players)
            {
                if (p.PlayerName == (string)cmboRequestee.SelectedItem)
                {
                    chosenPlayer = p;
                    txtRequesterMoney.Enabled = true;
                    lstRequesterProperties.Enabled = true;
                    lstRequesterOffering.Enabled = true;
                    lstRequesteeProperties.Enabled = true;
                    lstRequesteeOffering.Enabled = true;
                    btnSubmit.Enabled = true;
                    lblRequesteeTotal.Text = p.Money.ToString();

                    // Clear the list
                    lstRequesteeProperties.Items.Clear();
                    lstRequesteeOffering.Items.Clear();

                    // Instantiate and fill a list of the requestees spots
                    target = new List<Spot>();

                    target = game.GetPlayersPropertyList(chosenPlayer);

                    foreach (Spot s in target)
                    {
                        lstRequesteeProperties.Items.Add(s.SpotName);
                    }

                    // Reset the offer list if a new player is selected
                    targetOffer = new List<Spot>();
                }
            }
        }

        private void lstRequesterProperties_DoubleClick(object sender, EventArgs e)
        {
            if (lstRequesterProperties.SelectedItem != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in requester)
                {
                    if (s.SpotName == (string)lstRequesterProperties.SelectedItem)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the requester will keep 
                            // Add it to the list of spots to add to the other
                            requester.Remove(s);
                            requesterOffer.Add(s);

                            // Remove it from the spots that the requester will keep
                            // Add it to the list of spots to add to the other
                            lstRequesterOffering.Items.Add(lstRequesterProperties.SelectedItem);
                            lstRequesterProperties.Items.RemoveAt(lstRequesterProperties.SelectedIndex);
                            break;
                        }
                    }
                }
            }
        }

        private void lstRequesterOffering_DoubleClick(object sender, EventArgs e)
        {
            if (lstRequesterOffering.SelectedItem != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in requesterOffer)
                {
                    if (s.SpotName == (string)lstRequesterOffering.SelectedItem)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the requester will keep 
                            // Add it to the list of spots to add to the other
                            requesterOffer.Remove(s);
                            requester.Add(s);

                            // Remove it from the spots that the requester will keep
                            // Add it to the list of spots to add to the other
                            lstRequesterProperties.Items.Add(lstRequesterOffering.SelectedItem);
                            lstRequesterOffering.Items.RemoveAt(lstRequesterOffering.SelectedIndex);
                            break;
                        }
                    }
                }
            }
        }

        private void lstRequesteeProperties_DoubleClick(object sender, EventArgs e)
        {
            if (lstRequesteeProperties.SelectedItem != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in target)
                {
                    if (s.SpotName == (string)lstRequesteeProperties.SelectedItem)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the target will keep
                            // Add it to the list of spots to add to the other
                            target.Remove(s);
                            targetOffer.Add(s);

                            // Remove if from the listbox of spots that the target will keep
                            // Add it to the listbox of spots to add to the other
                            lstRequesteeOffering.Items.Add(lstRequesteeProperties.SelectedItem);
                            lstRequesteeProperties.Items.RemoveAt(lstRequesteeProperties.SelectedIndex);
                            break;
                        }
                    }
                }
            }
        }

        private void lstRequesteeOffering_DoubleClick(object sender, EventArgs e)
        {
            if (lstRequesteeOffering.SelectedItem != null)
            {
                // Check for the spot with the spot name as listed by the listbox
                foreach (Spot s in targetOffer)
                {
                    if (s.SpotName == (string)lstRequesteeOffering.SelectedItem)
                    {
                        if (s.HasHotel || s.NumberOfHouses > 0)
                        {
                            MessageBox.Show("Cannot sell, this property has a hotel or a house on it.");
                        }
                        else
                        {
                            // Remove it from the spots that the target will keep
                            // Add it to the list of spots to add to the other
                            targetOffer.Remove(s);
                            target.Add(s);

                            // Remove if from the listbox of spots that the target will keep
                            // Add it to the listbox of spots to add to the other
                            lstRequesteeProperties.Items.Add(lstRequesteeOffering.SelectedItem);
                            lstRequesteeOffering.Items.RemoveAt(lstRequesteeOffering.SelectedIndex);
                            break;
                        }
                    }
                }
            }
        }
    }
}

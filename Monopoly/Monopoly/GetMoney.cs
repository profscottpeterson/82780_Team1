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
    public partial class GetMoney : Form
    {
        /// <summary>
        /// Stores the debt of the player - if there is one.
        /// </summary>
        private int debt = 0;

        /// <summary>
        /// The current game session
        /// </summary>
        public Game game;

        /// <summary>
        /// Stores the current spot
        /// </summary>
        public Spot currentSpot;

        /// <summary>
        /// Store the current players list of properties
        /// </summary>
        public List<Spot> playerSpots = new List<Spot>();

        /// <summary>
        /// Stores the current Player
        /// </summary>
        public Player currentPlayer = new Player();

        /// <summary>
        /// Get a list of the colors that are eligible for a house
        /// </summary>
        public List<Color> houseEligible = new List<Color>();

        /// <summary>
        /// Gets or sets the debt of the player
        /// </summary>
        public int Debt { set { this.debt = value; } get { return this.debt; } }

        public GetMoney(Game game, Player currentPlayer)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
            this.game = game;
            this.currentPlayer = currentPlayer;

            //Get the current players list of properties
            this.playerSpots = game.GetPlayersPropertyList(this.currentPlayer);

            FillListView(listViewProperties, this.playerSpots);

            lblTotalDebt.Text = "0";
            lblDebtCurrent.Text = "0";
            lblPlayerName.Text = this.currentPlayer.PlayerName;
            lblMoney.Text = this.currentPlayer.Money.ToString();

            fillColors(playerSpots);
        }

        public GetMoney(Game game, Player currentPlayer, int debt)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
            this.Debt = debt;
            this.game = game;
            this.currentPlayer = currentPlayer;

            //Get the current players list of properties
            this.playerSpots = game.GetPlayersPropertyList(this.currentPlayer);

            FillListView(listViewProperties, this.playerSpots);
            lblTotalDebt.Text = debt.ToString();
            lblDebtCurrent.Text = debt.ToString();
            lblPlayerName.Text = this.currentPlayer.PlayerName;
            lblMoney.Text = this.currentPlayer.Money.ToString();

            fillColors(playerSpots);
        }

        private void fillColors(List<Spot> prop)
        {
            this.houseEligible = this.game.CheckIfEligibleForHouse(prop);
        }

        /// <summary>
        /// Will probably end up closing the form
        /// </summary>
        /// <param name="sender">Object clicked</param>
        /// <param name="e">Event arguments</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblDebtCurrent.Text) > 0)
            {

            }
            else
            {
                this.Close();
            }
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
                listView.Columns.Add("Property Name", 100);
                listView.Columns.Add("Mortgage", 75);
            }

            // Array to hold to contents of each row of the list view
            string[] rowContents = new string[2];

            // Loop through each spot in list of spots given
            foreach (Spot s in spots)
            {
                // Put the spot name in the first column
                rowContents[0] = s.SpotName;

                // Put the price in the second column
                rowContents[1] = s.Mortgage.ToString("c0");

                // Create a list view item that is a row made up of the spot name and price
                var row = new ListViewItem(rowContents);

                // Add created row to list view
                listView.Items.Add(row);
            }

            // Loop through each item in the list view
            foreach (ListViewItem item in listView.Items)
            {
                // Get the spot that corresponds with the spot name
                Spot spot = game.GetSpotByName(item.Text);

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
                    else if (spot.Color == Color.Pink)
                    {
                        item.ForeColor = Color.DeepPink;
                    }
                    else if (spot.Color == Color.Yellow)
                    {
                        item.ForeColor = Color.FromArgb(255, 220, 220, 0);
                    }
                    else if (spot.Color == Color.Orange)
                    {
                        item.ForeColor = Color.DarkOrange;
                    }
                }
            }
        }

        private void reset()
        {
            this.btnMortage.Enabled = false;
            this.btnSellHotel.Enabled = false;
            this.btnSellHouse.Enabled = false;
        }

        private void btnSellHouse_Click(object sender, EventArgs e)
        {
            this.game.Board[this.currentSpot.SpotId].NumberOfHouses -= 1;
            this.game.Players[this.currentPlayer.PlayerId].Money += int.Parse(lblMoneyGainFromHouse.Text);
            this.currentSpot = this.game.Board[this.currentSpot.SpotId];
            this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];

            lblMoney.Text = this.currentPlayer.Money.ToString();

            int remainingDebt = int.Parse(lblDebtCurrent.Text);

            int newDebt = remainingDebt - int.Parse(lblMoneyGainFromHouse.Text);

            if (newDebt < 0)
            {
                newDebt = 0;
            }

            lblDebtCurrent.Text = newDebt.ToString();

            reset();
        }

        private void btnSellHotel_Click(object sender, EventArgs e)
        {
            this.game.Board[this.currentSpot.SpotId].HasHotel = false;
            this.game.Players[this.currentPlayer.PlayerId].Money += int.Parse(lblMoneyGainFromHotel.Text);
            this.currentSpot = this.game.Board[this.currentSpot.SpotId];
            this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];

            lblMoney.Text = this.currentPlayer.Money.ToString();

            int remainingDebt = int.Parse(lblDebtCurrent.Text);

            int newDebt = remainingDebt - int.Parse(lblMoneyGainFromHotel.Text);

            if (newDebt < 0)
            {
                newDebt = 0;
            }

            lblDebtCurrent.Text = newDebt.ToString();

            reset();
        }

        private void btnMortage_Click(object sender, EventArgs e)
        {
            this.game.Board[this.currentSpot.SpotId].IsMortgaged = true;
            this.game.Players[this.currentPlayer.PlayerId].Money += this.currentSpot.Mortgage;
            this.currentSpot = this.game.Board[this.currentSpot.SpotId];
            this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];

            lblMoney.Text = this.currentPlayer.Money.ToString();

            int remainingDebt = int.Parse(lblDebtCurrent.Text);

            int newDebt = remainingDebt - this.currentSpot.Mortgage;

            if (newDebt < 0)
            {
                newDebt = 0;
            }

            lblDebtCurrent.Text = newDebt.ToString();

            reset();
        }

        private void btnForfeit_Click(object sender, EventArgs e)
        {
            game.Forfeit(currentPlayer);
            this.Close();
        }

        private void listViewProperties_Click(object sender, EventArgs e)
        {
            //check if selected item isn't null
            if (listViewProperties.SelectedItems[0] != null)
            {
                txtErrors.Text = "";

                reset();
                //find the current spot
                foreach (Spot s in playerSpots)
                {
                    if (s.SpotName == listViewProperties.SelectedItems[0].Text)
                    {
                        this.currentSpot = s;
                    }
                }

                //Create a list of properties with the same color as the original
                List<Spot> sameType = new List<Spot>();

                foreach (Spot s in playerSpots)
                {
                    if (s.Color == currentSpot.Color && s.SpotName != currentSpot.SpotName)
                    {
                        sameType.Add(s);
                    }
                }

                //fill the labels with information
                if (this.currentSpot.HasHotel)
                {
                    this.lblNumHotel.Text = "1";
                    btnSellHotel.Enabled = true;
                }
                else
                {
                    if (this.currentSpot.IsMortgaged == false)
                    {
                        this.lblNumHotel.Text = "0";

                        //one of the property colors with only 2 properties
                        if (sameType.Count == 1 && (this.currentSpot.Color == Color.Brown || this.currentSpot.Color == Color.DarkBlue))
                        {
                            //both properties have the same number of houses
                            if (sameType[0].NumberOfHouses == this.currentSpot.NumberOfHouses)
                            {
                                // if the other property with the same color has a hotel still
                                if (sameType[0].HasHotel)
                                {
                                    txtErrors.Text = "Must sell hotel on other property";
                                }
                                else
                                {
                                    if (this.currentSpot.NumberOfHouses > 0)
                                    {
                                        btnSellHouse.Enabled = true;
                                    }

                                    if (this.currentSpot.NumberOfHouses == 0 && sameType[0].NumberOfHouses == 0)
                                    {
                                        btnMortage.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                //if they have more houses than the other property of the same color
                                if (this.currentSpot.NumberOfHouses > sameType[0].NumberOfHouses)
                                {
                                    btnSellHouse.Enabled = true;
                                }
                                else
                                {
                                    txtErrors.Text = "Another property of the same color has more houses than this one.";
                                }
                            }
                        }
                        else if (sameType.Count == 2)
                        {
                            //both properties have the same number of houses
                            if (sameType[0].NumberOfHouses == this.currentSpot.NumberOfHouses && this.currentSpot.NumberOfHouses == sameType[1].NumberOfHouses)
                            {
                                // if the other property with the same color has a hotel still
                                if (sameType[0].HasHotel || sameType[1].HasHotel)
                                {
                                    txtErrors.Text = "Must sell hotel on other property";
                                }
                                else
                                {
                                    if (this.currentSpot.NumberOfHouses > 0)
                                    {
                                        btnSellHouse.Enabled = true;
                                    }
                                    if (this.currentSpot.NumberOfHouses == 0 && sameType[0].NumberOfHouses == 0 && sameType[1].NumberOfHouses == 0)
                                    {
                                        btnMortage.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                //if they have more houses than the other property of the same color
                                if (this.currentSpot.NumberOfHouses > sameType[0].NumberOfHouses || this.currentSpot.NumberOfHouses > sameType[1].NumberOfHouses)
                                {
                                    btnSellHouse.Enabled = true;
                                }
                                else
                                {
                                    txtErrors.Text = "Another property of the same color has more houses than this one.";
                                }
                            }
                        }
                        else
                        {
                            if (!this.currentSpot.IsMortgaged)
                            {
                                btnMortage.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        btnMortage.Enabled = false;
                    }
                }

                lblNumHouse.Text = this.currentSpot.NumberOfHouses.ToString();
                lblMoneyGainFromHotel.Text = "+" + (this.currentSpot.HotelCost / 2).ToString();
                lblMoneyGainFromHouse.Text = "+" + (this.currentSpot.HouseCost / 2).ToString();
                lblMortgageGain.Text = this.currentSpot.Mortgage.ToString();

                //Put on the property name
                this.lblPropertyName.Text = this.currentSpot.SpotName;
                this.lblPropertyName.ForeColor = this.currentSpot.Color;

                if (this.lblPropertyName.ForeColor == Color.Yellow)
                {
                    this.lblPropertyName.ForeColor = Color.YellowGreen;
                }
                if (this.lblPropertyName.ForeColor == Color.LightBlue)
                {
                    this.lblPropertyName.ForeColor = Color.Blue;
                }
                if (this.lblPropertyName.ForeColor == Color.Pink)
                {
                    this.lblPropertyName.ForeColor = Color.DeepPink;
                }

                //refill the list view
                //this.FillListView(listViewProperties, playerSpots);
            }
        }
    }
}

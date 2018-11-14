//-----------------------------------------------------------------------
// <copyright file="GetMoney.cs" company="null">
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
    /// The get money form
    /// </summary>
    public partial class GetMoney : Form
    {
        /// <summary>
        /// The current game session
        /// </summary>
        private Game game;

        /// <summary>
        /// Stores the current spot
        /// </summary>
        private Spot currentSpot;

        /// <summary>
        /// Store the current players list of properties
        /// </summary>
        private List<Spot> playerSpots = new List<Spot>();

        /// <summary>
        /// Stores the current Player
        /// </summary>
        private Player currentPlayer = new Player();

        /// <summary>
        /// Get a list of the colors that are eligible for a house
        /// </summary>
        private List<Color> houseEligible = new List<Color>();

        /// <summary>
        /// Stores the debt of the player - if there is one.
        /// </summary>
        private int debt = 0;

        /// <summary>
        /// Initializes a new instance of the GetMoney class
        /// </summary>
        /// <param name="game">The game</param>
        /// <param name="currentPlayer">The current player</param>
        public GetMoney(Game game, Player currentPlayer)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
            this.game = game;
            this.currentPlayer = currentPlayer;

            // Get the current players list of properties
            this.playerSpots = currentPlayer.GetPlayersPropertyList(game.Board);

            this.FillListView(this.listViewProperties, this.playerSpots);

            this.lblTotalDebt.Text = "0";
            this.lblDebtCurrent.Text = "0";
            this.lblPlayerName.Text = this.currentPlayer.PlayerName;
            this.lblMoney.Text = this.currentPlayer.Money.ToString();

            this.FillColors(this.playerSpots);
        }

        /// <summary>
        /// Initializes a new instance of the GetMoney class
        /// </summary>
        /// <param name="game">The game</param>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="debt">The players debt</param>
        public GetMoney(Game game, Player currentPlayer, int debt)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
            this.Debt = debt;
            this.game = game;
            this.currentPlayer = currentPlayer;

            // Get the current players list of properties
            this.playerSpots = currentPlayer.GetPlayersPropertyList(game.Board);

            if (this.currentPlayer.IsAi == false)
            {
                this.FillListView(this.listViewProperties, this.playerSpots);
                this.lblTotalDebt.Text = debt.ToString();
                this.lblDebtCurrent.Text = debt.ToString();
                this.lblPlayerName.Text = this.currentPlayer.PlayerName;
                this.lblMoney.Text = this.currentPlayer.Money.ToString();

                this.FillColors(this.playerSpots);
            }
            else
            {
                while (this.Debt > 0)
                {
                    for (int x = 0; x < this.playerSpots.Count; x++)
                    {
                        if (this.Debt > 0)
                        {
                            this.currentSpot = this.playerSpots[x];
                            if (this.currentSpot.HasHotel == true)
                            {
                                this.BtnSellHotel_Click(this.currentSpot, EventArgs.Empty);
                            }
                            else if (this.currentSpot.NumberOfHouses > 0)
                            {
                                this.BtnSellHouse_Click(this.currentSpot, EventArgs.Empty);
                            }
                            else if (this.currentSpot.IsMortgaged == false)
                            {
                                this.BtnMortgage_Click(this.currentSpot, EventArgs.Empty);
                            }

                            if (x == this.playerSpots.Count)
                            {
                                if (this.Debt > 0)
                                {
                                    this.BtnForfeit_Click(this.currentPlayer, EventArgs.Empty);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this.BtnSubmit_Click(this.currentPlayer, EventArgs.Empty);
                            break;
                        }
                    }

                    if (this.Debt <= 0)
                    {
                        this.BtnSubmit_Click(this.currentPlayer, EventArgs.Empty);
                        break;
                    }
                    else
                    {
                        this.BtnForfeit_Click(this.currentPlayer, EventArgs.Empty);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the debt of the player
        /// </summary>
        private int Debt
        {
            get { return this.debt; }
            set { this.debt = value; }
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
                listView.Columns.Add("Mortgage", 60);
                listView.Columns.Add("Is Mortgaged", 75);
                listView.Columns.Add("Houses", 50);
                listView.Columns.Add("Hotel", 50);
            }

            // Array to hold to contents of each row of the list view
            string[] rowContents = new string[5];

            // Loop through each spot in list of spots given
            foreach (Spot s in spots)
            {
                // Put the spot name in the first column
                rowContents[0] = s.SpotName;

                // Put the price in the second column
                rowContents[1] = s.Mortgage.ToString("c0");

                // Put whether the property is mortgaged in the third column
                rowContents[2] = s.IsMortgaged.ToString();

                // Put the number of houses a property has in the fourth column
                rowContents[3] = s.NumberOfHouses.ToString();

                // Put whether a property has a hotel has in the fifth column
                rowContents[4] = s.HasHotel.ToString();

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
        /// Fills the colors for the spots
        /// </summary>
        /// <param name="prop">The list of properties</param>
        private void FillColors(List<Spot> prop)
        {
            this.houseEligible = Game.CheckIfEligibleForHouse(prop);
        }

        /// <summary>
        /// Will probably end up closing the form
        /// </summary>
        /// <param name="sender">Object clicked</param>
        /// <param name="e">Event arguments</param>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.lblDebtCurrent.Text) > 0)
            {
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Sets the form buttons to false
        /// </summary>
        private void Reset()
        {
            this.btnMortage.Enabled = false;
            this.btnSellHotel.Enabled = false;
            this.btnSellHouse.Enabled = false;
        }

        /// <summary>
        /// The method for selling a house on a property
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnSellHouse_Click(object sender, EventArgs e)
        {
            this.game.Board[this.currentSpot.SpotId].NumberOfHouses -= 1;
            this.game.Players[this.currentPlayer.PlayerId].Money += this.currentSpot.HouseCost / 2;
            this.currentSpot = this.game.Board[this.currentSpot.SpotId];
            this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];

            if (this.currentPlayer.IsAi == false)
            {
                this.lblMoney.Text = this.currentPlayer.Money.ToString();

                int remainingDebt = int.Parse(this.lblDebtCurrent.Text);

                int newDebt = remainingDebt - (this.currentSpot.HouseCost / 2);

                if (newDebt < 0)
                {
                    newDebt = 0;
                }

            this.FillListView(this.listViewProperties, this.currentPlayer.GetPlayersPropertyList(this.game.Board));

                this.lblDebtCurrent.Text = newDebt.ToString();

                this.Reset();
            }
        }

        /// <summary>
        /// The button used for selling a hotel on a property.
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnSellHotel_Click(object sender, EventArgs e)
        {
            this.game.Board[this.currentSpot.SpotId].HasHotel = false;
            this.game.Players[this.currentPlayer.PlayerId].Money += this.currentSpot.HotelCost / 2;
            this.currentSpot = this.game.Board[this.currentSpot.SpotId];
            this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];

            if (this.currentPlayer.IsAi == false)
            {
                this.lblMoney.Text = this.currentPlayer.Money.ToString();

                int remainingDebt = int.Parse(this.lblDebtCurrent.Text);

                int newDebt = remainingDebt - (this.currentSpot.HotelCost / 2);

                if (newDebt < 0)
                {
                    newDebt = 0;
                }

            this.FillListView(this.listViewProperties, this.currentPlayer.GetPlayersPropertyList(this.game.Board));

                this.lblDebtCurrent.Text = newDebt.ToString();

                this.Reset();
            }
        }

        /// <summary>
        /// The button for mortgaging a property.
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnMortgage_Click(object sender, EventArgs e)
        {
            this.game.Board[this.currentSpot.SpotId].IsMortgaged = true;
            this.game.Players[this.currentPlayer.PlayerId].Money += this.currentSpot.Mortgage;
            this.currentSpot = this.game.Board[this.currentSpot.SpotId];
            this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];

            if (this.currentPlayer.IsAi == false)
            {
                this.lblMoney.Text = this.currentPlayer.Money.ToString();

                int remainingDebt = int.Parse(this.lblDebtCurrent.Text);

                int newDebt = remainingDebt - this.currentSpot.Mortgage;

                if (newDebt < 0)
                {
                    newDebt = 0;
                }

            this.FillListView(this.listViewProperties, this.currentPlayer.GetPlayersPropertyList(this.game.Board));

                this.lblDebtCurrent.Text = newDebt.ToString();

                this.Reset();
            }
        }

        /// <summary>
        /// The button for forfeiting the game
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnForfeit_Click(object sender, EventArgs e)
        {
            this.game.Forfeit(this.currentPlayer);
            this.Close();
        }

        /// <summary>
        /// The click event for the items in the list view of properties
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void ListViewProperties_Click(object sender, EventArgs e)
        {
            // check if selected item isn't null
            if (this.listViewProperties.SelectedItems[0] != null)
            {
                this.txtErrors.Text = string.Empty;

                this.Reset();

                // find the current spot
                foreach (Spot s in this.playerSpots)
                {
                    if (s.SpotName == this.listViewProperties.SelectedItems[0].Text)
                    {
                        this.currentSpot = s;
                    }
                }

                // Create a list of properties with the same color as the original
                List<Spot> sameType = new List<Spot>();

                foreach (Spot s in this.playerSpots)
                {
                    if (s.Color == this.currentSpot.Color && s.SpotName != this.currentSpot.SpotName)
                    {
                        sameType.Add(s);
                    }
                }

                // fill the labels with information
                if (this.currentSpot.HasHotel)
                {
                    this.btnSellHotel.Enabled = true;
                }
                else
                {
                    if (this.currentSpot.IsMortgaged == false)
                    {
                        // one of the property colors with only 2 properties
                        if (sameType.Count == 1 && (this.currentSpot.Color == Color.Brown || this.currentSpot.Color == Color.DarkBlue))
                        {
                            // both properties have the same number of houses
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
                                        this.btnSellHouse.Enabled = true;
                                    }

                                    if (this.currentSpot.NumberOfHouses == 0 && sameType[0].NumberOfHouses == 0)
                                    {
                                        this.btnMortage.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                // if they have more houses than the other property of the same color
                                if (this.currentSpot.NumberOfHouses > sameType[0].NumberOfHouses)
                                {
                                    this.btnSellHouse.Enabled = true;
                                }
                                else
                                {
                                    this.txtErrors.Text = "Another property of the same color has more houses than this one.";
                                }
                            }
                        }
                        else if (sameType.Count == 2)
                        {
                            // both properties have the same number of houses
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
                                        this.btnSellHouse.Enabled = true;
                                    }

                                    if (this.currentSpot.NumberOfHouses == 0 && sameType[0].NumberOfHouses == 0 && sameType[1].NumberOfHouses == 0)
                                    {
                                        this.btnMortage.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                // if they have more houses than the other property of the same color
                                if (this.currentSpot.NumberOfHouses > sameType[0].NumberOfHouses || this.currentSpot.NumberOfHouses > sameType[1].NumberOfHouses)
                                {
                                    this.btnSellHouse.Enabled = true;
                                }
                                else
                                {
                                    this.txtErrors.Text = "Another property of the same color has more houses than this one.";
                                }
                            }
                        }
                        else
                        {
                            if (!this.currentSpot.IsMortgaged)
                            {
                                this.btnMortage.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        this.btnMortage.Enabled = false;
                    }
                }
                
                this.lblMoneyGainFromHotel.Text = "+" + (this.currentSpot.HotelCost / 2).ToString("c0");
                this.lblMoneyGainFromHouse.Text = "+" + (this.currentSpot.HouseCost / 2).ToString("c0");

                // Put on the property name
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
            }
        }
    }
}

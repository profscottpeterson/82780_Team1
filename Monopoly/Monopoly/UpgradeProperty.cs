//-----------------------------------------------------------------------
// <copyright file="UpgradeProperty.cs" company="null">
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
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The UpgradeProperty class extends the Form class
    /// </summary>
    public partial class UpgradeProperty : Form
    {
        /// <summary>
        /// Gets or sets the game
        /// </summary>
        private Game game;

        /// <summary>
        /// Gets or sets the currentPlayer
        /// </summary>
        private Player currentPlayer;

        /// <summary>
        /// holds the list of spots that the currentPlayer has
        /// </summary>
        private List<Spot> playerSpots = new List<Spot>();

        /// <summary>
        /// holds the colors that are eligible for a house
        /// </summary>
        private List<Color> houseEligible = new List<Color>();

        /// <summary>
        /// Holds the colors that are eligible for a hotel
        /// </summary>
        private List<Color> hotelEligible = new List<Color>();

        /// <summary>
        /// Spot s
        /// </summary>
        private Spot selectedSpot = new Spot();

        /// <summary>
        /// List of spots whose color is selected
        /// </summary>
        private List<Spot> sameType = new List<Spot>();

        /// <summary>
        /// list of eligible spots
        /// </summary>
        private List<Spot> eligible = new List<Spot>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UpgradeProperty"/> class
        /// </summary>
        /// <param name="game">brings forth the current game</param>
        /// <param name="currentPlayer">brings forth the currentPlayer</param>
        public UpgradeProperty(Game game, Player currentPlayer)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
            this.game = game;
            this.currentPlayer = currentPlayer;

            // fill the list with the list of spots that the currentPlayer has
            this.playerSpots = currentPlayer.GetPlayersPropertyList(this.game.Board);

            this.lblMoneyTotal.Text = currentPlayer.Money.ToString();
            this.lblPlayerName.Text = currentPlayer.PlayerName;

            List<Spot> spotsEligible = new List<Spot>();

            List<Color> colorsEligible = Game.CheckIfEligibleForHouse(this.playerSpots);

            List<Spot> mortgage = new List<Spot>();

            foreach (Spot s in this.playerSpots)
            {
                if (s.IsMortgaged == true)
                {
                    mortgage.Add(s);
                }
            }

            if (colorsEligible.Count > 0 || mortgage.Count > 0)
            {
                // Get every spot that matches a color in the list
                foreach (Spot s in this.playerSpots)
                {
                    foreach (Color c in colorsEligible)
                    {
                        if ((s.Color == c || s.IsMortgaged == true) && !spotsEligible.Contains(s))
                        {
                            spotsEligible.Add(s);
                        }
                    }

                    if (!spotsEligible.Contains(s) && s.IsMortgaged)
                    {
                        spotsEligible.Add(s);
                    }
                }

                // fill public slot
                this.eligible = spotsEligible;

                if (this.currentPlayer.IsAi == false)
                {
                     // add them to the listView
                     this.FillListView(this.listViewProperties, spotsEligible);
                }
                else
                {
                    foreach (Spot s in this.eligible)
                    {
                        this.selectedSpot = s;

                        // List that holds the spots of the same type
                        this.sameType.Clear();

                        // Get a list of spots that share the same color
                        foreach (Spot g in this.playerSpots)
                        {
                            if (g.Color == this.selectedSpot.Color && g.SpotName != this.selectedSpot.SpotName)
                            {
                                this.sameType.Add(g);
                            }
                        }

                        // add houses/unmortgage/hotels to possible properties
                        PropertyLogic();
                    }

                    this.Close();
                }
            }
            else
            {
                if (this.currentPlayer.IsAi == false)
                {
                    MessageBox.Show("No Properties Eligible For Upgrade.");
                }

                this.Close();
            }
        }

        /// <summary>
        /// Reset the form buttons to not be enabled unless certain conditions are met
        /// </summary>
        public void Reset()
        {
            lblPropertyName.ForeColor = Color.Black;
            lblPropertyName.Text = "Choose another property";
            btnAddHotel.Enabled = false;
            btnAddHouse.Enabled = false;
            btnAddHouseToAll.Enabled = false;
            btnAddHotelToAll.Enabled = false;
            btnUnmortgage.Enabled = false;
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
                listView.Columns.Add("House Cost", 65);
                listView.Columns.Add("Hotel Cost", 65);
            }

            // Array to hold to contents of each row of the list view
            string[] rowContents = new string[3];

            // Loop through each spot in list of spots given
            foreach (Spot s in spots)
            {
                // Put the spot name in the first column
                rowContents[0] = s.SpotName;

                // Put the hosue cost in the second column
                rowContents[1] = s.HouseCost.ToString("c0");

                // Put the hotel cost in the third column
                rowContents[2] = s.HotelCost.ToString("c0");

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
        /// Closes the form
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Add a house to the selected property
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void BtnAddHouse_Click(object sender, EventArgs e)
        {
            this.game.Board[this.selectedSpot.SpotId].NumberOfHouses++;
            this.currentPlayer.Money = this.currentPlayer.Money - this.selectedSpot.HouseCost;
            this.lblMoneyTotal.Text = this.game.Players[this.currentPlayer.PlayerId].Money.ToString();

            this.Reset();
        }

        /// <summary>
        /// add a hotel to the selected property
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void BtnAddHotel_Click(object sender, EventArgs e)
        {
            this.game.Board[this.selectedSpot.SpotId].HasHotel = true;
            this.currentPlayer.Money = this.currentPlayer.Money - this.selectedSpot.HotelCost;
            this.lblMoneyTotal.Text = this.game.Players[this.currentPlayer.PlayerId].Money.ToString();

            this.Reset();
        }

        /// <summary>
        /// add house to all properties of a specific color
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void BtnAddHouseToAll_Click(object sender, EventArgs e)
        {
            if (this.sameType.Count == 2)
            {
                this.game.Board[this.sameType[0].SpotId].NumberOfHouses++;
                this.game.Board[this.sameType[1].SpotId].NumberOfHouses++;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HouseCost * 2);
            }
            else
            {
                this.game.Board[this.sameType[0].SpotId].NumberOfHouses++;
                this.game.Board[this.sameType[1].SpotId].NumberOfHouses++;
                this.game.Board[this.sameType[2].SpotId].NumberOfHouses++;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HouseCost * 3);
            }

            this.lblMoneyTotal.Text = this.game.Players[this.currentPlayer.PlayerId].Money.ToString();
            this.Reset();
        }

        /// <summary>
        /// add hotel to all properties of a specific color
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void BtnAddHotelToAll_Click(object sender, EventArgs e)
        {
            if (this.sameType.Count == 2)
            {
                this.game.Board[this.sameType[0].SpotId].HasHotel = true;
                this.game.Board[this.sameType[1].SpotId].HasHotel = true;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HotelCost * 2);
            }
            else
            {
                this.game.Board[this.sameType[0].SpotId].HasHotel = true;
                this.game.Board[this.sameType[1].SpotId].HasHotel = true;
                this.game.Board[this.sameType[2].SpotId].HasHotel = true;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HotelCost * 3);
            }

            this.lblMoneyTotal.Text = this.game.Players[this.currentPlayer.PlayerId].Money.ToString();
            this.Reset();
        }

        /// <summary>
        /// unmortgage the selected property
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void BtnUnmortgage_Click(object sender, EventArgs e)
        {
            this.game.Board[this.selectedSpot.SpotId].IsMortgaged = false;
            this.game.Players[this.currentPlayer.PlayerId].Money = this.game.Players[this.currentPlayer.PlayerId].Money - (int)(this.selectedSpot.Mortgage * 1.1);
            this.lblMoneyTotal.Text = this.game.Players[this.currentPlayer.PlayerId].Money.ToString();

            this.Reset();           
        }

        /// <summary>
        /// When the list view is clicked
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void ListViewProperties_Click(object sender, EventArgs e)
        {
            // Get the item selected in the list box right now
            int index = this.listViewProperties.SelectedIndices[0];

            // Get the name stored in the listview
            string name = this.listViewProperties.Items[index].SubItems[0].Text;

            // Search for the spot
            foreach (Spot s in this.playerSpots)
            {
                if (s.SpotName == name)
                {
                    this.selectedSpot = s;
                }
            }

            // List that holds the spots of the same type
            this.sameType.Clear();

            // Get a list of spots that share the same color
            foreach (Spot s in this.playerSpots)
            {
                if (s.Color == this.selectedSpot.Color && s.SpotName != this.selectedSpot.SpotName)
                {
                    this.sameType.Add(s);
                }
            }

            // default all buttons to false
            btnAddHouse.Enabled = false;
            btnAddHotel.Enabled = false;
            btnAddHouseToAll.Enabled = false;
            btnAddHotelToAll.Enabled = false;
            btnUnmortgage.Enabled = false;
            txtMessage.Text = string.Empty;

            PropertyLogic();

            // Add the selected spot to the list of spots for that color
            this.sameType.Add(this.selectedSpot);

            // Update text
            this.lblPropertyName.Text = this.selectedSpot.SpotName;
            this.lblPropertyName.ForeColor = this.selectedSpot.Color;

            if (this.lblPropertyName.ForeColor == Color.Yellow)
            {
                this.lblPropertyName.ForeColor = Color.YellowGreen;
            }

            if (this.lblPropertyName.ForeColor == Color.LightBlue)
            {
                this.lblPropertyName.ForeColor = Color.Blue;
            }

            // add them to the listView
            // FillListView(listViewProperties, eligible);
        }

        private void PropertyLogic()
        {
            // Activate buttons as they are possible
            if (this.sameType.Count == 1)
            {
                if (!this.selectedSpot.IsMortgaged)
                {
                    if (!this.sameType[0].IsMortgaged)
                    {
                        if (this.selectedSpot.NumberOfHouses < this.sameType[0].NumberOfHouses)
                        {
                            if (this.selectedSpot.HouseCost <= this.currentPlayer.Money)
                            {
                                if (currentPlayer.IsAi == false)
                                {
                                    this.btnAddHouse.Enabled = true;
                                }
                                else
                                {
                                    this.BtnAddHouse_Click(currentPlayer, EventArgs.Empty);
                                }
                                
                            }
                            else
                            {
                                this.txtMessage.Text = txtMessage.Text + " Not enough money to put a house on this property.";
                            }
                        }
                        else if (this.selectedSpot.NumberOfHouses == this.sameType[0].NumberOfHouses)
                        {
                            if (this.selectedSpot.NumberOfHouses == 4 && this.sameType[0].NumberOfHouses == 4)
                            {
                                if (this.selectedSpot.HasHotel)
                                {
                                }
                                else if (this.sameType[0].HasHotel)
                                {
                                    if (this.currentPlayer.Money >= this.selectedSpot.HotelCost)
                                    {
                                        if (currentPlayer.IsAi == false)
                                        {
                                            this.btnAddHotel.Enabled = true;
                                        }
                                        else
                                        {
                                            this.BtnAddHotel_Click(currentPlayer, EventArgs.Empty);
                                        }
                                        
                                    }
                                    else
                                    {
                                        this.txtMessage.Text =
                                            txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }
                                }
                                else
                                {
                                    if (this.currentPlayer.Money >= this.selectedSpot.HotelCost)
                                    {
                                        if (currentPlayer.IsAi == false)
                                        {
                                            this.btnAddHotel.Enabled = true;
                                        }
                                        else
                                        {
                                            this.BtnAddHotel_Click(currentPlayer, EventArgs.Empty);
                                        }
                                    }
                                    else
                                    {
                                        this.txtMessage.Text =
                                            txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }

                                    if (this.currentPlayer.Money >= (this.selectedSpot.HotelCost * 2))
                                    {
                                        if (currentPlayer.IsAi == false)
                                        {
                                            this.btnAddHotelToAll.Enabled = true;
                                        }
                                        else
                                        {
                                            this.BtnAddHotelToAll_Click(currentPlayer, EventArgs.Empty);
                                        }
                                    }
                                    else
                                    {
                                        this.txtMessage.Text =
                                            this.txtMessage.Text +
                                            " Not enough money to put a hotel on all properties of this color.";
                                    }
                                }
                            }
                            else
                            {
                                if (this.selectedSpot.HouseCost <= this.currentPlayer.Money)
                                {
                                    if (currentPlayer.IsAi == false)
                                    {
                                        this.btnAddHouse.Enabled = true;
                                    }
                                    else
                                    {
                                        this.BtnAddHouse_Click(currentPlayer, EventArgs.Empty);
                                    }
                                }
                                else
                                {
                                    this.txtMessage.Text =
                                        this.txtMessage.Text + " Not enough money to put a house on this property.";
                                }

                                if (this.currentPlayer.Money >= (this.selectedSpot.HouseCost * 2))
                                {
                                    if (currentPlayer.IsAi == false)
                                    {
                                        this.btnAddHouseToAll.Enabled = true;
                                    }
                                    else
                                    {
                                        this.BtnAddHouseToAll_Click(currentPlayer, EventArgs.Empty);
                                    }
                                }
                                else
                                {
                                    this.txtMessage.Text = this.txtMessage.Text +
                                                           " Not enough money to put a house on all properties of this color.";
                                }
                            }
                        }
                        else
                        {
                            this.txtMessage.Text = this.txtMessage.Text +
                                                   " This property has either more houses or a hotel than the other properties of the same color.";
                        }
                    }
                }
                else
                {
                    if (this.currentPlayer.Money >= (this.selectedSpot.Mortgage * 1.1))
                    {
                        if (this.currentPlayer.IsAi == false)
                        {
                            this.btnUnmortgage.Enabled = true;
                        }
                        else
                        {
                            this.BtnUnmortgage_Click(this.currentPlayer, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        this.txtMessage.Text =
                            this.txtMessage.Text + "You do not have enough money to un-mortgage this property";
                    }
                }
            }
            else if (this.sameType.Count == 2)
            {
                if (!this.selectedSpot.IsMortgaged)
                {
                    if (!this.sameType[0].IsMortgaged && !this.sameType[1].IsMortgaged)
                    {
                        if ((this.selectedSpot.NumberOfHouses < this.sameType[0].NumberOfHouses) ||
                            (this.selectedSpot.NumberOfHouses < this.sameType[1].NumberOfHouses))
                        {
                            if (this.currentPlayer.Money >= this.selectedSpot.HouseCost)
                            {
                                if (currentPlayer.IsAi == false)
                                {
                                    this.btnAddHouse.Enabled = true;
                                }
                                else
                                {
                                    this.BtnAddHouse_Click(currentPlayer, EventArgs.Empty);
                                }
                            }
                            else
                            {
                                this.txtMessage.Text =
                                    this.txtMessage.Text + " Not enough money to put a house on this property.";
                            }
                        }
                        else if ((this.selectedSpot.NumberOfHouses == this.sameType[0].NumberOfHouses) &&
                                 (this.selectedSpot.NumberOfHouses == this.sameType[1].NumberOfHouses))
                        {
                            if (this.selectedSpot.NumberOfHouses == 4 && this.sameType[0].NumberOfHouses == 4 &&
                                this.sameType[1].NumberOfHouses == 4)
                            {
                                if (this.selectedSpot.HasHotel)
                                {
                                }
                                else if (this.sameType[0].HasHotel || this.sameType[1].HasHotel)
                                {
                                    if (this.currentPlayer.Money >= this.selectedSpot.HotelCost)
                                    {
                                        if (currentPlayer.IsAi == false)
                                        {
                                            this.btnAddHotel.Enabled = true;
                                        }
                                        else
                                        {
                                            this.BtnAddHotel_Click(currentPlayer, EventArgs.Empty);
                                        }
                                    }
                                    else
                                    {
                                        this.txtMessage.Text =
                                            this.txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }
                                }
                                else
                                {
                                    if (this.currentPlayer.Money >= this.selectedSpot.HotelCost)
                                    {
                                        if (currentPlayer.IsAi == false)
                                        {
                                            this.btnAddHotel.Enabled = true;
                                        }
                                        else
                                        {
                                            this.BtnAddHotel_Click(currentPlayer, EventArgs.Empty);
                                        }
                                    }
                                    else
                                    {
                                        this.txtMessage.Text =
                                            this.txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }

                                    if (this.currentPlayer.Money >= (this.selectedSpot.HotelCost * 3))
                                    {
                                        this.btnAddHotelToAll.Enabled = true;
                                        this.txtMessage.Text =
                                            this.txtMessage.Text +
                                            " Not enough money to put a hotel on all properties of this color.";
                                    }
                                }
                            }
                            else
                            {
                                if (this.currentPlayer.Money >= this.selectedSpot.HouseCost)
                                {
                                    if (currentPlayer.IsAi == false)
                                    {
                                        this.btnAddHouse.Enabled = true;
                                    }
                                    else
                                    {
                                        this.BtnAddHouse_Click(currentPlayer, EventArgs.Empty);
                                    }
                                }
                                else
                                {
                                    this.txtMessage.Text =
                                        this.txtMessage.Text + " Not enough money to put a house on this property.";
                                }

                                if (this.currentPlayer.Money >= (this.selectedSpot.HouseCost * 3))
                                {
                                    this.btnAddHouseToAll.Enabled = true;
                                }
                                else
                                {
                                    this.txtMessage.Text = this.txtMessage.Text +
                                                           " Not enough money to put a house on all of the properties of this color.";
                                }
                            }
                        }
                        else
                        {
                            this.txtMessage.Text =
                                "This property has either more houses or a hotel than the other properties of the same color.";
                        }
                    }
                    else
                    {
                        this.txtMessage.Text =
                            "Other properties of this color are mortgaged - nothing can be upgraded on any of these properties.";
                    }
                }
                else
                {
                    if (this.currentPlayer.Money >= (int) (this.selectedSpot.Mortgage * 1.1))
                    {
                        this.btnUnmortgage.Enabled = true;
                    }
                    else
                    {
                        this.txtMessage.Text =
                            this.txtMessage.Text + "You do not have enough money to un-mortgage this property";
                    }
                }
            }
            else if (this.selectedSpot.IsMortgaged)
            {
                if (this.currentPlayer.Money >= (int) (this.selectedSpot.Mortgage * 1.1))
                {
                    this.btnUnmortgage.Enabled = true;
                }
                else
                {
                    this.txtMessage.Text = "You do not have enough money to un-mortgage this property";
                }
            }
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            HelpMenu hm = new HelpMenu("Upgrade Screen");
            hm.ShowDialog();
        }
    }
}

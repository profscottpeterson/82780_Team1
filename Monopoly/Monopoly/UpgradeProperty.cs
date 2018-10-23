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

namespace Monopoly
{
    public partial class UpgradeProperty : Form
    {
        /// <summary>
        /// Holds the game
        /// </summary>
        public Game game = new Game();

        /// <summary>
        /// Holds the currentPlayer
        /// </summary>
        public Player currentPlayer = new Player();

        /// <summary>
        /// holds the list of spots that the currentPlayer has
        /// </summary>
        public List<Spot> playerSpots = new List<Spot>();

        /// <summary>
        /// holds the colors that are eligible for a house
        /// </summary>
        public List<Color> houseEligible = new List<Color>();

        /// <summary>
        /// Holds the colors that are eligible for a hotel
        /// </summary>
        public List<Color> hotelEligible = new List<Color>();

        /// <summary>
        /// Spot s
        /// </summary>
        public Spot selectedSpot = new Spot();

        /// <summary>
        /// List of spots whose color is selected
        /// </summary>
        public List<Spot> sameType = new List<Spot>();

        /// <summary>
        /// list of eligible spots
        /// </summary>
        public List<Spot> eligible = new List<Spot>();

        /// <summary>
        /// Creates a new instance of the UpgradeProperty class
        /// </summary>
        /// <param name="game">brings forth the current game</param>
        /// <param name="currentPlayer">brings forth the currentPlayer</param>
        public UpgradeProperty(Game game, Player currentPlayer)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
            this.game = game;
            this.currentPlayer = currentPlayer;
            //fill the list with the list of spots that the currentPlayer has
            playerSpots = game.GetPlayersPropertyList(currentPlayer);

            lblMoneyTotal.Text = currentPlayer.Money.ToString();
            lblPlayerName.Text = currentPlayer.PlayerName;

            List<Spot> spotsEligible = new List<Spot>();

            List<Color> colorsEligible = game.CheckIfEligibleForHouse(playerSpots);

            List<Spot> mortgage = new List<Spot>();

            foreach (Spot s in playerSpots)
            {
                if (s.IsMortgaged == true)
                {
                    mortgage.Add(s);
                }
            }

            if (colorsEligible.Count > 0 || mortgage.Count > 0)
            {
                //Get every spot that matches a color in the list
                foreach (Spot s in playerSpots)
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

                //add them to the listView
                FillListView(listViewProperties, spotsEligible);

                //fill public slot
                this.eligible = spotsEligible;
            }
            else
            {
                MessageBox.Show("No Properties Eligible For Upgrade.");
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

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender">button that send the click event</param>
        /// <param name="e">event args</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            game.Board[selectedSpot.SpotId].NumberOfHouses++;
            this.currentPlayer.Money = this.currentPlayer.Money - this.selectedSpot.HouseCost;
            this.lblMoneyTotal.Text = game.Players[currentPlayer.PlayerId].Money.ToString();

            this.reset();
        }

        private void btnAddHotel_Click(object sender, EventArgs e)
        {
            game.Board[selectedSpot.SpotId].HasHotel = true;
            this.currentPlayer.Money = this.currentPlayer.Money - this.selectedSpot.HotelCost;
            this.lblMoneyTotal.Text = game.Players[currentPlayer.PlayerId].Money.ToString();

            this.reset();
        }

        private void btnAddHouseToAll_Click(object sender, EventArgs e)
        {
            if (sameType.Count == 2)
            {
                game.Board[sameType[0].SpotId].NumberOfHouses++;
                game.Board[sameType[1].SpotId].NumberOfHouses++;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HouseCost*2);
            }
            else
            {
                game.Board[sameType[0].SpotId].NumberOfHouses++;
                game.Board[sameType[1].SpotId].NumberOfHouses++;
                game.Board[sameType[2].SpotId].NumberOfHouses++;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HouseCost*3);
                
            }

            this.lblMoneyTotal.Text = game.Players[currentPlayer.PlayerId].Money.ToString();
            this.reset();
        }

        private void btnAddHotelToAll_Click(object sender, EventArgs e)
        {
            if (sameType.Count == 2)
            {
                game.Board[sameType[0].SpotId].HasHotel = true;
                game.Board[sameType[1].SpotId].HasHotel = true;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HotelCost * 2);
            }
            else
            {
                game.Board[sameType[0].SpotId].HasHotel = true;
                game.Board[sameType[1].SpotId].HasHotel = true;
                game.Board[sameType[2].SpotId].HasHotel = true;
                this.currentPlayer.Money = this.currentPlayer.Money - (this.selectedSpot.HotelCost * 3);
            }

            this.lblMoneyTotal.Text = game.Players[currentPlayer.PlayerId].Money.ToString();
            this.reset();
        }

        public void reset()
        {
            lblPropertyName.ForeColor = Color.Black;
            lblPropertyName.Text = "Choose another property";
            btnAddHotel.Enabled = false;
            btnAddHouse.Enabled = false;
            btnAddHouseToAll.Enabled = false;
            btnAddHotelToAll.Enabled = false;
            btnUnmortgage.Enabled = false;
        }

        private void btnUnmortgage_Click(object sender, EventArgs e)
        {
            this.game.Board[selectedSpot.SpotId].IsMortgaged = false;
            this.game.Players[currentPlayer.PlayerId].Money = this.game.Players[currentPlayer.PlayerId].Money - (int)(this.selectedSpot.Mortgage * 1.1);
            this.lblMoneyTotal.Text = game.Players[currentPlayer.PlayerId].Money.ToString();

            this.reset();           
        }

        private void listViewProperties_Click(object sender, EventArgs e)
        {
            //Get the item selected in the list box right now
            int index = this.listViewProperties.SelectedIndices[0];

            //Get the name stored in the listview
            string name = this.listViewProperties.Items[index].SubItems[0].Text;

            //Search for the spot
            foreach (Spot s in playerSpots)
            {
                if (s.SpotName == name)
                {
                    this.selectedSpot = s;
                }
            }

            //List that holds the spots of the same type
            this.sameType.Clear();

            //Get a list of spots that share the same color
            foreach (Spot s in playerSpots)
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
            txtMessage.Text = String.Empty;

            //Activate buttons as they are possible
            if (this.sameType.Count == 1)
            {
                if (!selectedSpot.IsMortgaged)
                {
                    if (!sameType[0].IsMortgaged)
                    {
                        if (selectedSpot.NumberOfHouses < sameType[0].NumberOfHouses)
                        {
                            if (selectedSpot.HouseCost <= currentPlayer.Money)
                            {
                                btnAddHouse.Enabled = true;
                            }
                            else
                            {
                                txtMessage.Text = txtMessage.Text + " Not enough money to put a house on this property.";
                            }
                        }
                        else if (selectedSpot.NumberOfHouses == sameType[0].NumberOfHouses)
                        {
                            if (selectedSpot.NumberOfHouses == 4 && sameType[0].NumberOfHouses == 4)
                            {
                                if (selectedSpot.HasHotel)
                                {

                                }
                                else if (sameType[0].HasHotel)
                                {
                                    if (currentPlayer.Money >= selectedSpot.HotelCost)
                                    {
                                        btnAddHotel.Enabled = true;
                                    }
                                    else
                                    {
                                        txtMessage.Text = txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }
                                }
                                else
                                {
                                    if (currentPlayer.Money >= selectedSpot.HotelCost)
                                    {
                                        btnAddHotel.Enabled = true;
                                    }
                                    else
                                    {
                                        txtMessage.Text = txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }
                                    if (currentPlayer.Money >= (selectedSpot.HotelCost * 2))
                                    {
                                        btnAddHotelToAll.Enabled = true;
                                    }
                                    else
                                    {
                                        txtMessage.Text = txtMessage.Text + " Not enough money to put a hotel on all properties of this color.";
                                    }
                                }
                            }
                            else
                            {
                                if (selectedSpot.HouseCost <= currentPlayer.Money)
                                {
                                    btnAddHouse.Enabled = true;
                                }
                                else
                                {
                                    txtMessage.Text = txtMessage.Text + " Not enough money to put a house on this property.";
                                }
                                if (currentPlayer.Money >= (selectedSpot.HouseCost * 2))
                                {
                                    btnAddHouseToAll.Enabled = true;
                                }
                                else
                                {
                                    txtMessage.Text = txtMessage.Text + " Not enough money to put a house on all properties of this color.";
                                }
                            }
                        }
                        else
                        {
                            txtMessage.Text = txtMessage.Text + " This property has either more houses or a hotel than the other properties of the same color.";
                        }
                    }
                }
                else
                {
                    if (currentPlayer.Money >= (selectedSpot.Mortgage * 1.1))
                    {
                        btnUnmortgage.Enabled = true;
                    }
                    else
                    {
                        txtMessage.Text = txtMessage.Text + "You do not have enough money to un-mortgage this property";
                    }
                }
            }
            else if (this.sameType.Count == 2)
            {
                if (!selectedSpot.IsMortgaged)
                {
                    if (!sameType[0].IsMortgaged && !sameType[1].IsMortgaged)
                    {
                        if ((selectedSpot.NumberOfHouses < sameType[0].NumberOfHouses) || (selectedSpot.NumberOfHouses < sameType[1].NumberOfHouses))
                        {
                            if (currentPlayer.Money >= selectedSpot.HouseCost)
                            {
                                btnAddHouse.Enabled = true;
                            }
                            else
                            {
                                txtMessage.Text = txtMessage.Text + " Not enough money to put a house on this property.";
                            }
                        }
                        else if ((selectedSpot.NumberOfHouses == sameType[0].NumberOfHouses) && (selectedSpot.NumberOfHouses == sameType[1].NumberOfHouses))
                        {
                            if (selectedSpot.NumberOfHouses == 4 && sameType[0].NumberOfHouses == 4 && sameType[1].NumberOfHouses == 4)
                            {
                                if (selectedSpot.HasHotel)
                                {

                                }
                                else if (sameType[0].HasHotel || sameType[1].HasHotel)
                                {
                                    if (currentPlayer.Money >= selectedSpot.HotelCost)
                                    {
                                        btnAddHotel.Enabled = true;
                                    }
                                    else
                                    {
                                        txtMessage.Text = txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }
                                }
                                else
                                {
                                    if (currentPlayer.Money >= selectedSpot.HotelCost)
                                    {
                                        btnAddHotel.Enabled = true;
                                    }
                                    else
                                    {
                                        txtMessage.Text = txtMessage.Text + " Not enough money to put a hotel on this property.";
                                    }
                                    if (currentPlayer.Money >= (selectedSpot.HotelCost * 3))
                                    {
                                        btnAddHotelToAll.Enabled = true;
                                        txtMessage.Text = txtMessage.Text + " Not enough money to put a hotel on all properties of this color.";
                                    }
                                }
                            }
                            else
                            {
                                if (currentPlayer.Money >= selectedSpot.HouseCost)
                                {
                                    btnAddHouse.Enabled = true;
                                }
                                else
                                {
                                    txtMessage.Text = txtMessage.Text + " Not enough money to put a house on this property.";
                                }
                                if (currentPlayer.Money >= (selectedSpot.HouseCost * 3))
                                {
                                    btnAddHouseToAll.Enabled = true;
                                }
                                else
                                {
                                    txtMessage.Text = txtMessage.Text + " Not enough money to put a house on all of the properties of this color.";
                                }
                            }
                        }
                        else
                        {
                            txtMessage.Text = "This property has either more houses or a hotel than the other properties of the same color.";
                        }
                    }
                    else
                    {
                        txtMessage.Text = "Other properties of this color are mortgaged - nothing can be upgraded on any of these properties.";
                    }
                }
                else
                {
                    if (currentPlayer.Money >= (int)(selectedSpot.Mortgage * 1.1))
                    {
                        btnUnmortgage.Enabled = true;
                    }
                    else
                    {
                        txtMessage.Text = txtMessage.Text + "You do not have enough money to un-mortgage this property";
                    }
                }
            }
            else if (selectedSpot.IsMortgaged)
            {
                if (currentPlayer.Money >= (int)(selectedSpot.Mortgage * 1.1))
                {
                    btnUnmortgage.Enabled = true;
                }
                else
                {
                    txtMessage.Text = "You do not have enough money to un-mortgage this property";
                }

            }

            //Add the selected spot to the list of spots for that color
            this.sameType.Add(selectedSpot);

            //Update text
            this.lblPropertyName.Text = selectedSpot.SpotName;
            this.lblPropertyName.ForeColor = selectedSpot.Color;

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

            //add them to the listView
            //FillListView(listViewProperties, eligible);
        }
    }
}

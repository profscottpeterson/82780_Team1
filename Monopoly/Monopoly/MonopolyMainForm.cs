//-----------------------------------------------------------------------
// <copyright file="MonopolyMainForm.cs" company="null">
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
    using Monopoly.Properties;

    /// <summary>
    /// An enum for dictating a spots type
    /// </summary>
    public enum SpotType
    {
        /// <summary>
        /// Spot is a property that is not a railroad or utility
        /// </summary>
        Property,

        /// <summary>
        /// Spot is a Chance spot
        /// </summary>
        Chance,

        /// <summary>
        /// Spot is a Community Chest spot
        /// </summary>
        CommunityChest,

        /// <summary>
        /// Spot is Go
        /// </summary>
        Go,

        /// <summary>
        /// Spot is Jail
        /// </summary>
        Jail,

        /// <summary>
        /// Spot is "Go to Jail"
        /// </summary>
        GoToJail,

        /// <summary>
        /// Spot is Luxury or Income Tax spot
        /// </summary>
        Tax,

        /// <summary>
        /// Spot is Electric Company or Water Works property
        /// </summary>
        Utility,

        /// <summary>
        /// Spot is a railroad
        /// </summary>
        Railroad,

        /// <summary>
        /// Spot is free parking spot
        /// </summary>
        FreeParking
    }

    /// <summary>
    /// An enum for dictating a cards type
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// Card is from Community Chest pile
        /// </summary>
        CommunityChest,

        /// <summary>
        /// Card is from Chance pile
        /// </summary>
        Chance
    }

    /// <summary>
    /// The MonopolyMainForm class.
    /// </summary>
    public partial class MonopolyMainForm : Form
    {  
        /// <summary>
        /// The game
        /// </summary>
        private Game game;

        /// <summary>
        /// The current player
        /// </summary>
        private Player currentPlayer;

        /// <summary>
        /// The checked player
        /// </summary>
        private Player checkedPlayer = null;

        /// <summary>
        /// The current player
        /// </summary>
        private List<PictureBox> spotPicture = new List<PictureBox>();

        /// <summary>
        /// The array of radio buttons for the player options
        /// </summary>
        private RadioButton[] radioButtons;

        /// <summary>
        /// The list of player pictureboxes
        /// </summary>
        private List<PictureBox> playerBoxes;

        /// <summary>
        /// How many doubles have been rolled in a turn
        /// </summary>
        private int doubleCounter = 0;

        /// <summary>
        /// Cheat code to give player money: Shift, M, O, N (in that order, separately)
        /// </summary>
        private List<Keys> cheatCode = new List<Keys>() { Keys.ShiftKey, Keys.M, Keys.O, Keys.N };

        /// <summary>
        /// Sequence the user has entered.
        /// </summary>
        private List<Keys> cheatCodeKeysPressed = new List<Keys>();

        /// <summary>
        /// Initializes a new instance of the MonopolyMainForm class.
        /// </summary>
        public MonopolyMainForm()
        {
            this.KeyPreview = true; // enables key combinations
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
        }
        
        /// <summary>
        /// Starts a new game and adds a click event to the picture boxes
        /// </summary>
        /// <param name="sender">The main form</param>
        /// <param name="e">The load event</param>
        private void MonopolyMainForm_Load(object sender, EventArgs e)
        {
            // Call StartGame method and get dialog result from GameOptions form
            DialogResult result = this.StartGame();

            // If start was pressed on GameOptions form,
            // dynamically add picture boxes and their click events
            // (Should only be done once and on form load)
            if (result == DialogResult.OK)
            {
                // Sets the forms height to 1000 pixels
                this.Height = 1000;
                this.CenterToScreen();

                // Finds each spot on the board and adds them to a list
                List<PictureBox> spotPictures = new List<PictureBox>();
                for (int i = 1; i <= 40; i++)
                {
                    spotPictures.Add((PictureBox)Controls.Find("pictureBox" + i, true)[0]);

                    // Sets a tag for the image 
                    spotPictures[i - 1].Tag = i - 1;
                }

                // A foreach loop that runs through each picture box that is a spot
                foreach (PictureBox p in spotPictures)
                {
                    // Set the picture box of the spot
                    this.game.Board[(int)p.Tag].SpotBox = p;

                    // Assigns a click event to the picture box
                    p.Click += delegate { this.PropertyClickEvent(this.game.Board[(int)p.Tag]); };
                    p.MouseHover += delegate { this.PropertyHoverEvent(this.game.Board[(int) p.Tag]); };
                    p.MouseLeave += delegate { this.PropertyHoverExitEvent(this.game.Board[(int) p.Tag]); };
                }

                this.spotPicture = spotPictures;

                foreach (Spot s in game.Board)
                {
                    s.IsAvailable = true;
                    s.IsMortgaged = false;
                    s.NumberOfHouses = 0;
                    s.HasHotel = false;
                    s.Owner = null;
                }

                this.flpCurrentPlayerProps.Controls.Clear();
                this.flpOtherPlayerHand.Controls.Clear();
            }
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <returns>The dialog result from the Game options form</returns>
        private DialogResult StartGame()
        {
            // Instantiate game
            this.game = new Game(this.ChanceImages, this.CommunityChestImages);

            // Options to start game, player count notably
            GameOptions options = new GameOptions(this.game);
            options.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = options.ShowDialog();

            // User choose quit button
            if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }

            // User choose start button
            if (result == DialogResult.OK)
            {
                this.CenterToScreen();

                // Sets the list of players to the list of players passed from the game options form
                this.game.Players = options.TempPlayers;
                this.currentPlayer = this.game.Players[0];

                // Sets the players picture box to their picture box on the form
                playerBoxes = new List<PictureBox>();
                for (int i = 0; i < this.game.Players.Count; i++)
                {
                    playerBoxes.Add((PictureBox)Controls.Find("picPlayer" + (i + 1), true)[0]);

                    if (this.game.Players[i].PlayerPictureBox.Image == null)
                    {
                        this.game.Players[i].PlayerPictureBox = playerBoxes[i];
                    }
                    else
                    {
                        playerBoxes[i].BackColor = Color.Empty;
                        playerBoxes[i].Image = this.game.Players[i].PlayerPictureBox.Image;
                    }
                }

                // Show a number of player pawns that corresponds to the number of players
                if (this.game.Players.Count == 2)
                {
                    this.picPlayer1.Visible = true;
                    this.picPlayer2.Visible = true;
                    this.picPlayer3.Visible = false;
                    this.picPlayer4.Visible = false;
                }
                else if (this.game.Players.Count == 3)
                {
                    this.picPlayer1.Visible = true;
                    this.picPlayer2.Visible = true;
                    this.picPlayer3.Visible = true;
                    this.picPlayer4.Visible = false;
                }
                else if (this.game.Players.Count == 4)
                {
                    this.picPlayer1.Visible = true;
                    this.picPlayer2.Visible = true;
                    this.picPlayer3.Visible = true;
                    this.picPlayer4.Visible = true;
                }

                // Shows the players the current players image or color as well as the current player
                this.SetCurrentPlayerImage(this.currentPlayer);
                this.lblOtherPlayersHand.Text = string.Empty;
                this.lblOtherPlayerBalance.Text = string.Empty;
                this.SetUpPlayerHandOptions();

                if (this.currentPlayer.PlayerName.Length > 18)
                {
                    this.DoublesLabel.Text = "It is " + this.currentPlayer.PlayerName.Substring(0, 18) + "...'s Turn";
                    this.lblPlayerTurn.Text = this.currentPlayer.PlayerName.Substring(0, 14) + "..." + "'s Turn";
                }
                else
                {
                    this.DoublesLabel.Text = "It is " + this.currentPlayer.PlayerName + "'s Turn";
                    this.lblPlayerTurn.Text = this.currentPlayer.PlayerName + "'s Turn";
                }

                this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");
                this.lblGetOutOfJailLabel.Text = "You have " + this.currentPlayer.GetOutOfJailFreeCards.Count + " get out of jail free cards.";
            }

            this.flpCurrentPlayerProps.Controls.Clear();
            this.flpOtherPlayerHand.Controls.Clear();

            return result;
        }

        /// <summary>
        /// Shows a form containing a property's information when that property is clicked on
        /// </summary>
        /// <param name="spot">Property clicked on</param>
        private void PropertyClickEvent(Spot spot)
        {
            // If the spot is a buy-able property then call the MonPopUp form
            if (spot.Type == SpotType.Property)
            {
                MonPopUp popUp = new MonPopUp(spot);
                popUp.StartPosition = FormStartPosition.CenterParent;
                popUp.ShowDialog();
            }

            // If the spot type is a railroad or a utility, call the NonPropPopUp form
            if (spot.Type == SpotType.Railroad || spot.Type == SpotType.Utility)
            {
                NonPropPopUp popUp = new NonPropPopUp(spot, this.game);
                popUp.StartPosition = FormStartPosition.CenterParent;
                popUp.ShowDialog();
            }
        }

        /// <summary>
        /// The click event for rolling the two dice on the form
        /// </summary>
        /// <param name="spot">The desired spot</param>
        private void PropertyHoverEvent(Spot spot)
        {
            // Remove previous label
            Control[] c = this.Controls.Find("remove", true);

            if (c.Length > 0)
            {
                this.Controls.Remove(this.Controls.Find("remove", true)[0]);
            }

            // Create a new label and place it near the spot that is hovered over
            Label l = new Label();
            Point p = spot.SpotBox.Location;
            p.Y += 20;
            l.AutoSize = true;
            
            // Set the name to remove to find it later
            l.Name = "remove";
            l.Text = spot.SpotName + "\n";

            // If it is a buy-able spot, add click to see more to the label
            if (spot.Type == SpotType.Property || spot.Type == SpotType.Railroad || spot.Type == SpotType.Utility)
            {
                l.Text = l.Text + "(Click to see more)";
            }

            l.ForeColor = Color.Black;
            l.BackColor = Color.White;
            l.Location = p;

            // Add the label
            this.Controls.Add(l);
            l.BringToFront();
        }

        /// <summary>
        /// The click event for rolling the two dice on the form
        /// </summary>
        /// <param name="spot">The passed spot</param>
        private void PropertyHoverExitEvent(Spot spot)
        {
            // Remove the label from the form
            Control[] c = this.Controls.Find("remove", true);
            if (c.Length > 0)
            {
                this.Controls.Remove(this.Controls.Find("remove", true)[0]);
            }
        }

        /// <summary>
        /// The click event for rolling the two dice on the form
        /// </summary>
        /// <param name="sender">The Roll button</param>
        /// <param name="e">The click event</param>
        private void BtnRoll_Click(object sender, EventArgs e)
        {
            // Values for the two dice
            int die1 = 0;
            int die2 = 0;

            btnJailFreeCard.Enabled = false;
            btnJailPay.Enabled = false;

            // Method for the animation of the dice
            this.RollingDice(out die1, out die2);

            if (this.currentPlayer.InJail == false)
            {
                int totalMove = 0;

                totalMove = die1 + die2;

                if (die1 == die2 && this.currentPlayer.IsActive)
                {
                    this.doubleCounter++;
                    if (this.doubleCounter >= 3)
                    {
                        this.DoublesLabel.Text = "Sorry. That was your third doubles in a row. Go to Jail.";
                        this.currentPlayer.SendToJail(this.game.GetSpotByName("Jail"));
                    }
                    else
                    {
                        this.DoublesLabel.Text = "You rolled doubles and get to roll again.";
                        this.BtnNextTurn.Enabled = false;
                        this.btnRoll.Enabled = true;
                        this.btnRoll.Focus();

                        // Find player's new location and set current location property of player
                        this.game.MovePlayerLocation(this.currentPlayer, totalMove);

                        // Move pawn picture
                        this.FindNewPawnLocations(this.currentPlayer.CurrentLocation.SpotId, this.currentPlayer);

                        // So balance is updated when Go is passed
                        this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");

                        this.game.RollChecks(this.currentPlayer);
                    }
                }
                else
                {
                    this.DoublesLabel.Text = string.Empty;
                    this.BtnNextTurn.Enabled = true;
                    this.BtnNextTurn.Focus();
                    this.btnRoll.Enabled = false;

                    // Find player's new location and set current location property of player
                    this.game.MovePlayerLocation(this.currentPlayer, totalMove);

                    // Move pawn picture
                    this.FindNewPawnLocations(this.currentPlayer.CurrentLocation.SpotId, this.currentPlayer);

                    // So balance is updated when Go is passed
                    this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");

                    this.game.RollChecks(this.currentPlayer);
                }

                // If player was sent to jail
                if (this.currentPlayer.InJail)
                {
                    if (this.doubleCounter < 3)
                    {
                        this.DoublesLabel.Text = "You were sent to Jail. End of turn.";
                    }
                    
                    this.BtnNextTurn.Enabled = true;
                    this.btnRoll.Enabled = false;
                    this.BtnNextTurn.Focus();
                }
            }
            else
            {
                // Take the player out of jail if they rolled doubles
                if (die1 == die2)
                {
                    this.DoublesLabel.Text = "Rolling doubles enabled you to get out of Jail.";
                    this.currentPlayer.InJail = false;
                    this.currentPlayer.TurnsInJail = 0;
                    int total = die1 + die2;
                    this.game.MovePlayerLocation(this.currentPlayer, total);
                    this.FindNewPawnLocations(this.currentPlayer.CurrentLocation.SpotId, this.currentPlayer);

                    this.game.RollChecks(this.currentPlayer);
                }
                else
                {
                    this.DoublesLabel.Text = "Sorry. This roll will not get you out of Jail.";
                    this.btnJailPay.Enabled = true;

                    this.currentPlayer.TurnsInJail++;

                    // Allow the player to leave jail
                    if (this.currentPlayer.TurnsInJail == 3)
                    {
                        this.DoublesLabel.Text += " - Paid $50 to get out.";
                        this.currentPlayer.Money -= 50;
                        this.game.CheckIfPlayerHasEnoughMoney(this.currentPlayer);
                        this.currentPlayer.InJail = false;
                        this.currentPlayer.TurnsInJail = 0;
                        int total = die1 + die2;
                        this.game.MovePlayerLocation(this.currentPlayer, total);
                        this.game.RollChecks(this.currentPlayer);
                    }
                }

                this.btnRoll.Enabled = false;
                this.BtnNextTurn.Enabled = true;
                this.BtnNextTurn.Focus();
            }

            // Move pawn picture
            this.FindNewPawnLocations(this.currentPlayer.CurrentLocation.SpotId, this.currentPlayer);

            this.btnJailFreeCard.Enabled = false;
            this.btnJailPay.Enabled = false;
            this.flpOtherPlayerHand.Controls.Clear();
            if (currentPlayer.IsActive == false)
            {
                this.playerBoxes[currentPlayer.PlayerId].Visible = false;
                this.BtnNextTurn_Click(this.currentPlayer, EventArgs.Empty); 
            }
            else
            {
                this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);
            }


            // Restart the game
            if (this.game.RestartGame)
            {
                this.RestartGame();
            }
        }

        /// <summary>
        /// Shows the dice rolling
        /// </summary>
        /// <param name="die1">The value of the first die</param>
        /// <param name="die2">The value of the second die</param>
        private void RollingDice(out int die1, out int die2)
        {
            this.TurnFormButtonsOffOrOn(false);
            
            Random rand = new Random();

            die1 = 0;
            die2 = 0;

            // Disable roll button so it cannot be clicked while dice are rolling
            this.btnRoll.Enabled = false;

            // Have dice roll 5 times
            for (int i = 0; i < 5; i++)
            {
                // Get two random numbers for dice values
                die1 = rand.Next(1, 7);
                die2 = rand.Next(1, 7);

                // Have dice images match random numbers that were generated
                pbxDiceLeft.Image = this.dicePictures.Images[die1 - 1];
                pbxDiceRight.Image = this.dicePictures.Images[die2 - 1];

                // Pause for 200 milliseconds
                System.Threading.Thread.Sleep(150);
                Application.DoEvents();
            }

            if (this.currentPlayer.IsAi)
            {
                System.Threading.Thread.Sleep(1000);
                Application.DoEvents();
            }

            // Re-enable the roll button when dice are done rolling
            this.btnRoll.Enabled = true;
            this.TurnFormButtonsOffOrOn(true);
        }

        /// <summary>
        /// Finds the pawn's new location
        /// </summary>
        /// <param name="newLocation">The new spot on the board the pawn is moving to</param>
        /// <param name="player">The owner of the pawn</param>
        private void FindNewPawnLocations(int newLocation, Player player)
        {
            if (player != null)
            {
                // Bottom Row
                if (newLocation > 0 && newLocation < 10)
                {
                    Point p = new Point();

                    p.Y = 800;
                    p.X = 765 - (newLocation * 70);

                    if (player.PlayerId == 0)
                    {
                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.X = p.X + 45;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.Y = p.Y + 45;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = p.X + 45;
                        p.Y = p.Y + 45;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation > 10 && newLocation < 20)
                {
                    // Left column
                    Point p = new Point();

                    p.Y = 765 - ((newLocation - 10) * 70);
                    p.X = 75;

                    if (player.PlayerId == 0)
                    {
                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.Y = p.Y + 45;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.X = p.X - 45;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = p.X - 45;
                        p.Y = p.Y + 45;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation > 20 && newLocation < 30)
                {
                    // Top row
                    Point p = new Point();

                    p.Y = 75;
                    p.X = 135 + ((newLocation - 21) * 70);

                    if (player.PlayerId == 0)
                    {
                        p.X = p.X + 45;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.Y = p.Y - 45;
                        p.X = p.X + 45;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.Y = p.Y - 45;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation > 30 && newLocation < 40)
                {
                    // Right Column
                    Point p = new Point();

                    p.Y = 135 + ((newLocation - 31) * 70);
                    p.X = 800;

                    if (player.PlayerId == 0)
                    {
                        p.Y = p.Y + 45;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.Y = p.Y + 45;
                        p.X = p.X + 45;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = p.X + 45;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation == 0)
                {
                    // Land on go
                    Point p = new Point();

                    if (player.PlayerId == 0)
                    {
                        p.X = 790;
                        p.Y = 790;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.X = 840;
                        p.Y = 790;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.X = 790;
                        p.Y = 840;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = 840;
                        p.Y = 840;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation == 10 && player.InJail == false)
                {
                    // Visiting Jail
                    Point p = new Point();

                    if (player.PlayerId == 0)
                    {
                        p.X = 28;
                        p.Y = 774;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.X = 28;
                        p.Y = 814;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.X = 60;
                        p.Y = 846;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = 99;
                        p.Y = 846;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation == 10 && player.InJail)
                {
                    // If they are on the jail space but are in jail this will put them in jail
                    Point p = new Point();

                    if (player.PlayerId == 0)
                    {
                        p.X = 72;
                        p.Y = 771;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.X = 100;
                        p.Y = 771;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.X = 72;
                        p.Y = 802;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = 100;
                        p.Y = 802;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation == 20)
                {
                    // Free Parking
                    Point p = new Point();

                    if (player.PlayerId == 0)
                    {
                        p.X = 45;
                        p.Y = 45;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.X = 90;
                        p.Y = 45;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.X = 45;
                        p.Y = 90;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = 90;
                        p.Y = 90;

                        this.picPlayer4.Location = p;
                    }
                }
                else if (newLocation == 30)
                {
                    // Go to Jail
                    this.currentPlayer.SendToJail(this.game.GetSpotByName("Jail"));

                    Point p = new Point();

                    if (player.PlayerId == 0)
                    {
                        p.X = 72;
                        p.Y = 771;

                        this.picPlayer1.Location = p;
                    }
                    else if (player.PlayerId == 1)
                    {
                        p.X = 100;
                        p.Y = 771;

                        this.picPlayer2.Location = p;
                    }
                    else if (player.PlayerId == 2)
                    {
                        p.X = 72;
                        p.Y = 802;

                        this.picPlayer3.Location = p;
                    }
                    else if (player.PlayerId == 3)
                    {
                        p.X = 100;
                        p.Y = 802;

                        this.picPlayer4.Location = p;
                    }
                }
            }
        }

        /// <summary>
        /// The method used for setting up the next player's information on the form
        /// </summary>
        /// <param name="player">The current player</param>
        /// <param name="panelToUse">The panel to use</param>
        private void SetNextPlayer(Player player, FlowLayoutPanel panelToUse, bool condition)
        {
            // Sets the form labels to the next player values
            this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");
            this.lblGetOutOfJailLabel.Text = "You have " + player.GetOutOfJailFreeCards.Count + " get out of jail free cards.";
            this.lblOtherPlayersHand.Text = string.Empty;
            this.lblOtherPlayerBalance.Text = string.Empty;
            panelToUse.Controls.Clear();

            // Gets the list of the players spots
            List<Spot> currentPlayerSpots = new List<Spot>();
            currentPlayerSpots = player.GetPlayersPropertyList(this.game.Board);

            // Arrays to be used to add information to the players hand
            PictureBox[] pictureBoxes = new PictureBox[currentPlayerSpots.Count];
            Panel[] playerPropertyPanels = new Panel[currentPlayerSpots.Count];
            Label[] playerPropertyLabels = new Label[currentPlayerSpots.Count];

            // If the player owns properties
            if (pictureBoxes.Length > 0)
            {
                for (int r = 0; r < pictureBoxes.Length; r++)
                {
                    // Create new controls
                    pictureBoxes[r] = new PictureBox();
                    playerPropertyPanels[r] = new Panel();
                    playerPropertyLabels[r] = new Label();
                }

                foreach (PictureBox pb in pictureBoxes)
                {
                    // Sets each picture box point and size
                    Point point = new Point(5, 30);
                    pb.Width = 70;
                    pb.Height = 115;
                    pb.Location = point;
                }

                foreach (Panel pl in playerPropertyPanels)
                {
                    // Sets the size of each panel
                    pl.Width = 80;
                    pl.Height = 150;
                    pl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }

                foreach (Label lbl in playerPropertyLabels)
                {
                    // Sets the size of each label
                    lbl.MaximumSize = new Size(80, 40);
                    lbl.AutoSize = true;
                    lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }

                // Temporary variables for creating the player properties in their hand
                Spot s = new Spot();
                Image tempImage = new Bitmap(70, 115);
                PictureBox p = new PictureBox();
                Panel panel = new Panel();
                Label label = new Label();

                for (int g = 0; g < currentPlayerSpots.Count; g++)
                {
                    p = pictureBoxes[g];
                    s = currentPlayerSpots[g];
                    panel = playerPropertyPanels[g];
                    label = playerPropertyLabels[g];

                    // Checks for the color of the property and assigns it an image
                    if (s.Color == Color.Black)
                    {
                        if (s.Type == SpotType.Utility)
                        {
                            if (s.SpotName == "Electric Company")
                            {
                                tempImage = this.usableSpotPictures.Images[0];
                                p.Image = tempImage;   
                            }
                            else
                            {
                                tempImage = this.usableSpotPictures.Images[2];
                                p.Image = tempImage;
                            }
                        }
                        else
                        {
                            tempImage = this.usableSpotPictures.Images[1];
                            p.Image = tempImage;   
                        }
                    }
                    else if (s.Color == Color.DarkBlue)
                    {
                        tempImage = this.usableSpotPictures.Images[3];
                        p.Image = tempImage;   
                    }
                    else if (s.Color == Color.Green)
                    {
                        tempImage = this.usableSpotPictures.Images[4];
                        p.Image = tempImage;   
                    }
                    else if (s.Color == Color.LightBlue)
                    {
                        tempImage = this.usableSpotPictures.Images[5];
                        p.Image = tempImage;   
                    }
                    else if (s.Color == Color.Purple)
                    {
                        tempImage = this.usableSpotPictures.Images[6];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.DarkOrange)
                    {
                        tempImage = this.usableSpotPictures.Images[7];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.MediumVioletRed)
                    {
                        tempImage = this.usableSpotPictures.Images[8];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.Red)
                    {
                        tempImage = this.usableSpotPictures.Images[9];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.Yellow)
                    {
                        tempImage = this.usableSpotPictures.Images[10];
                        p.Image = tempImage;
                    }

                    // Set the tags and text of the temporary controls
                    p.Tag = g.ToString();
                    panel.Tag = g.ToString();
                    label.Tag = g.ToString();
                    label.Text = s.SpotName;
                }
            }

            // Adds click, mouse hover, and mouse leave events to the controls in a players hand
            foreach (PictureBox pbx in pictureBoxes)
            {
                pbx.Click += delegate { this.PropertyClickEvent(currentPlayerSpots[int.Parse(pbx.Tag.ToString())]); };
                pbx.MouseHover += delegate
                {
                    this.PropertyHoverEvent(currentPlayerSpots[int.Parse(pbx.Tag.ToString())]);
                };
                pbx.MouseLeave += delegate
                {
                    this.PropertyHoverExitEvent(currentPlayerSpots[int.Parse(pbx.Tag.ToString())]);
                };
            }

            // Adds the panels to the panel on the form to display the players hand
            foreach (Panel panel in playerPropertyPanels)
            {
                panel.Controls.Add(playerPropertyLabels[int.Parse(panel.Tag.ToString())]);
                panel.Controls.Add(pictureBoxes[int.Parse(panel.Tag.ToString())]);
                panelToUse.Controls.Add(panel);
            }

            // Checks whether to update the form for the current player or a different player
            if (condition == true)
            {
                this.SetCurrentPlayerImage(player);
                if (player.PlayerName.Length > 18)
                {
                    this.lblPlayerTurn.Text = player.PlayerName.Substring(0, 14) + "..." + "'s Turn";
                }
                else
                {
                    this.lblPlayerTurn.Text = player.PlayerName + "'s Turn";
                }

                this.lblCurrentBalance.Text = "Current Balance: " + '\n' + player.Money.ToString("c0");
            }
            else
            {
                // Sets up the other player's hand and labels
                this.SetUpPlayerHandOptions();

                string stringForUpdating = string.Empty;

                if (player.PlayerName.Length > 15)
                {
                    stringForUpdating = player.PlayerName.Substring(0, 13) + "...";
                    this.lblOtherPlayersHand.Text = stringForUpdating + "'s hand";
                }
                else
                {
                    stringForUpdating = player.PlayerName;
                    this.lblOtherPlayersHand.Text = player.PlayerName + "'s hand";
                }

                this.lblOtherPlayerBalance.Text = stringForUpdating + "'s balance: " + player.Money.ToString("c0");

                if (this.lblOtherPlayersHand.Text == this.currentPlayer.PlayerName)
                {
                    this.lblOtherPlayersHand.Text = string.Empty;
                    this.lblOtherPlayerBalance.Text = string.Empty;
                }
            }

            this.SetUpHotelsAndHouses();
        }

        /// <summary>
        /// Sets up options for seeing other players' hands
        /// </summary>
        private void SetUpHotelsAndHouses()
        {
            while (this.Controls["Upgrade"] != null)
            {
                this.Controls.Remove((PictureBox)Controls.Find("Upgrade", true)[0]);
                this.Controls.Remove((PictureBox)Controls.Find("Border", true)[0]);
            }

            foreach (Spot s in this.game.Board)
            {
                if (s.Type == SpotType.Property)
                {
                    if (s.HasHotel == true)
                    {
                        PictureBox temp = new PictureBox();

                        foreach (PictureBox pic in this.spotPicture)
                        {
                            if (int.Parse(pic.Tag.ToString()) == s.SpotId)
                            {
                                temp = pic;
                            }
                        }

                        PictureBox border = new PictureBox();
                        border.Name = "Border";
                        border.Size = new Size(25, 25);
                        border.BackColor = Color.White;

                        PictureBox hotel = new PictureBox();
                        hotel.Name = "Upgrade";
                        hotel.Size = new Size(23, 23);

                        hotel.BackColor = Color.Firebrick;

                        Point p = temp.Location;

                        if (s.SpotId > 0 && s.SpotId < 10)
                        {
                            p.X = p.X + 22;
                        }
                        else if (s.SpotId > 10 && s.SpotId < 20)
                        {
                            p.X = p.X + 90;
                            p.Y = p.Y + 22;
                        }
                        else if (s.SpotId > 20 && s.SpotId < 30)
                        {
                            p.X = p.X + 22;
                            p.Y = p.Y + 90;
                        }
                        else if (s.SpotId > 30 && s.SpotId < 40)
                        {
                            p.Y = p.Y + 22;
                        }

                        border.Location = p;
                        p.X += 1;
                        p.Y += 1;
                        hotel.Location = p;
                        this.Controls.Add(border);
                        this.Controls.Add(hotel);
                        border.BringToFront();
                        hotel.BringToFront();
                    }
                    else
                    {
                        PictureBox temp = new PictureBox();

                        foreach (PictureBox pic in this.spotPicture)
                        {
                            if (int.Parse(pic.Tag.ToString()) == s.SpotId)
                            {
                                temp = pic;
                            }
                        }

                        for (int i = 0; i < s.NumberOfHouses; i++)
                        {
                            PictureBox border = new PictureBox();
                            border.Name = "Border";
                            border.Size = new Size(14, 14);
                            border.BackColor = Color.White;

                            PictureBox hotel = new PictureBox();
                            hotel.Name = "Upgrade";
                            hotel.Size = new Size(12, 12);

                            hotel.BackColor = Color.Green;

                            Point p = temp.Location;
                            
                            if (s.SpotId > 0 && s.SpotId < 10)
                            {
                                p.X = (p.X + (17 * i)) + (2 * i);
                            }
                            else if (s.SpotId > 10 && s.SpotId < 20)
                            {
                                p.X = p.X + 101;
                                p.Y = (p.Y + (17 * i)) + (2 * i);
                            }
                            else if (s.SpotId > 20 && s.SpotId < 30)
                            {
                                p.X = p.X + 56;
                                p.X = (p.X - (17 * i)) - (2 * i);
                                p.Y = p.Y + 101;
                            }
                            else if (s.SpotId > 30 && s.SpotId < 40)
                            {
                                p.Y = p.Y + 56;
                                p.Y = (p.Y - (17 * i)) - (2 * i);
                            }

                            border.Location = p;
                            p.X += 1;
                            p.Y += 1;
                            hotel.Location = p;
                            this.Controls.Add(border);
                            this.Controls.Add(hotel);
                            border.BringToFront();
                            hotel.BringToFront();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets up options for seeing other players' hands
        /// </summary>
        private void SetUpPlayerHandOptions()
        {       
            this.flpPlayerHandOptions.Controls.Clear();
            int activePlayerCount = this.game.Players.Count;
            bool[] playerStatus = new bool[activePlayerCount];
            
            if (activePlayerCount - 1 > 0)
            {
                this.radioButtons = new RadioButton[activePlayerCount];
                for (int x = 0; x < this.game.Players.Count; x++)
                {
                    playerStatus[x] = this.game.Players[x].IsActive;
                    this.radioButtons[x] = new RadioButton();
                    if (this.game.Players[x].IsActive == true)
                    {
                        if (this.game.Players[x].PlayerName.Length > 15)
                        {
                            this.radioButtons[x].Text = this.game.Players[x].PlayerName.Substring(0, 13) + "...";
                        }
                        else
                        {
                            this.radioButtons[x].Text = this.game.Players[x].PlayerName;
                        }

                        this.radioButtons[x].Font = new Font("Microsoft Sans Serif", 12);
                        this.radioButtons[x].Tag = this.game.Players[x].PlayerId;
                        this.radioButtons[x].AutoSize = true;
                    }
                }

                for (int x = 0; x < activePlayerCount; x++)
                {
                    RadioButton r = this.radioButtons[x];
                    if (playerStatus[x] == true)
                    {
                        if (r.Tag.ToString() != this.currentPlayer.PlayerId.ToString())
                        {
                            if (r.Text != string.Empty)
                            {
                                r.CheckedChanged += delegate
                                {
                                    this.SetNextPlayer(this.game.Players[int.Parse(r.Tag.ToString())], this.flpOtherPlayerHand, false);

                                    this.checkedPlayer = this.game.Players[int.Parse(r.Tag.ToString())];
                                };
                                this.flpPlayerHandOptions.Controls.Add(r);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the current player's image
        /// </summary>
        /// <param name="player">The current player</param>
        private void SetCurrentPlayerImage(Player player)
        {
            if (player.PlayerPictureBox.Image != null)
            {
                this.pbxCurrentPlayerPicture.BackColor = Color.Transparent;
                this.pbxCurrentPlayerPicture.Image = player.PlayerPictureBox.Image;
                this.pbxCurrentPlayerPicture.Update();
            }
            else
            {
                this.pbxCurrentPlayerPicture.Image = null;
                this.pbxCurrentPlayerPicture.BackColor = player.PlayerPictureBox.BackColor;
            }
        }

        /// <summary>
        /// Brings up Trade from when button is clicked
        /// </summary>
        /// <param name="sender">The Trade button</param>
        /// <param name="e">The click event</param>
        private void BtnTradeRequest_Click(object sender, EventArgs e)
        {
            Trade tradeForm = new Trade(this.currentPlayer, this.game);
            tradeForm.StartPosition = FormStartPosition.CenterParent;
            tradeForm.ShowDialog();          

            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);

            if (this.checkedPlayer != null)
            {
               // this.SetNextPlayer(this.checkedPlayer, this.flpOtherPlayerHand, false);
            }
        }

        /// <summary>
        /// Bring up Sell form when user clicks button
        /// </summary>
        /// <param name="sender">The Sell button</param>
        /// <param name="e">The click event</param>
        private void BtnSell_Click(object sender, EventArgs e)
        {
            GetMoney money = new GetMoney(this.game, this.currentPlayer);

            money.ShowDialog();
            money.Close();

            this.flpOtherPlayerHand.Controls.Clear();
            this.lblOtherPlayersHand.Text = string.Empty;
            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);
            this.SetUpPlayerHandOptions();

            // If a player forfeited
            if (money.DialogResult == DialogResult.Cancel)
            {
                this.currentPlayer = this.game.NextPlayer(this.currentPlayer);
                this.btnRoll.Enabled = true;
                this.BtnNextTurn.Enabled = false;
                this.btnRoll.Focus();
                this.doubleCounter = 0;
                this.flpCurrentPlayerProps.Controls.Clear();
                this.flpOtherPlayerHand.Controls.Clear();
                this.lblOtherPlayersHand.Text = string.Empty;
                this.flpPlayerHandOptions.Controls.Clear();
                this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);
                this.SetUpPlayerHandOptions();
            }

            if (this.game.RestartGame)
            {
                this.RestartGame();
            }
        }

        /// <summary>
        /// Bring up Upgrade Property form when button is clicked
        /// </summary>
        /// <param name="sender">The Buy House Or Hotel button</param>
        /// <param name="e">The click event</param>
        private void BtnBuyHouseOrHotel_Click(object sender, EventArgs e)
        {
            UpgradeProperty upgrade = new UpgradeProperty(this.game, this.currentPlayer);
            if (upgrade.IsDisposed == false)
            {
                upgrade.ShowDialog();
                this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];
            }

            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);
        }

        /// <summary>
        /// Set up board for the next player and set the current player to the next player
        /// </summary>
        /// <param name="sender">The Next Turn button</param>
        /// <param name="e">The click event</param>
        private void BtnNextTurn_Click(object sender, EventArgs e)
        {
            this.btnRoll.Enabled = true;
            this.BtnNextTurn.Enabled = false;
            this.btnRoll.Focus();
            this.doubleCounter = 0;
            this.DoublesLabel.Text = string.Empty;
            this.currentPlayer = this.game.NextPlayer(this.currentPlayer);
            this.flpCurrentPlayerProps.Controls.Clear();
            this.flpOtherPlayerHand.Controls.Clear();
            this.lblOtherPlayersHand.Text = string.Empty;
            this.flpPlayerHandOptions.Controls.Clear();

            this.SetUpPlayerHandOptions();

            if (this.currentPlayer.InJail)
            {
                if (this.currentPlayer.GetOutOfJailFreeCards.Count >= 1)
                {
                    this.btnJailFreeCard.Enabled = true;
                }
                else
                {
                    this.btnJailFreeCard.Enabled = false;
                }
                
                this.btnJailPay.Enabled = true;
            }
            else
            {
                this.btnJailPay.Enabled = false;
                this.btnJailFreeCard.Enabled = false;
            }

            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);

            if (this.currentPlayer.IsAi == true)
            {
                this.flpPlayerHandOptions.Enabled = false;
                while (this.btnRoll.Enabled)
                {
                    this.BtnRoll_Click(sender, e);
                }

                this.BtnBuyHouseOrHotel_Click(sender, e);
                this.BtnNextTurn_Click(sender, e);
            }
            else
            {
                this.flpPlayerHandOptions.Enabled = true;
                if (this.currentPlayer.PlayerName.Length > 20)
                {
                    this.DoublesLabel.Text = "It is " + this.currentPlayer.PlayerName.Substring(0, 18) + "...'s Turn";
                }
                else
                {
                    this.DoublesLabel.Text = "It is " + this.currentPlayer.PlayerName + "'s Turn";
                }
            }
            this.Update();
            this.Invalidate();
        }

        /// <summary>
        /// Have player pay to get out of jail when button is clicked
        /// </summary>
        /// <param name="sender">The Jail Pay button</param>
        /// <param name="e">The click event</param>
        private void BtnJailPay_Click(object sender, EventArgs e)
        {
            // take players money
            this.currentPlayer.Money -= 50;
            this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");

            // Break them out of jail
            this.currentPlayer.InJail = false;

            // set currentPlayers new location now out of jail
            this.FindNewPawnLocations(10, this.currentPlayer);

            // Check how many turns they've been in jail.
            // if they have been in jail for 3 turns then paid
            // make them roll and move
            this.btnRoll.Enabled = false;
            this.btnJailFreeCard.Enabled = false;
            this.btnJailPay.Enabled = false;
            this.BtnNextTurn.Enabled = true;
            this.currentPlayer.TurnsInJail = 0;

            this.BtnNextTurn.Focus();
        }

        /// <summary>
        /// Has player use "Get Out of Jail Free" card to get out of Jail when button is clicked
        /// </summary>
        /// <param name="sender">The Jail Free Card button</param>
        /// <param name="e">The click event</param>
        private void BtnJailFreeCard_Click(object sender, EventArgs e)
        {
            // Remove card from player, set player's in jail boolean to false, and 
            // add card back into corresponding deck
            this.game.PlayGetOutOfJailFreeCard(this.currentPlayer);

            // set currentPlayers new location now out of jail
            this.FindNewPawnLocations(10, this.currentPlayer);

            // disable and enable correct buttons
            this.btnJailFreeCard.Enabled = false;
            this.btnJailPay.Enabled = false;
            this.btnRoll.Enabled = false;
            this.BtnNextTurn.Enabled = true;
            this.currentPlayer.TurnsInJail = 0;

            this.BtnNextTurn.Focus();
        }

        /// <summary>
        /// Ends game when button is clicked
        /// </summary>
        /// <param name="sender">The Quit Game button</param>
        /// <param name="e">The click event</param>
        private void QuitGameBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Restarts a game when button is clicked
        /// </summary>
        /// <param name="sender">The Restart Game button</param>
        /// <param name="e">The click event</param>
        private void BtnRestartGame_Click(object sender, EventArgs e)
        {
            this.RestartGame();
        }

        /// <summary>
        /// Restarts a game
        /// </summary>
        private void RestartGame()
        {
            foreach (PictureBox p in playerBoxes)
            {
                p.Image = null;
                if (p.Tag.ToString() == "1")
                {
                    p.BackColor = Color.Red;
                }
                else if (p.Tag.ToString() == "2")
                {
                    p.BackColor = Color.Green;
                }
                else if (p.Tag.ToString() == "3")
                {
                    p.BackColor = Color.Blue;
                }
                else
                {
                    p.BackColor = Color.FromArgb(255, 128, 0);
                }
            }

            // Call StartGame to start a new game with game options form
            this.StartGame();

            // Enable and disable central buttons
            this.btnRoll.Enabled = true;
            this.btnRoll.Focus();
            this.BtnNextTurn.Enabled = false;
            this.btnJailPay.Enabled = false;
            this.btnJailFreeCard.Enabled = false;

            // Set up the current player's information on the form
            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps, true);

            // Loop through the list of players
            foreach (Player player in this.game.Players)
            {
                // Move their pawn picture back to Go
                this.FindNewPawnLocations(player.CurrentLocation.SpotId, player);
            }
        }

        /// <summary>
        /// button to give the player a small loan of 1000 dollars
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The eventArgs</param>
        private void BtnSmallLoan_Click(object sender, EventArgs e)
        {
            this.currentPlayer.Money += 1000;
        }

        /// <summary>
        /// The click event for the help button on the Monopoly Main Form
        /// </summary>
        /// <param name="sender">The help button</param>
        /// <param name="e">The click event</param>
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            HelpMenu hm = new HelpMenu("Board Screen");
            hm.ShowDialog();
        }

        /// <summary>
        /// Disables the form buttons while ai are playing
        /// </summary>
        private void TurnFormButtonsOffOrOn(bool condition)
        {
            
            // Turns on or off the buttons on the form
            this.btnSell.Enabled = condition;
            this.btnBuyHouseOrHotel.Enabled = condition;
            this.QuitGameBtn.Enabled = condition;
            this.BtnRestartGame.Enabled = condition;
            this.btnTradeRequest.Enabled = condition;
            this.BtnHelp.Enabled = condition;
            this.flpOtherPlayerHand.Enabled = condition;
            this.flpCurrentPlayerProps.Enabled = condition;
            foreach (PictureBox p in this.spotPicture)
            {
                p.Enabled = condition;
            }
        }

        /// <summary>
        /// Key combination gives current player 1k. 
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The eventArgs</param>
        private void MonopolyMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Capture keys/tries one by one. 
            // If key is not recognized, it will break the code.
            if (this.cheatCode.Contains(e.KeyCode))
            {
                this.cheatCodeKeysPressed.Add(e.KeyCode); // will add key to list in the order it came in

                // Check if cheat code is now completed by checking if the sequence matches the code.
                if (this.cheatCode.SequenceEqual(this.cheatCodeKeysPressed))
                {
                    this.currentPlayer.Money += 1000;
                    this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");
                    this.cheatCodeKeysPressed.Clear();
                }
                else if (this.cheatCode.Count == this.cheatCodeKeysPressed.Count)
                {
                    this.cheatCodeKeysPressed.Clear();
                }
            }
            else
            {
                this.cheatCodeKeysPressed.Clear();
            }
        }
    }
}

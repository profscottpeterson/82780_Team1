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
    /// 
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
        /// The array of radio buttons for the player options
        /// </summary>
        private RadioButton[] radioButtons;

        /// <summary>
        /// How many doubles have been rolled in a turn
        /// </summary>
        private int doubleCounter = 0;

        /// <summary>
        /// Determines which player to display using the set up player method
        /// </summary>
        private bool formBool = false;

        /// <summary>
        /// Initializes a new instance of the MonopolyMainForm class.
        /// </summary>
        public MonopolyMainForm()
        {
            ////this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonopolyMainForm_Load(object sender, EventArgs e)
        {
            // Call StartGame method and get dialog result from GameOptions form
            DialogResult result = this.StartGame();

            // If start was pressed on GameOptions form,
            // dynamically add picture boxes and their click events
            // (Should only be done once and on form load)
            if(result == DialogResult.OK)
            {
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
                }
            }
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <returns>The dialog result from the Game options form</returns>
        private DialogResult StartGame()
        {
            // Instantiate game
            this.game = new Game();

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
                List<PictureBox> playerBoxes = new List<PictureBox>();
                for (int i = 0; i < this.game.Players.Count; i++)
                {
                    playerBoxes.Add((PictureBox) Controls.Find("picPlayer" + (i + 1), true)[0]);
                    this.game.Players[i].PlayerPictureBox = playerBoxes[i];
                }

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
                this.formBool = true;
                this.SetUpPlayerHandOptions();
                this.lblPlayerTurn.Text = this.currentPlayer.PlayerName + "'s Turn";
                this.lblCurrentBalance.Text = "Current Balance: " + '\n' + this.currentPlayer.Money.ToString("c0");
            }

            return result;
        }

        /// <summary>
        /// The click event for rolling the two dice on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRoll_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            int die1 = 0;
            int die2 = 0;

            die1 = rand.Next(1, 7);
            die2 = rand.Next(1, 7);

            pbxDiceLeft.Image = this.dicePictures.Images[die1 - 1];
            pbxDiceRight.Image = this.dicePictures.Images[die2 - 1];

            if (this.currentPlayer.InJail == false)
            {
                int totalMove = 0;

                totalMove = die1 + die2;

                // Find player's new location and set current location property of player
                this.game.MovePlayerLocation(this.currentPlayer, totalMove);

                // Move pawn picture
                this.FindNewPawnLocations(this.currentPlayer.CurrentLocation.SpotId, this.currentPlayer);

                // So balance is updated when Go is passed
                this.lblCurrentBalance.Text = "Current Balance: " + '\n' + currentPlayer.Money.ToString("c0");

                this.game.RollChecks(this.currentPlayer);

                if (die1 == die2)
                {
                    this.doubleCounter++;
                    if (this.doubleCounter >= 3)
                    {
                        this.game.SendToJail(this.currentPlayer);
                    }
                    else
                    {
                        this.BtnNextTurn.Enabled = false;
                        this.btnRoll.Enabled = true;
                        this.btnRoll.Focus();
                    }
                }
                else
                {
                    this.BtnNextTurn.Enabled = true;
                    this.BtnNextTurn.Focus();
                    this.btnRoll.Enabled = false;
                }
            }
            else
            {
                if (die1 == die2)
                {
                    this.currentPlayer.InJail = false;
                    this.currentPlayer.TurnsInJail = 0;
                    int total = die1 + die2;
                    this.game.MovePlayerLocation(this.currentPlayer, total);
                    this.FindNewPawnLocations(this.currentPlayer.CurrentLocation.SpotId, this.currentPlayer);

                    this.game.RollChecks(this.currentPlayer);
                }
                else
                {
                    this.btnJailPay.Enabled = true;

                    this.currentPlayer.TurnsInJail++;

                    if (this.currentPlayer.TurnsInJail == 3)
                    {
                        this.currentPlayer.Money -= 50;
                        this.game.CheckIfPlayerHasEnoughMoney(this.currentPlayer);
                        this.currentPlayer.InJail = false;
                        this.currentPlayer.TurnsInJail = 0;
                        int total = die1 + die2;
                        this.game.MovePlayerLocation(this.currentPlayer, total);
                    }
                }

                this.btnRoll.Enabled = false;
                this.BtnNextTurn.Enabled = true;
                this.BtnNextTurn.Focus();
            }

            // Move pawn picture
            this.FindNewPawnLocations(currentPlayer.CurrentLocation.SpotId, currentPlayer);

            this.btnJailFreeCard.Enabled = false;
            this.btnJailPay.Enabled = false;
            // this.formBool = false;
            this.flpOtherPlayerHand.Controls.Clear();
            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps);

            if (this.game.RestartGame)
            {
                this.RestartGame();
            }
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
                    this.game.SendToJail(this.currentPlayer);
                    //// this.currentPlayer.InJail = true;
                    //// this.currentPlayer.CurrentLocation = this.game.GetSpotByName("Jail");

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
        private void SetNextPlayer(Player player, FlowLayoutPanel panelToUse)
        {
            this.lblCurrentBalance.Text = "Current Balance: " + '\n' + currentPlayer.Money.ToString("c0");
            lblOtherPlayersHand.Text = string.Empty;
            panelToUse.Controls.Clear();
            List<Spot> currentPlayerSpots = new List<Spot>();
            currentPlayerSpots = this.game.GetPlayersPropertyList(player);
            PictureBox[] pictureBoxes = new PictureBox[currentPlayerSpots.Count];
            Panel[] playerPropertyPanels = new Panel[currentPlayerSpots.Count];
            Label[] playerPropertyLabels = new Label[currentPlayerSpots.Count];
            if (pictureBoxes.Length > 0)
            {
                for (int r = 0; r < pictureBoxes.Length; r++)
                {
                    pictureBoxes[r] = new PictureBox();
                    playerPropertyPanels[r] = new Panel();
                    playerPropertyLabels[r] = new Label();
                }

                foreach (PictureBox pb in pictureBoxes)
                {
                    Point point = new Point(5, 30);
                    pb.Width = 70;
                    pb.Height = 115;
                    pb.Location = point;
                }

                foreach (Panel pl in playerPropertyPanels)
                {
                    pl.Width = 80;
                    pl.Height = 150;
                    pl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }

                foreach (Label lbl in playerPropertyLabels)
                {
                    lbl.MaximumSize = new Size(80, 40);
                    lbl.AutoSize = true;
                    lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                }

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
                    if (s.Color == Color.Black)
                    {
                        if (s.Type == SpotType.Utility)
                        {
                            if (s.SpotName == "Electric Company")
                            {
                                tempImage = usableSpotPictures.Images[0];
                                p.Image = tempImage;   
                            }
                            else
                            {
                                tempImage = usableSpotPictures.Images[2];
                                p.Image = tempImage;
                            }
                        }
                        else
                        {
                            tempImage = usableSpotPictures.Images[1];
                            p.Image = tempImage;   
                        }
                    }
                    else if (s.Color == Color.DarkBlue)
                    {
                        tempImage = usableSpotPictures.Images[3];
                        p.Image = tempImage;   
                    }
                    else if (s.Color == Color.Green)
                    {
                        tempImage = usableSpotPictures.Images[4];
                        p.Image = tempImage;   
                    }
                    else if (s.Color == Color.LightBlue)
                    {
                        tempImage = usableSpotPictures.Images[5];
                        p.Image = tempImage;   
                    }
                    else if (s.Color == Color.Brown)
                    {
                        tempImage = usableSpotPictures.Images[6];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.Orange)
                    {
                        tempImage = usableSpotPictures.Images[7];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.Pink)
                    {
                        tempImage = usableSpotPictures.Images[8];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.Red)
                    {
                        tempImage = usableSpotPictures.Images[9];
                        p.Image = tempImage;
                    }
                    else if (s.Color == Color.Yellow)
                    {
                        tempImage = usableSpotPictures.Images[10];
                        p.Image = tempImage;
                    }

                    p.Tag = g.ToString();
                    panel.Tag = g.ToString();
                    label.Tag = g.ToString();
                    label.Text = s.SpotName;
                }
            }

            foreach (PictureBox pbx in pictureBoxes)
            {
                pbx.Click += delegate { this.PropertyClickEvent(currentPlayerSpots[int.Parse(pbx.Tag.ToString())]); };
            }

            foreach (Panel panel in playerPropertyPanels)
            {
                panel.Controls.Add(playerPropertyLabels[int.Parse(panel.Tag.ToString())]);
                panel.Controls.Add(pictureBoxes[int.Parse(panel.Tag.ToString())]);
                panelToUse.Controls.Add(panel);
            }

            if (this.formBool == false)
            {
                this.SetCurrentPlayerImage(player);
                this.lblPlayerTurn.Text = player.PlayerName + "'s Turn";
                this.lblCurrentBalance.Text = "Current Balance: " + '\n' + player.Money.ToString("c0");
                this.formBool = true;
            }
            else
            {
                SetUpPlayerHandOptions();
                lblOtherPlayersHand.Text = player.PlayerName;
                if (lblOtherPlayersHand.Text == currentPlayer.PlayerName)
                {
                    lblOtherPlayersHand.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Sets up options for seeing other players' hands
        /// </summary>
        private void SetUpPlayerHandOptions()
        {
            
            flpPlayerHandOptions.Controls.Clear();
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
                        this.radioButtons[x].Text = this.game.Players[x].PlayerName;
                        this.radioButtons[x].Font = new Font("Microsoft Sans Serif", 13);
                        this.radioButtons[x].Tag = this.game.Players[x].PlayerId;
                    }
                }

                for (int x = 0; x < activePlayerCount; x++)
                {
                    RadioButton r = this.radioButtons[x];
                    if (playerStatus[x] == true)
                    {
                        if (r.Text != this.currentPlayer.PlayerName)
                        {
                            if (r.Text != string.Empty)
                            {
                                r.CheckedChanged += delegate
                                {
                                    this.SetNextPlayer(this.game.Players[int.Parse(r.Tag.ToString())], this.flpOtherPlayerHand);
                                };
                                flpPlayerHandOptions.Controls.Add(r);
                            }
                        }
                    }
                }
            }
        }

        private void SetCurrentPlayerImage(Player player)
        {
            if (player.PlayerPictureBox.Image != null)
            {
                this.pbxCurrentPlayerPicture.Image = player.PlayerPictureBox.Image;
            }
            else
            {
                this.pbxCurrentPlayerPicture.BackColor = player.PlayerPictureBox.BackColor;
            }
        }

        private void PropertyClickEvent(Spot spot)
        {
            if (spot.Type == SpotType.Property)
            {
                MonPopUp popUp = new MonPopUp(spot);
                popUp.StartPosition = FormStartPosition.CenterParent;
                popUp.ShowDialog();
            }

            if (spot.Type == SpotType.Railroad || spot.Type == SpotType.Utility)
            {
                NonPropPopUp popUp = new NonPropPopUp(spot, this.game);
                popUp.StartPosition = FormStartPosition.CenterParent;
                popUp.ShowDialog();
            }
        }

        private void BtnTradeRequest_Click(object sender, EventArgs e)
        {
            Trade tradeForm = new Trade(this.currentPlayer, this.game);
            tradeForm.StartPosition = FormStartPosition.CenterParent;
            tradeForm.ShowDialog();

            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps);
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            GetMoney money = new GetMoney(this.game, this.currentPlayer);

            money.ShowDialog();
            while (this.currentPlayer.IsActive == false)
            {
                this.currentPlayer = this.game.NextPlayer(this.currentPlayer);
                this.formBool = false;
            }

            this.flpOtherPlayerHand.Controls.Clear();
            this.lblOtherPlayersHand.Text = string.Empty;
            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps);
            this.SetUpPlayerHandOptions();

            // If a player foreited
            if (money.DialogResult == DialogResult.Cancel)
            {
                this.BtnNextTurn.Enabled = false;
                this.btnRoll.Enabled = true;
                this.btnRoll.Focus();
            }

            if (this.game.RestartGame)
            {
                this.RestartGame();
            }
        }

        private void BtnBuyHouseOrHotel_Click(object sender, EventArgs e)
        {
            UpgradeProperty upgrade = new UpgradeProperty(this.game, this.currentPlayer);
            if (upgrade.IsDisposed == false)
            {
                upgrade.ShowDialog();
                this.currentPlayer = this.game.Players[this.currentPlayer.PlayerId];
            }

            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps);
        }

        private void BtnNextTurn_Click(object sender, EventArgs e)
        {
            this.btnRoll.Enabled = true;
            this.BtnNextTurn.Enabled = false;
            this.btnRoll.Focus();
            this.doubleCounter = 0;
            this.formBool = false;
            this.currentPlayer = this.game.NextPlayer(this.currentPlayer);
            this.flpCurrentPlayerProps.Controls.Clear();
            this.flpOtherPlayerHand.Controls.Clear();
            this.lblOtherPlayersHand.Text = string.Empty;
            this.flpPlayerHandOptions.Controls.Clear();

            while (this.currentPlayer.IsActive == false)
            {
                this.currentPlayer = this.game.NextPlayer(this.currentPlayer);
            }

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

            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps);
        }

        private void BtnJailPay_Click(object sender, EventArgs e)
        {
            // take players money
            this.currentPlayer.Money -= 50;
            this.lblCurrentBalance.Text = "Current Balance: " + '\n' + currentPlayer.Money.ToString("c0");

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
        }

        private void BtnJailFreeCard_Click(object sender, EventArgs e)
        {
            // use the players card
            ////this.currentPlayer.GetOutOfJailFreeCards.RemoveAt(0);

            // set players jail bool to false
            /////this.currentPlayer.InJail = false;

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
        }

        private void QuitGameBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Restarts a game when button is clicked
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        /// <summary>
        /// Restarts a game
        /// </summary>
        private void RestartGame()
        {
            // Call StartGame to start a new game with game options form
            this.StartGame();

            // Enable and disable central buttons
            this.btnRoll.Enabled = true;
            this.btnRoll.Focus();
            this.BtnNextTurn.Enabled = false;
            this.btnJailPay.Enabled = false;
            this.btnJailFreeCard.Enabled = false;

            // Set up the current player's information on the form
            this.SetNextPlayer(this.currentPlayer, this.flpCurrentPlayerProps);

            // Loop through the list of players
            foreach (Player player in this.game.Players)
            {
                // Move their pawn picture back to Go
                this.FindNewPawnLocations(player.CurrentLocation.SpotId, player);
            }
        }
    }
}

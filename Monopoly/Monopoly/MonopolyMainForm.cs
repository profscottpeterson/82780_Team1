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

    /// <summary>
    /// An enum for dictating a spots type
    /// </summary>
    public enum SpotType
    {
        Property,
        Chance,
        CommunityChest,
        Go,
        Jail,
        GoToJail,
        Tax,
        Utility,
        Railroad,
        FreeParking
    }

    /// <summary>
    /// An enum for dictating a cards type
    /// </summary>
    public enum CardType
    {
        CommunityChest,
        Chance
    }


    public partial class MonopolyMainForm : Form
    {
        private Player currentPlayer;
        public Game game;
        int P1Jail = 1;
        int P2Jail = 1;
        int P3Jail = 1;
        int P4Jail = 1;

        public MonopolyMainForm()
        {
            InitializeComponent();
        }

        /*
        public Player getCurrentPlayer()
        {
            return this.currentPlayer;
        }
        */
        
        private void MonopolyMainForm_Load(object sender, EventArgs e)
        {
            // Instantiate Game
            game = new Game();

            // Options to start game, player count notably
            GameOptions options = new GameOptions(game);
            options.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = options.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }

            if (result == DialogResult.OK)
            {
                // Sets the list of players to the list of players passed from the game options form
                game.Players = options.TempPlayers;
                currentPlayer = game.Players[0];

                // Sets the players picture box to their picture box on the form
                List<PictureBox> playerBoxes = new List<PictureBox>();
                for (int i = 0; i < game.Players.Count; i++)
                {
                    playerBoxes.Add((PictureBox)Controls.Find("picPlayer" + (i+1), true)[0]);
                    game.Players[i].PlayerPictureBox = playerBoxes[i];
                }

                // Shows the players the current players image or color as well as the current player
                SetCurrentPlayerImage(currentPlayer);
                lblPlayerTurn.Text = currentPlayer.PlayerName + "'s Turn";
                lblCurrentBalance.Text = currentPlayer.Money.ToString("c0");

                // Finds each spot on the board and adds them to a list
                List<PictureBox> spotPictures = new List<PictureBox>();
                for (int i = 1; i <= 40; i++)
                {
                    spotPictures.Add((PictureBox) Controls.Find("pictureBox" + i, true)[0]);

                    // Sets a tag for the image 
                    spotPictures[i - 1].Tag = i - 1;
                }

                // A foreach loop that runs through each picture box that is a spot
                foreach (PictureBox p in spotPictures)
                {
                    Spot spot = game.Board[(int)p.Tag];
                    spot.SpotBox = p;

                    // Assigns a click event to the picture box
                    p.Click += delegate
                    {
                        /*
                        if (spot.Type == SpotType.Property)
                        {
                            MonPopUp popUp = new MonPopUp(spot);
                            popUp.ShowDialog();
                        }

                        if (spot.Type == SpotType.Railroad || spot.Type == SpotType.Utility)
                        {
                            NonPropPopUp popUp = new NonPropPopUp(spot);
                            popUp.ShowDialog();
                        }
                        */
                        PropertyClickEvent(spot);
                    };
                }
            }
        }

        /// <summary>
        /// The click event for rolling the two dice on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoll_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            int die1 = 0;
            int die2 = 0;

            die1 = rand.Next(1, 7);
            die2 = rand.Next(1, 7);

            // lblDie1.Text = die1.ToString();
            // lblDie2.Text = die2.ToString();

            pbxDiceLeft.Image = this.dicePictures.Images[die1 - 1];
            pbxDiceRight.Image = this.dicePictures.Images[die2 - 1];

            if (currentPlayer.InJail == false) {

                int totalMove = 0;

                totalMove = die1 + die2;

                /*int newLocation = 0;

                int currentLocation = currentPlayer.CurrentLocation.SpotId;

                newLocation = currentLocation + totalMove;

                if (newLocation > 39)
                {
                    newLocation -= 40;
                    currentPlayer.Money += 200;
                }

                currentPlayer.CurrentLocation = game.GetSpotById(newLocation);*/

                // Find player's new location and set current location property of player
                game.MovePlayerLocation(currentPlayer, totalMove);

                // Move pawn picture
                FindNewPawnLocations(currentPlayer.CurrentLocation.SpotId);

                // Check to see if rent needs to be paid and pay it if so
                game.CheckPayRent(currentPlayer, currentPlayer.CurrentLocation);

                // Check to see if spot landed on can be bought
                if (game.ShowBuyPropertyButton(currentPlayer, currentPlayer.CurrentLocation))
                {
                    ////TODO: CHECK THE BUY PROPERTY CODE - AKA THE BUYPROP FORM AND CODE IN THIS IF STATEMENT AND THERE

                    BuyProp buyProp = new BuyProp(currentPlayer.CurrentLocation, currentPlayer, game);
                    buyProp.StartPosition = FormStartPosition.CenterParent;
                    buyProp.ShowDialog();
                }

                // Check to see if tax needs to be paid and pay it if yes
                game.CheckPayTax(currentPlayer, currentPlayer.CurrentLocation);

                // Check to see if player landed on "Go to Jail"
                game.CheckGoToJail(currentPlayer, currentPlayer.CurrentLocation);

                ////TODO: Chance and Community Chest cards

                // Move pawn picture
                FindNewPawnLocations(currentPlayer.CurrentLocation.SpotId);
            }
            else
            {
                Point p = new Point();

                if (die1 == die2)
                {
                    currentPlayer.InJail = false;

                    if (currentPlayer.PlayerId == 0)
                    {
                        P1Jail = 1;

                        p.X = 28;
                        p.Y = 774;

                        picPlayer1.Location = p;
                    }
                    else if (currentPlayer.PlayerId == 1)
                    {
                        P2Jail = 1;

                        p.X = 28;
                        p.Y = 814;

                        picPlayer2.Location = p;
                    }
                    else if (currentPlayer.PlayerId == 2)
                    {
                        P3Jail = 1;

                        p.X = 60;
                        p.Y = 846;

                        picPlayer3.Location = p;
                    }
                    else if (currentPlayer.PlayerId == 3)
                    {
                        P4Jail = 1;

                        p.X = 99;
                        p.Y = 846;

                        picPlayer4.Location = p;
                    }
                }
                else
                {
                    if (currentPlayer.PlayerId == 0)
                    {
                        if (P1Jail == 3)
                        {
                            currentPlayer.InJail = false;
                            P1Jail = 1;

                            p.X = 28;
                            p.Y = 774;

                            picPlayer1.Location = p;
                        }
                        else
                        {
                            P1Jail++;
                        }
                    }
                    else if (currentPlayer.PlayerId == 1)
                    {
                        if (P2Jail == 3)
                        {
                            currentPlayer.InJail = false;
                            P2Jail = 1;

                            p.X = 28;
                            p.Y = 814;

                            picPlayer2.Location = p;
                        }
                        else
                        {
                            P2Jail++;
                        }
                    }
                    else if (currentPlayer.PlayerId == 2)
                    {
                        if (P3Jail == 3)
                        {
                            currentPlayer.InJail = false;
                            P3Jail = 1;

                            p.X = 60;
                            p.Y = 846;

                            picPlayer3.Location = p;
                        }
                        else
                        {
                            P3Jail++;
                        }
                    }
                    else if (currentPlayer.PlayerId == 3)
                    {
                        if (P4Jail == 3)
                        {
                            currentPlayer.InJail = false;
                            P4Jail = 1;

                            p.X = 99;
                            p.Y = 846;

                            picPlayer4.Location = p;
                        }
                        else
                        {
                            P4Jail++;
                        }
                    }
                }
            }

            currentPlayer = game.NextPlayer(currentPlayer);
            SetNextPlayer(currentPlayer);
        }

        private void FindNewPawnLocations(int newLocation)
        {
            // Bottom Row
            if (newLocation > 0 && newLocation < 10)
            {
                Point p = new Point();

                p.Y = 800;
                p.X = 765 - (newLocation * 70);

                if (currentPlayer.PlayerId == 0)
                {
                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.X = p.X + 45;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.Y = p.Y + 45;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = p.X + 45;
                    p.Y = p.Y + 45;

                    picPlayer4.Location = p;
                }
            }
            // Left column
            else if (newLocation > 10 && newLocation < 20)
            {
                Point p = new Point();

                p.Y = 765 - ((newLocation - 10) * 70);
                p.X = 75;

                if (currentPlayer.PlayerId == 0)
                {
                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.Y = p.Y + 45;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.X = p.X - 45;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = p.X - 45;
                    p.Y = p.Y + 45;

                    picPlayer4.Location = p;
                }
            }
            // Top row
            else if (newLocation > 20 && newLocation < 30)
            {
                Point p = new Point();

                p.Y = 75;
                p.X = 135 + ((newLocation - 21) * 70);

                if (currentPlayer.PlayerId == 0)
                {
                    p.X = p.X + 45;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.Y = p.Y - 45;
                    p.X = p.X + 45;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.Y = p.Y - 45;

                    picPlayer4.Location = p;
                }
            }
            // Right Column
            else if (newLocation > 30 && newLocation < 40)
            {
                Point p = new Point();

                p.Y = 135 + ((newLocation - 31) * 70);
                p.X = 800;

                if (currentPlayer.PlayerId == 0)
                {
                    p.Y = p.Y + 45;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.Y = p.Y + 45;
                    p.X = p.X + 45;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = p.X + 45;

                    picPlayer4.Location = p;
                }
            }
            // Land on go
            else if (newLocation == 0)
            {
                Point p = new Point();

                if (currentPlayer.PlayerId == 0)
                {
                    p.X = 790;
                    p.Y = 790;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.X = 840;
                    p.Y = 790;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.X = 790;
                    p.Y = 840;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = 840;
                    p.Y = 840;

                    picPlayer4.Location = p;
                }
            }
            // Visiting Jail
            else if (newLocation == 10 && currentPlayer.InJail == false)
            {
                Point p = new Point();

                if (currentPlayer.PlayerId == 0)
                {
                    p.X = 28;
                    p.Y = 774;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.X = 28;
                    p.Y = 814;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.X = 60;
                    p.Y = 846;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = 99;
                    p.Y = 846;

                    picPlayer4.Location = p;
                }
            }
            // If they are on the jail space but are in jail this will put them in jail
            else if (newLocation == 10 && currentPlayer.InJail)
            {
                Point p = new Point();

                if (currentPlayer.PlayerId == 0)
                {
                    p.X = 72;
                    p.Y = 771;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.X = 100;
                    p.Y = 771;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.X = 72;
                    p.Y = 802;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = 100;
                    p.Y = 802;

                    picPlayer4.Location = p;
                }
            }
            // Free Parking
            else if (newLocation == 20)
            {
                Point p = new Point();

                if (currentPlayer.PlayerId == 0)
                {
                    p.X = 45;
                    p.Y = 45;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.X = 90;
                    p.Y = 45;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.X = 45;
                    p.Y = 90;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = 90;
                    p.Y = 90;

                    picPlayer4.Location = p;
                }
            }
            // Go to Jail
            else if (newLocation == 30)
            {
                currentPlayer.InJail = true;
                currentPlayer.CurrentLocation = game.GetSpotByName("Jail");

                Point p = new Point();

                if (currentPlayer.PlayerId == 0)
                {
                    p.X = 72;
                    p.Y = 771;

                    picPlayer1.Location = p;
                }
                else if (currentPlayer.PlayerId == 1)
                {
                    p.X = 100;
                    p.Y = 771;

                    picPlayer2.Location = p;
                }
                else if (currentPlayer.PlayerId == 2)
                {
                    p.X = 72;
                    p.Y = 802;

                    picPlayer3.Location = p;
                }
                else if (currentPlayer.PlayerId == 3)
                {
                    p.X = 100;
                    p.Y = 802;

                    picPlayer4.Location = p;
                }
            }
        }

        /// <summary>
        /// The method used for setting up the next player's information on the form
        /// </summary>
        /// <param name="player"></param>
        private void SetNextPlayer(Player player)
        {
            flpCurrentPlayerProps.Controls.Clear();
            List<Spot> currentPlayerSpots = new List<Spot>();
            currentPlayerSpots = game.GetPlayersPropertyList(player);
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
                    Point point = new Point(5,30);
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
                    lbl.MaximumSize = new Size(80,40);
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
                pbx.Click += delegate { PropertyClickEvent(currentPlayerSpots[Int32.Parse(pbx.Tag.ToString())]); };
            }

            foreach (Panel panel in playerPropertyPanels)
            {
                panel.Controls.Add(playerPropertyLabels[int.Parse(panel.Tag.ToString())]);
                panel.Controls.Add(pictureBoxes[int.Parse(panel.Tag.ToString())]);
                flpCurrentPlayerProps.Controls.Add(panel);
            }
            SetCurrentPlayerImage(player);
            lblPlayerTurn.Text = player.PlayerName + "'s Turn";
            lblCurrentBalance.Text = player.Money.ToString("c0");
        }

        private void SetCurrentPlayerImage(Player player)
        {
            if (player.PlayerPictureBox.Image != null)
            {
                pbxCurrentPlayerPicture.Image = player.PlayerPictureBox.Image;
            }
            else
            {
                pbxCurrentPlayerPicture.BackColor = player.PlayerPictureBox.BackColor;
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
                NonPropPopUp popUp = new NonPropPopUp(spot);
                popUp.StartPosition = FormStartPosition.CenterParent;
                popUp.ShowDialog();
            }
        }

        private void btnTradeRequest_Click(object sender, EventArgs e)
        {
            Trade tradeForm = new Trade(currentPlayer, game);
            tradeForm.StartPosition = FormStartPosition.CenterParent;
            tradeForm.ShowDialog();
            

            SetNextPlayer(currentPlayer);
        }
    }
}

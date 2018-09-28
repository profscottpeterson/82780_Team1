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

    public enum CardType
    {
        CommunityChest,
        Chance
    }

    public partial class MonopolyMainForm : Form
    {
        private Player currentPlayer;
        Game game;
        int P1Jail = 1;
        int P2Jail = 1;
        int P3Jail = 1;
        int P4Jail = 1;

        public MonopolyMainForm()
        {
            InitializeComponent();
        }

        private void MonopolyMainForm_Load(object sender, EventArgs e)
        {
            // Instantiate Game
            game = new Game();

            // Options to start game, player count notably
            GameOptions options = new GameOptions(game);
            DialogResult result = options.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }

            if (result == DialogResult.OK)
            {
                game.Players = options.TempPlayers;
                currentPlayer = game.Players[0];

                lblPlayerTurn.Text = currentPlayer.PlayerName + "'s Turn";

                List<PictureBox> spotPictures = new List<PictureBox>();
                for (int i = 1; i <= 40; i++)
                {
                    spotPictures.Add((PictureBox) Controls.Find("pictureBox" + i, true)[0]);
                    spotPictures[i - 1].Tag = i - 1;
                }

                foreach (PictureBox p in spotPictures)
                {
                    p.Click += delegate
                    {
                        Spot spot = game.Board[(int) p.Tag];

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

                    };
                }
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (currentPlayer.InJail == false) {
                Random rand = new Random();

                int die1 = 0;
                int die2 = 0;
                int totalMove = 0;

                die1 = rand.Next(1, 7);
                die2 = rand.Next(1, 7);

                lblDie1.Text = die1.ToString();
                lblDie2.Text = die2.ToString();

                totalMove = die1 + die2;

                int newLocation = 0;

                int currentLocation = currentPlayer.CurrentLocation.SpotId;

                newLocation = currentLocation + totalMove;

                if (newLocation > 39)
                {
                    newLocation -= 40;
                    currentPlayer.Money += 200;
                }

                currentPlayer.CurrentLocation = game.GetSpotById(newLocation);

                // Bottom Row
                if (newLocation > 0 &&  newLocation < 10)
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

                    p.Y = 765 - ((newLocation - 10)* 70);
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
                else if (newLocation == 10)
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

                // Next Player
                currentPlayer = game.NextPlayer(currentPlayer);
                lblPlayerTurn.Text = currentPlayer.PlayerName + "'s Turn";
                // End of not jail roll
            }
            else
            {
                Random rand = new Random();

                int die1 = 0;
                int die2 = 0;

                die1 = rand.Next(1, 7);
                die2 = rand.Next(1, 7);

                lblDie1.Text = die1.ToString();
                lblDie2.Text = die2.ToString();

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

                // Next Player
                currentPlayer = game.NextPlayer(currentPlayer);
                lblPlayerTurn.Text = currentPlayer.PlayerName + "'s Turn";
                // End of if in jail roll
            }
        }

        //Make new lists to hold players and spots


        /*
        public void instantiatePlayers(int num)
        {
            //Based on int of how many players
            for (int i = 0; i < num; i++)
            {
                int o = i + 1;

                if (o == 1)
                {
                    if (chkAiPlayer1.isChecked())
                    {
                        Player temp = new Player(1, txtName1.Text, Color.One, true);
                        players.Add(temp);
                    }
                    else
                    {
                        Player temp = new Player(1, txtName1.Text, Color.One);
                        players.Add(temp);
                    }
                }
                else if (o == 2)
                {
                    if (chkAiPlayer2.isChecked())
                    {
                        Player temp = new Player(2, txtName2.Text, Color.Two, true);
                        players.Add(temp);
                    }
                    else
                    {
                        Player temp = new Player(2, txtName2.Text, Color.Two);
                        players.Add(temp);
                    }
                }
                else if (o == 3)
                {
                    if (chkAiPlayer3.isChecked())
                    {
                        Player temp = new Player(3, txtName3.Text, Color.Three, true);
                        players.Add(temp);
                    }
                    else
                    {
                        Player temp = new Player(3, txtName3.Text, Color.Three);
                        players.Add(temp);
                    }
                }
                else if (o == 4)
                {
                    if (chkAiPlayer4.isChecked())
                    {
                        Player temp = new Player(4, txtName4.Text, Color.Four, true);
                        players.Add(temp);
                    }
                    else
                    {
                        Player temp = new Player(4, txtName4.Text, Color.Four);
                        players.Add(temp);
                    }
                }
            }
        }
        */



        /*
        //Give p1 Spot to p2 if p2 has enough money.
        public void GiveToPlayer(Player p1, Player p2, int amount, int index)
        {
            if (p2.Money >= amount)
            {
                int indexInList = 0;
                Spot temp;

                for (int i = 0; i < p1.Properties.Count; i++)
                {
                    if (p1.Properties[i].SpotId == index)
                    {
                        indexInList = i;
                    }
                }

                temp = p1.Properties[indexInList];
                p1.Properties.Remove(indexInList);
                p2.Properties.Add(temp);
                p2.Money -= amount;
            }
        }

        //A player buys an unowned Spot
        public void Buy(Player p, int index)
        {
            Player owner = FindOwner();

            if (owner == null)
            {
                Spot prop;

                foreach (Spot p in Board)
                {
                    if (p.SpotId == index)
                    {
                        prop = p;
                    }
                }

                if (p.Money >= prop.Price)
                {
                    p.Properties.Add(prop);
                    p.Money -= prop.Price;
                }
            }
        }

        //Finds owner of a Spot
        public Player FindOwner(Spot p)
        {
            Player owner = null;

            foreach (Player pl in players)
            {
                foreach (Spot pr in p.properties)
                {
                    if (pr == p)
                    {
                        owner = pl;
                    }
                }
            }

            return owner;
        }
        */
    }
}

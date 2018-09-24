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

        public MonopolyMainForm()
        {
            InitializeComponent();
        }

        private void MonopolyMainForm_Load(object sender, EventArgs e)
        {
            // Instantiate Game
            Game game = new Game();

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

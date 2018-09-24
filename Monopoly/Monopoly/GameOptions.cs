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
    public partial class GameOptions : Form
    {
        public List<Player> TempPlayers { get; set; }

        private Game game;

        public GameOptions()
        {
            InitializeComponent();
            TempPlayers = new List<Player>();
        }

        public GameOptions(Game game)
        {
            InitializeComponent();
            this.game = game;
            TempPlayers = new List<Player>();
        }

        private void cmboNumPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            int value = int.Parse(cmboNumPlayers.Text);

            if (value == 2)
            {
                panelPlayer1.Visible = true;
                panelPlayer2.Visible = true;

                panelPlayer4.Visible = false;
                panelPlayer3.Visible = false;
            }
            else if (value == 3)
            {
                panelPlayer1.Visible = true;
                panelPlayer2.Visible = true;
                panelPlayer3.Visible = true;

                panelPlayer4.Visible = false;
            }
            else if (value == 4)
            {
                panelPlayer1.Visible = true;
                panelPlayer2.Visible = true;
                panelPlayer3.Visible = true;
                panelPlayer4.Visible = true;
            }

            this.btnStart.Enabled = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(Panel))
                {
                    Panel p = (Panel) control;
                    if (p.Visible)
                    {
                        Player temp = new Player();
                        foreach (var c in p.Controls)
                        {
                            if (c.GetType() == typeof(TextBox))
                            {
                                TextBox textBox = (TextBox) c;
                                string name = textBox.Text;
                                if (name == string.Empty)
                                {
                                    name = textBox.Tag.ToString();
                                }
                                temp.PlayerName = name;
                            }
                            else if (c.GetType() == typeof(CheckBox))
                            {
                                CheckBox checkBox = (CheckBox) c;
                                if (checkBox.Checked)
                                {
                                    temp.IsAi = true;
                                }
                                else
                                {
                                    temp.IsAi = false;
                                }
                            }
                        }
                        TempPlayers.Add(temp);
                    }
                }
            }

            TempPlayers.Reverse();

            for (int i = 0; i < this.TempPlayers.Count; i++)
            {
                this.TempPlayers[i].PlayerId = i;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

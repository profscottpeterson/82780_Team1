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
        /// <summary>
        /// Gets or sets the list of players
        /// </summary>
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
            // Get the value selected from the combobox
            int value = int.Parse(cmboNumPlayers.Text);

            if (value == 2)
            {
                // If the value is two
                // Make the first two panels visible
                panelPlayer1.Visible = true;
                panelPlayer2.Visible = true;

                // Make the last two panels invisible
                panelPlayer4.Visible = false;
                panelPlayer3.Visible = false;
            }
            else if (value == 3)
            {
                // If the value is three
                // Make the first three panels visible
                panelPlayer1.Visible = true;
                panelPlayer2.Visible = true;
                panelPlayer3.Visible = true;

                // Make the last panel invisible
                panelPlayer4.Visible = false;
            }
            else if (value == 4)
            {
                // If the value is four
                // Make all the panels visible
                panelPlayer1.Visible = true;
                panelPlayer2.Visible = true;
                panelPlayer3.Visible = true;
                panelPlayer4.Visible = true;
            }

            // Enable the start button
            this.btnStart.Enabled = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Close down everything
            Environment.Exit(0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Player tempPlayer;

            if (panelPlayer1.Visible)
            {
                tempPlayer = new Player();
                string name = txtPlayer1Name.Text;
                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = txtPlayer1Name.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                // If the checkbox is checked
                if (chkAI1.Checked)
                {
                    // Set tempPlayer's boolean IsAi to true
                    tempPlayer.IsAi = true;
                }
                else
                {
                    // The checkbox was not checked
                    // Set tempPlayer's boolean IsAi to false
                    tempPlayer.IsAi = false;
                }

                this.TempPlayers.Add(tempPlayer);
            }

            if (panelPlayer2.Visible)
            {
                tempPlayer = new Player();
                string name = txtPlayerName2.Text;
                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = txtPlayerName2.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                // If the checkbox is checked
                if (chkAI2.Checked)
                {
                    // Set tempPlayer's boolean IsAi to true
                    tempPlayer.IsAi = true;
                }
                else
                {
                    // The checkbox was not checked
                    // Set tempPlayer's boolean IsAi to false
                    tempPlayer.IsAi = false;
                }

                this.TempPlayers.Add(tempPlayer);
            }

            if (panelPlayer3.Visible)
            {
                tempPlayer = new Player();
                string name = txtPlayerName3.Text;
                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = txtPlayerName3.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                // If the checkbox is checked
                if (chkAI3.Checked)
                {
                    // Set tempPlayer's boolean IsAi to true
                    tempPlayer.IsAi = true;
                }
                else
                {
                    // The checkbox was not checked
                    // Set tempPlayer's boolean IsAi to false
                    tempPlayer.IsAi = false;
                }

                this.TempPlayers.Add(tempPlayer);
            }

            if (panelPlayer4.Visible)
            {
                tempPlayer = new Player();
                string name = txtPlayerName4.Text;
                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = txtPlayerName4.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                // If the checkbox is checked
                if (chkAI4.Checked)
                {
                    // Set tempPlayer's boolean IsAi to true
                    tempPlayer.IsAi = true;
                }
                else
                {
                    // The checkbox was not checked
                    // Set tempPlayer's boolean IsAi to false
                    tempPlayer.IsAi = false;
                }

                this.TempPlayers.Add(tempPlayer);
            }
           

            // Loop through the list of players
            for (int i = 0; i < this.TempPlayers.Count; i++)
            {
                // Set each player id to its position in the list
                this.TempPlayers[i].CurrentLocation = game.GetSpotByName("Go");
                this.TempPlayers[i].PlayerId = i;
            }

            // Set the DialogResult to OK so it does not default to Cancel
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }
    }
}

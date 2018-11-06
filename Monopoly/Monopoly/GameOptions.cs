//-----------------------------------------------------------------------
// <copyright file="GameOptions.cs" company="null">
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
    /// The class for the game options form
    /// </summary>
    public partial class GameOptions : Form
    {
        /*
        public GameOptions()
        {
            InitializeComponent();
            TempPlayers = new List<Player>();
        }
        */

        /// <summary>
        /// The game
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the GameOptions class.
        /// </summary>
        /// <param name="game">The game.</param>
        public GameOptions(Game game)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
            this.game = game;
            this.TempPlayers = new List<Player>();
        }

        /// <summary>
        /// Gets or sets the list of players
        /// </summary>
        public List<Player> TempPlayers { get; set; }

        /// <summary>
        /// The method for whenever a different player is selected
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void CmboNumPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            // Get the value selected from the combobox
            int value = int.Parse(this.cmboNumPlayers.Text);

            if (value == 2)
            {
                // If the value is two
                // Make the first two panels visible
                this.panelPlayer1.Visible = true;
                this.panelPlayer2.Visible = true;

                // Make the last two panels invisible
                this.panelPlayer4.Visible = false;
                this.panelPlayer3.Visible = false;
            }
            else if (value == 3)
            {
                // If the value is three
                // Make the first three panels visible
                this.panelPlayer1.Visible = true;
                this.panelPlayer2.Visible = true;
                this.panelPlayer3.Visible = true;

                // Make the last panel invisible
                this.panelPlayer4.Visible = false;
            }
            else if (value == 4)
            {
                // If the value is four
                // Make all the panels visible
                this.panelPlayer1.Visible = true;
                this.panelPlayer2.Visible = true;
                this.panelPlayer3.Visible = true;
                this.panelPlayer4.Visible = true;
            }

            // Enable the start button
            this.btnStart.Enabled = true;
        }

        /// <summary>
        /// The button for closing the game options form.
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            // Close down everything
            Environment.Exit(0);
        }

        /// <summary>
        /// The button for starting the game.
        /// </summary>
        /// <param name="sender">The object</param>
        /// <param name="e">The event</param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            Player tempPlayer;

            if (this.panelPlayer1.Visible)
            {
                tempPlayer = new Player();
                string name = this.txtPlayer1Name.Text;

                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = this.txtPlayer1Name.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                this.TempPlayers.Add(tempPlayer);
            }

            if (panelPlayer2.Visible)
            {
                tempPlayer = new Player();
                string name = this.txtPlayerName2.Text;

                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = this.txtPlayerName2.Tag.ToString();
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
                    name = this.txtPlayerName3.Tag.ToString();
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
                    name = this.txtPlayerName4.Tag.ToString();
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
                this.TempPlayers[i].CurrentLocation = this.game.GetSpotByName("Go");
                this.TempPlayers[i].PlayerId = i;
            }

            // Set the DialogResult to OK so it does not default to Cancel
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }
    }
}

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
        /// A list of pictures that holds the pictures.
        /// </summary>
        private Image[] playerImages = new Image[4];

        /// <summary>
        /// Initializes a new instance of the GameOptions class.
        /// </summary>
        /// <param name="game">The game.</param>
        public GameOptions(Game game)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.Text = string.Empty;
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
        /// The method to choose an image for a player
        /// </summary>
        /// <param name="playerId">The player to set the picture of</param>
        public void ChooseImage(int playerId)
        {
            // if user clicked ok on open file dialog
            if (ofChooseGIfs.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the specified file
                string filepath = ofChooseGIfs.FileName;

                this.playerImages[playerId] = Image.FromFile(filepath);
            }
        }

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
            this.TempPlayers.Clear();

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

            if (this.panelPlayer2.Visible)
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
                if (this.chkAI2.Checked)
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

            if (this.panelPlayer3.Visible)
            {
                tempPlayer = new Player();
                string name = this.txtPlayerName3.Text;

                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = this.txtPlayerName3.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                // If the checkbox is checked
                if (this.chkAI3.Checked)
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

            if (this.panelPlayer4.Visible)
            {
                tempPlayer = new Player();
                string name = this.txtPlayerName4.Text;

                // If the textbox was empty
                if (name == string.Empty)
                {
                    // Get name the text that is in the tag
                    name = this.txtPlayerName4.Tag.ToString();
                }

                // Set the player name of tempPlayer
                tempPlayer.PlayerName = name;

                // If the checkbox is checked
                if (this.chkAI4.Checked)
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
                this.TempPlayers[i].PlayerPictureBox.Image = this.playerImages[i];
            }

            // Set the DialogResult to OK so it does not default to Cancel
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }

        /// <summary>
        /// The image choosing button for the first player
        /// </summary>
        /// <param name="sender">The sender control</param>
        /// <param name="e">The eventArgs for the click event</param>
        private void BtnChooseImage1_Click(object sender, EventArgs e)
        {
            this.ChooseImage(0);
        }

        /// <summary>
        /// The image choosing button for the second player
        /// </summary>
        /// <param name="sender">The sender control</param>
        /// <param name="e">The eventArgs for the click event</param>
        private void BtnChooseImage2_Click(object sender, EventArgs e)
        {
            this.ChooseImage(1);
        }

        /// <summary>
        /// The image choosing button for the third player
        /// </summary>
        /// <param name="sender">The sender control</param>
        /// <param name="e">The eventArgs for the click event</param>
        private void BtnChooseImage3_Click(object sender, EventArgs e)
        {
            this.ChooseImage(2);
        }

        /// <summary>
        /// The image choosing button for the fourth player
        /// </summary>
        /// <param name="sender">The sender control</param>
        /// <param name="e">The eventArgs for the click event</param>
        private void BtnChooseImage4_Click(object sender, EventArgs e)
        {
            this.ChooseImage(3);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            HelpMenu hm = new HelpMenu("Game Setup");
            hm.ShowDialog();
        }
    }
}

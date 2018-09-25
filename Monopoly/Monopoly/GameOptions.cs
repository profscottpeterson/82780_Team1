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
            // Loop through all the controls on the form
            foreach (var control in Controls)
            {
                // If the control is of type panel
                if (control.GetType() == typeof(Panel))
                {
                    // Declare a panel that is that control
                    Panel p = (Panel) control;

                    // if the panel is visible
                    if (p.Visible)
                    {
                        // Construct a new Player called tempPlayer
                        Player tempPlayer = new Player();

                        // Loop through all the panel's controls
                        foreach (var c in p.Controls)
                        {
                            // If the control inside the panel is a textbox
                            if (c.GetType() == typeof(TextBox))
                            {
                                // Declare a textbox that is that control
                                TextBox textBox = (TextBox) c;

                                // Get the text in the textbox
                                string name = textBox.Text;

                                // If the textbox was empty
                                if (name == string.Empty)
                                {
                                    // Get name the text that is in the tag
                                    name = textBox.Tag.ToString();
                                }

                                // Set the player name of tempPlayer
                                tempPlayer.PlayerName = name;
                            }
                            else if (c.GetType() == typeof(CheckBox))
                            {
                                // If the control inside the panel is a checkbox
                                // Declare a checkbox that is that control
                                CheckBox checkBox = (CheckBox) c;

                                // If the checkbox is checked
                                if (checkBox.Checked)
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
                            }
                        }

                        // Add tempPlayer to the List of Players
                        TempPlayers.Add(tempPlayer);
                    }
                }
            }

            // Reverse the list of players so the first player added is in position 0
            TempPlayers.Reverse();

            // Loop through the list of players
            for (int i = 0; i < this.TempPlayers.Count; i++)
            {
                // Set each player id to its position in the list
                this.TempPlayers[i].PlayerId = i;
            }

            // Set the DialogResult to OK so it does not default to Cancel
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }
    }
}

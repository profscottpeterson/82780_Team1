//-----------------------------------------------------------------------
// <copyright file="GameOptions.Designer.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    /// <summary>
    /// The class that holds all the form information
    /// </summary>
    public partial class GameOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The combo box for the number of players
        /// </summary>
        private System.Windows.Forms.ComboBox cmboNumPlayers;

        /// <summary>
        /// Player 1 option panel
        /// </summary>
        private System.Windows.Forms.Panel panelPlayer1;

        /// <summary>
        /// Asking for number of players label
        /// </summary>
        private System.Windows.Forms.Label lblNumPlayer;

        /// <summary>
        /// Player 1 Name label
        /// </summary>
        private System.Windows.Forms.Label lblPlayerName1;

        /// <summary>
        /// Text box for adding a player name
        /// </summary>
        private System.Windows.Forms.TextBox txtPlayer1Name;

        /// <summary>
        /// Player 2 option panel
        /// </summary>
        private System.Windows.Forms.Panel panelPlayer2;

        /// <summary>
        /// Player 2 Name label
        /// </summary>
        private System.Windows.Forms.Label lblPlayerName2;

        /// <summary>
        /// Text box for adding a player name
        /// </summary>
        private System.Windows.Forms.TextBox txtPlayerName2;

        /// <summary>
        /// A check box for determining if the player is an ai
        /// </summary>
        private System.Windows.Forms.CheckBox chkAI2;

        /// <summary>
        /// Player 3 option panel
        /// </summary>
        private System.Windows.Forms.Panel panelPlayer3;

        /// <summary>
        /// Player 3 Name label
        /// </summary>
        private System.Windows.Forms.Label lblPlayerName3;

        /// <summary>
        /// Text box for adding a player name
        /// </summary>
        private System.Windows.Forms.TextBox txtPlayerName3;

        /// <summary>
        /// A check box for determining if the player is an ai
        /// </summary>
        private System.Windows.Forms.CheckBox chkAI3;

        /// <summary>
        /// Player 4 option panel
        /// </summary>
        private System.Windows.Forms.Panel panelPlayer4;

        /// <summary>
        /// Player 4 Name label
        /// </summary>
        private System.Windows.Forms.Label lblPlayerName4;

        /// <summary>
        /// Text box for adding a player name
        /// </summary>
        private System.Windows.Forms.TextBox txtPlayerName4;

        /// <summary>
        /// A check box for determining if the player is an ai
        /// </summary>
        private System.Windows.Forms.CheckBox chkAI4;

        /// <summary>
        /// Button for starting the game
        /// </summary>
        private System.Windows.Forms.Button btnStart;

        /// <summary>
        /// Button for exiting the game
        /// </summary>
        private System.Windows.Forms.Button btnQuit;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmboNumPlayers = new System.Windows.Forms.ComboBox();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.lblPlayerName1 = new System.Windows.Forms.Label();
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.lblNumPlayer = new System.Windows.Forms.Label();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.lblPlayerName2 = new System.Windows.Forms.Label();
            this.txtPlayerName2 = new System.Windows.Forms.TextBox();
            this.chkAI2 = new System.Windows.Forms.CheckBox();
            this.panelPlayer3 = new System.Windows.Forms.Panel();
            this.lblPlayerName3 = new System.Windows.Forms.Label();
            this.txtPlayerName3 = new System.Windows.Forms.TextBox();
            this.chkAI3 = new System.Windows.Forms.CheckBox();
            this.panelPlayer4 = new System.Windows.Forms.Panel();
            this.lblPlayerName4 = new System.Windows.Forms.Label();
            this.txtPlayerName4 = new System.Windows.Forms.TextBox();
            this.chkAI4 = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblMonopoly = new System.Windows.Forms.Label();
            this.btnChooseImage1 = new System.Windows.Forms.Button();
            this.btnChooseImage2 = new System.Windows.Forms.Button();
            this.btnChooseImage3 = new System.Windows.Forms.Button();
            this.btnChooseImage4 = new System.Windows.Forms.Button();
            this.ofChooseGIfs = new System.Windows.Forms.OpenFileDialog();
            this.panelPlayer1.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            this.panelPlayer3.SuspendLayout();
            this.panelPlayer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmboNumPlayers
            // 
            this.cmboNumPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboNumPlayers.FormattingEnabled = true;
            this.cmboNumPlayers.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.cmboNumPlayers.Location = new System.Drawing.Point(128, 94);
            this.cmboNumPlayers.Name = "cmboNumPlayers";
            this.cmboNumPlayers.Size = new System.Drawing.Size(121, 21);
            this.cmboNumPlayers.TabIndex = 0;
            this.cmboNumPlayers.SelectedValueChanged += new System.EventHandler(this.CmboNumPlayers_SelectedValueChanged);
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Controls.Add(this.btnChooseImage1);
            this.panelPlayer1.Controls.Add(this.lblPlayerName1);
            this.panelPlayer1.Controls.Add(this.txtPlayer1Name);
            this.panelPlayer1.Location = new System.Drawing.Point(40, 121);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(209, 58);
            this.panelPlayer1.TabIndex = 1;
            this.panelPlayer1.Visible = false;
            // 
            // lblPlayerName1
            // 
            this.lblPlayerName1.AutoSize = true;
            this.lblPlayerName1.Location = new System.Drawing.Point(12, 10);
            this.lblPlayerName1.Name = "lblPlayerName1";
            this.lblPlayerName1.Size = new System.Drawing.Size(79, 13);
            this.lblPlayerName1.TabIndex = 2;
            this.lblPlayerName1.Text = "Player 1 Name:";
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.Location = new System.Drawing.Point(97, 7);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer1Name.TabIndex = 1;
            this.txtPlayer1Name.Tag = "Player 1";
            // 
            // lblNumPlayer
            // 
            this.lblNumPlayer.AutoSize = true;
            this.lblNumPlayer.Location = new System.Drawing.Point(26, 97);
            this.lblNumPlayer.Name = "lblNumPlayer";
            this.lblNumPlayer.Size = new System.Drawing.Size(96, 13);
            this.lblNumPlayer.TabIndex = 2;
            this.lblNumPlayer.Text = "Number of Players:";
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Controls.Add(this.btnChooseImage2);
            this.panelPlayer2.Controls.Add(this.lblPlayerName2);
            this.panelPlayer2.Controls.Add(this.txtPlayerName2);
            this.panelPlayer2.Controls.Add(this.chkAI2);
            this.panelPlayer2.Location = new System.Drawing.Point(40, 185);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(209, 58);
            this.panelPlayer2.TabIndex = 2;
            this.panelPlayer2.Visible = false;
            // 
            // lblPlayerName2
            // 
            this.lblPlayerName2.AutoSize = true;
            this.lblPlayerName2.Location = new System.Drawing.Point(12, 10);
            this.lblPlayerName2.Name = "lblPlayerName2";
            this.lblPlayerName2.Size = new System.Drawing.Size(79, 13);
            this.lblPlayerName2.TabIndex = 2;
            this.lblPlayerName2.Text = "Player 2 Name:";
            // 
            // txtPlayerName2
            // 
            this.txtPlayerName2.Location = new System.Drawing.Point(97, 7);
            this.txtPlayerName2.Name = "txtPlayerName2";
            this.txtPlayerName2.Size = new System.Drawing.Size(100, 20);
            this.txtPlayerName2.TabIndex = 3;
            this.txtPlayerName2.Tag = "Player 2";
            // 
            // chkAI2
            // 
            this.chkAI2.AutoSize = true;
            this.chkAI2.Location = new System.Drawing.Point(127, 33);
            this.chkAI2.Name = "chkAI2";
            this.chkAI2.Size = new System.Drawing.Size(36, 17);
            this.chkAI2.TabIndex = 4;
            this.chkAI2.Text = "AI";
            this.chkAI2.UseVisualStyleBackColor = true;
            // 
            // panelPlayer3
            // 
            this.panelPlayer3.Controls.Add(this.btnChooseImage3);
            this.panelPlayer3.Controls.Add(this.lblPlayerName3);
            this.panelPlayer3.Controls.Add(this.txtPlayerName3);
            this.panelPlayer3.Controls.Add(this.chkAI3);
            this.panelPlayer3.Location = new System.Drawing.Point(40, 250);
            this.panelPlayer3.Name = "panelPlayer3";
            this.panelPlayer3.Size = new System.Drawing.Size(209, 58);
            this.panelPlayer3.TabIndex = 3;
            this.panelPlayer3.Visible = false;
            // 
            // lblPlayerName3
            // 
            this.lblPlayerName3.AutoSize = true;
            this.lblPlayerName3.Location = new System.Drawing.Point(12, 10);
            this.lblPlayerName3.Name = "lblPlayerName3";
            this.lblPlayerName3.Size = new System.Drawing.Size(79, 13);
            this.lblPlayerName3.TabIndex = 2;
            this.lblPlayerName3.Text = "Player 3 Name:";
            // 
            // txtPlayerName3
            // 
            this.txtPlayerName3.Location = new System.Drawing.Point(97, 7);
            this.txtPlayerName3.Name = "txtPlayerName3";
            this.txtPlayerName3.Size = new System.Drawing.Size(100, 20);
            this.txtPlayerName3.TabIndex = 5;
            this.txtPlayerName3.Tag = "Player 3";
            // 
            // chkAI3
            // 
            this.chkAI3.AutoSize = true;
            this.chkAI3.Location = new System.Drawing.Point(127, 33);
            this.chkAI3.Name = "chkAI3";
            this.chkAI3.Size = new System.Drawing.Size(36, 17);
            this.chkAI3.TabIndex = 6;
            this.chkAI3.Text = "AI";
            this.chkAI3.UseVisualStyleBackColor = true;
            // 
            // panelPlayer4
            // 
            this.panelPlayer4.Controls.Add(this.btnChooseImage4);
            this.panelPlayer4.Controls.Add(this.lblPlayerName4);
            this.panelPlayer4.Controls.Add(this.txtPlayerName4);
            this.panelPlayer4.Controls.Add(this.chkAI4);
            this.panelPlayer4.Location = new System.Drawing.Point(40, 314);
            this.panelPlayer4.Name = "panelPlayer4";
            this.panelPlayer4.Size = new System.Drawing.Size(209, 58);
            this.panelPlayer4.TabIndex = 4;
            this.panelPlayer4.Visible = false;
            // 
            // lblPlayerName4
            // 
            this.lblPlayerName4.AutoSize = true;
            this.lblPlayerName4.Location = new System.Drawing.Point(12, 10);
            this.lblPlayerName4.Name = "lblPlayerName4";
            this.lblPlayerName4.Size = new System.Drawing.Size(79, 13);
            this.lblPlayerName4.TabIndex = 2;
            this.lblPlayerName4.Text = "Player 4 Name:";
            // 
            // txtPlayerName4
            // 
            this.txtPlayerName4.Location = new System.Drawing.Point(97, 7);
            this.txtPlayerName4.Name = "txtPlayerName4";
            this.txtPlayerName4.Size = new System.Drawing.Size(100, 20);
            this.txtPlayerName4.TabIndex = 7;
            this.txtPlayerName4.Tag = "Player 4";
            // 
            // chkAI4
            // 
            this.chkAI4.AutoSize = true;
            this.chkAI4.Location = new System.Drawing.Point(127, 33);
            this.chkAI4.Name = "chkAI4";
            this.chkAI4.Size = new System.Drawing.Size(36, 17);
            this.chkAI4.TabIndex = 8;
            this.chkAI4.Text = "AI";
            this.chkAI4.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(40, 378);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(158, 378);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(91, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // lblMonopoly
            // 
            this.lblMonopoly.AutoSize = true;
            this.lblMonopoly.BackColor = System.Drawing.Color.Red;
            this.lblMonopoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonopoly.ForeColor = System.Drawing.Color.FloralWhite;
            this.lblMonopoly.Location = new System.Drawing.Point(39, 20);
            this.lblMonopoly.Name = "lblMonopoly";
            this.lblMonopoly.Size = new System.Drawing.Size(210, 51);
            this.lblMonopoly.TabIndex = 7;
            this.lblMonopoly.Text = "Monopoly";
            // 
            // btnChooseImage1
            // 
            this.btnChooseImage1.Location = new System.Drawing.Point(3, 32);
            this.btnChooseImage1.Name = "btnChooseImage1";
            this.btnChooseImage1.Size = new System.Drawing.Size(92, 23);
            this.btnChooseImage1.TabIndex = 10;
            this.btnChooseImage1.Text = "Choose Image";
            this.btnChooseImage1.UseVisualStyleBackColor = true;
            this.btnChooseImage1.Click += new System.EventHandler(this.BtnChooseImage1_Click);
            // 
            // btnChooseImage2
            // 
            this.btnChooseImage2.Location = new System.Drawing.Point(3, 32);
            this.btnChooseImage2.Name = "btnChooseImage2";
            this.btnChooseImage2.Size = new System.Drawing.Size(92, 23);
            this.btnChooseImage2.TabIndex = 11;
            this.btnChooseImage2.Text = "Choose Image";
            this.btnChooseImage2.UseVisualStyleBackColor = true;
            this.btnChooseImage2.Click += new System.EventHandler(this.BtnChooseImage2_Click);
            // 
            // btnChooseImage3
            // 
            this.btnChooseImage3.Location = new System.Drawing.Point(3, 32);
            this.btnChooseImage3.Name = "btnChooseImage3";
            this.btnChooseImage3.Size = new System.Drawing.Size(92, 23);
            this.btnChooseImage3.TabIndex = 11;
            this.btnChooseImage3.Text = "Choose Image";
            this.btnChooseImage3.UseVisualStyleBackColor = true;
            this.btnChooseImage3.Click += new System.EventHandler(this.BtnChooseImage3_Click);
            // 
            // btnChooseImage4
            // 
            this.btnChooseImage4.Location = new System.Drawing.Point(3, 32);
            this.btnChooseImage4.Name = "btnChooseImage4";
            this.btnChooseImage4.Size = new System.Drawing.Size(92, 23);
            this.btnChooseImage4.TabIndex = 11;
            this.btnChooseImage4.Text = "Choose Image";
            this.btnChooseImage4.UseVisualStyleBackColor = true;
            this.btnChooseImage4.Click += new System.EventHandler(this.BtnChooseImage4_Click);
            // 
            // ofChooseGIfs
            // 
            this.ofChooseGIfs.Filter = "\"Image files(*.png;*.jpg;*.gif;*.JPEG;)|*.png;*.jpg;*.gif;*.JPEG;\"";
            // 
            // GameOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 423);
            this.Controls.Add(this.lblMonopoly);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panelPlayer4);
            this.Controls.Add(this.panelPlayer3);
            this.Controls.Add(this.panelPlayer2);
            this.Controls.Add(this.lblNumPlayer);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.cmboNumPlayers);
            this.Name = "GameOptions";
            this.Text = "GameOptions";
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            this.panelPlayer3.ResumeLayout(false);
            this.panelPlayer3.PerformLayout();
            this.panelPlayer4.ResumeLayout(false);
            this.panelPlayer4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Monopoly Label
        /// </summary>
        private System.Windows.Forms.Label lblMonopoly;

        /// <summary>
        /// Button to choose the image for the first player
        /// </summary>
        private System.Windows.Forms.Button btnChooseImage1;

        /// <summary>
        /// Button to choose the image for the second player
        /// </summary>
        private System.Windows.Forms.Button btnChooseImage2;

        /// <summary>
        /// Button to choose the image for the third player
        /// </summary>
        private System.Windows.Forms.Button btnChooseImage3;

        /// <summary>
        /// Button to choose the image for the fourth player
        /// </summary>
        private System.Windows.Forms.Button btnChooseImage4;

        /// <summary>
        /// Dialog box to allow the user to select an image for their player
        /// </summary>
        private System.Windows.Forms.OpenFileDialog ofChooseGIfs;
    }
}
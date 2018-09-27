namespace Monopoly
{
    partial class GameOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.chkAI1 = new System.Windows.Forms.CheckBox();
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
            this.cmboNumPlayers.Location = new System.Drawing.Point(114, 6);
            this.cmboNumPlayers.Name = "cmboNumPlayers";
            this.cmboNumPlayers.Size = new System.Drawing.Size(121, 21);
            this.cmboNumPlayers.TabIndex = 0;
            this.cmboNumPlayers.SelectedValueChanged += new System.EventHandler(this.cmboNumPlayers_SelectedValueChanged);
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Controls.Add(this.lblPlayerName1);
            this.panelPlayer1.Controls.Add(this.txtPlayer1Name);
            this.panelPlayer1.Controls.Add(this.chkAI1);
            this.panelPlayer1.Location = new System.Drawing.Point(26, 33);
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
            // chkAI1
            // 
            this.chkAI1.AutoSize = true;
            this.chkAI1.Location = new System.Drawing.Point(127, 33);
            this.chkAI1.Name = "chkAI1";
            this.chkAI1.Size = new System.Drawing.Size(36, 17);
            this.chkAI1.TabIndex = 0;
            this.chkAI1.Text = "AI";
            this.chkAI1.UseVisualStyleBackColor = true;
            // 
            // lblNumPlayer
            // 
            this.lblNumPlayer.AutoSize = true;
            this.lblNumPlayer.Location = new System.Drawing.Point(12, 9);
            this.lblNumPlayer.Name = "lblNumPlayer";
            this.lblNumPlayer.Size = new System.Drawing.Size(96, 13);
            this.lblNumPlayer.TabIndex = 2;
            this.lblNumPlayer.Text = "Number of Players:";
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Controls.Add(this.lblPlayerName2);
            this.panelPlayer2.Controls.Add(this.txtPlayerName2);
            this.panelPlayer2.Controls.Add(this.chkAI2);
            this.panelPlayer2.Location = new System.Drawing.Point(26, 97);
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
            this.txtPlayerName2.TabIndex = 1;
            this.txtPlayerName2.Tag = "Player 2";
            // 
            // chkAI2
            // 
            this.chkAI2.AutoSize = true;
            this.chkAI2.Location = new System.Drawing.Point(127, 33);
            this.chkAI2.Name = "chkAI2";
            this.chkAI2.Size = new System.Drawing.Size(36, 17);
            this.chkAI2.TabIndex = 0;
            this.chkAI2.Text = "AI";
            this.chkAI2.UseVisualStyleBackColor = true;
            // 
            // panelPlayer3
            // 
            this.panelPlayer3.Controls.Add(this.lblPlayerName3);
            this.panelPlayer3.Controls.Add(this.txtPlayerName3);
            this.panelPlayer3.Controls.Add(this.chkAI3);
            this.panelPlayer3.Location = new System.Drawing.Point(26, 162);
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
            this.txtPlayerName3.TabIndex = 1;
            this.txtPlayerName3.Tag = "Player 3";
            // 
            // chkAI3
            // 
            this.chkAI3.AutoSize = true;
            this.chkAI3.Location = new System.Drawing.Point(127, 33);
            this.chkAI3.Name = "chkAI3";
            this.chkAI3.Size = new System.Drawing.Size(36, 17);
            this.chkAI3.TabIndex = 0;
            this.chkAI3.Text = "AI";
            this.chkAI3.UseVisualStyleBackColor = true;
            // 
            // panelPlayer4
            // 
            this.panelPlayer4.Controls.Add(this.lblPlayerName4);
            this.panelPlayer4.Controls.Add(this.txtPlayerName4);
            this.panelPlayer4.Controls.Add(this.chkAI4);
            this.panelPlayer4.Location = new System.Drawing.Point(26, 226);
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
            this.txtPlayerName4.TabIndex = 1;
            this.txtPlayerName4.Tag = "Player 4";
            // 
            // chkAI4
            // 
            this.chkAI4.AutoSize = true;
            this.chkAI4.Location = new System.Drawing.Point(127, 33);
            this.chkAI4.Name = "chkAI4";
            this.chkAI4.Size = new System.Drawing.Size(36, 17);
            this.chkAI4.TabIndex = 0;
            this.chkAI4.Text = "AI";
            this.chkAI4.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(26, 290);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(144, 290);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(91, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // GameOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 328);
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

        private System.Windows.Forms.ComboBox cmboNumPlayers;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.Label lblNumPlayer;
        private System.Windows.Forms.Label lblPlayerName1;
        private System.Windows.Forms.TextBox txtPlayer1Name;
        private System.Windows.Forms.CheckBox chkAI1;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.Label lblPlayerName2;
        private System.Windows.Forms.TextBox txtPlayerName2;
        private System.Windows.Forms.CheckBox chkAI2;
        private System.Windows.Forms.Panel panelPlayer3;
        private System.Windows.Forms.Label lblPlayerName3;
        private System.Windows.Forms.TextBox txtPlayerName3;
        private System.Windows.Forms.CheckBox chkAI3;
        private System.Windows.Forms.Panel panelPlayer4;
        private System.Windows.Forms.Label lblPlayerName4;
        private System.Windows.Forms.TextBox txtPlayerName4;
        private System.Windows.Forms.CheckBox chkAI4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnQuit;
    }
}
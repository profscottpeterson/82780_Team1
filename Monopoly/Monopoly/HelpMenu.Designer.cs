namespace Monopoly
{
    partial class HelpMenu
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
            this.lstOptions = new System.Windows.Forms.ListBox();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.lblLearn = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstOptions
            // 
            this.lstOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOptions.FormattingEnabled = true;
            this.lstOptions.ItemHeight = 20;
            this.lstOptions.Items.AddRange(new object[] {
            "Game Rules",
            "Game Setup",
            "Board Screen",
            "Trade Screen",
            "Trade Confirm Screen",
            "Upgrade Screen",
            "Sell Screen"});
            this.lstOptions.Location = new System.Drawing.Point(12, 33);
            this.lstOptions.Name = "lstOptions";
            this.lstOptions.Size = new System.Drawing.Size(182, 264);
            this.lstOptions.TabIndex = 0;
            this.lstOptions.SelectedIndexChanged += new System.EventHandler(this.LstOptions_SelectedIndexChanged);
            // 
            // rtbDesc
            // 
            this.rtbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDesc.Location = new System.Drawing.Point(200, 33);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            this.rtbDesc.Size = new System.Drawing.Size(392, 264);
            this.rtbDesc.TabIndex = 1;
            this.rtbDesc.Text = "";
            // 
            // lblLearn
            // 
            this.lblLearn.AutoSize = true;
            this.lblLearn.Location = new System.Drawing.Point(12, 17);
            this.lblLearn.Name = "lblLearn";
            this.lblLearn.Size = new System.Drawing.Size(99, 13);
            this.lblLearn.TabIndex = 2;
            this.lblLearn.Text = "Learn more about...";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(517, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // HelpMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 308);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lblLearn);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.lstOptions);
            this.Name = "HelpMenu";
            this.Text = "HelpMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstOptions;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.Label lblLearn;
        private System.Windows.Forms.Button BtnClose;
    }
}
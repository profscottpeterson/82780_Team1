namespace Monopoly
{
    partial class NonPropPopUp
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.AmtOwedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 53);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "label1";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(12, 85);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(35, 13);
            this.PriceLabel.TabIndex = 1;
            this.PriceLabel.Text = "label1";
            // 
            // AmtOwedLabel
            // 
            this.AmtOwedLabel.AutoSize = true;
            this.AmtOwedLabel.Location = new System.Drawing.Point(12, 115);
            this.AmtOwedLabel.Name = "AmtOwedLabel";
            this.AmtOwedLabel.Size = new System.Drawing.Size(35, 13);
            this.AmtOwedLabel.TabIndex = 2;
            this.AmtOwedLabel.Text = "label1";
            // 
            // NonPropPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AmtOwedLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "NonPropPopUp";
            this.Text = "NonPropPopUp";
            this.Load += new System.EventHandler(this.NonPropPopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label AmtOwedLabel;
    }
}
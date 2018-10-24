namespace Monopoly
{
    partial class MiscCardForm
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
            this.cardPictureBox = new System.Windows.Forms.PictureBox();
            this.cardTextLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Location = new System.Drawing.Point(182, 70);
            this.cardPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(218, 170);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cardPictureBox.TabIndex = 0;
            this.cardPictureBox.TabStop = false;
            // 
            // cardTextLabel
            // 
            this.cardTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardTextLabel.Location = new System.Drawing.Point(26, 22);
            this.cardTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardTextLabel.Name = "cardTextLabel";
            this.cardTextLabel.Size = new System.Drawing.Size(531, 23);
            this.cardTextLabel.TabIndex = 1;
            this.cardTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 278);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MiscCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 315);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cardTextLabel);
            this.Controls.Add(this.cardPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MiscCardForm";
            this.Text = "MiscCardForm";
            this.Load += new System.EventHandler(this.MiscCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cardPictureBox;
        private System.Windows.Forms.Label cardTextLabel;
        private System.Windows.Forms.Button button1;
    }
}
//-----------------------------------------------------------------------
// <copyright file="MiscCardForm.Designer.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    /// <summary>
    /// The MiscCardForm class
    /// </summary>
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.CardTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Location = new System.Drawing.Point(137, 74);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(164, 138);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cardPictureBox.TabIndex = 0;
            this.cardPictureBox.TabStop = false;
            // 
            // cardTextLabel
            // 
            this.cardTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardTextLabel.Location = new System.Drawing.Point(20, 40);
            this.cardTextLabel.Name = "cardTextLabel";
            this.cardTextLabel.Size = new System.Drawing.Size(398, 19);
            this.cardTextLabel.TabIndex = 1;
            this.cardTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(350, 248);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(86, 215);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(260, 55);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CardTypeLabel
            // 
            this.CardTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardTypeLabel.Location = new System.Drawing.Point(20, 7);
            this.CardTypeLabel.Name = "CardTypeLabel";
            this.CardTypeLabel.Size = new System.Drawing.Size(398, 32);
            this.CardTypeLabel.TabIndex = 4;
            this.CardTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiscCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 282);
            this.Controls.Add(this.CardTypeLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.cardTextLabel);
            this.Controls.Add(this.cardPictureBox);
            this.Name = "MiscCardForm";
            this.Load += new System.EventHandler(this.MiscCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cardPictureBox;
        private System.Windows.Forms.Label cardTextLabel;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label CardTypeLabel;
    }
}
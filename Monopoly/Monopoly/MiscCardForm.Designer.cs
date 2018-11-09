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
            this.cardPictureBox.Location = new System.Drawing.Point(183, 91);
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
            this.cardTextLabel.Location = new System.Drawing.Point(26, 49);
            this.cardTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardTextLabel.Name = "cardTextLabel";
            this.cardTextLabel.Size = new System.Drawing.Size(531, 23);
            this.cardTextLabel.TabIndex = 1;
            this.cardTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(467, 305);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(100, 28);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(114, 265);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(346, 68);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CardTypeLabel
            // 
            this.CardTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardTypeLabel.Location = new System.Drawing.Point(26, 9);
            this.CardTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CardTypeLabel.Name = "CardTypeLabel";
            this.CardTypeLabel.Size = new System.Drawing.Size(531, 40);
            this.CardTypeLabel.TabIndex = 4;
            this.CardTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MiscCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 347);
            this.Controls.Add(this.CardTypeLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.BtnClose);
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
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label CardTypeLabel;
    }
}
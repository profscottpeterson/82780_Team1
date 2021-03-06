﻿//-----------------------------------------------------------------------
// <copyright file="NonPropPopUp.Designer.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    /// <summary>
    /// The NonPropPopUp class
    /// </summary>
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
            this.MortgageLabel = new System.Windows.Forms.Label();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.IsMortgagedLabel = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.NumberOwnedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(-3, 3);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(246, 33);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PriceLabel
            // 
            this.PriceLabel.BackColor = System.Drawing.Color.White;
            this.PriceLabel.Location = new System.Drawing.Point(10, 40);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(218, 26);
            this.PriceLabel.TabIndex = 1;
            this.PriceLabel.Text = "Price";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmtOwedLabel
            // 
            this.AmtOwedLabel.BackColor = System.Drawing.Color.White;
            this.AmtOwedLabel.Location = new System.Drawing.Point(10, 67);
            this.AmtOwedLabel.Name = "AmtOwedLabel";
            this.AmtOwedLabel.Size = new System.Drawing.Size(218, 62);
            this.AmtOwedLabel.TabIndex = 2;
            this.AmtOwedLabel.Text = "Rent";
            this.AmtOwedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MortgageLabel
            // 
            this.MortgageLabel.BackColor = System.Drawing.Color.White;
            this.MortgageLabel.Location = new System.Drawing.Point(10, 128);
            this.MortgageLabel.Name = "MortgageLabel";
            this.MortgageLabel.Size = new System.Drawing.Size(218, 26);
            this.MortgageLabel.TabIndex = 3;
            this.MortgageLabel.Text = "Mortgage";
            this.MortgageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.BackColor = System.Drawing.Color.White;
            this.OwnerLabel.Location = new System.Drawing.Point(10, 154);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(218, 24);
            this.OwnerLabel.TabIndex = 19;
            this.OwnerLabel.Text = "Owner";
            this.OwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IsMortgagedLabel
            // 
            this.IsMortgagedLabel.BackColor = System.Drawing.Color.White;
            this.IsMortgagedLabel.Location = new System.Drawing.Point(10, 179);
            this.IsMortgagedLabel.Name = "IsMortgagedLabel";
            this.IsMortgagedLabel.Size = new System.Drawing.Size(218, 24);
            this.IsMortgagedLabel.TabIndex = 18;
            this.IsMortgagedLabel.Text = "IsMortgaged";
            this.IsMortgagedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(80, 232);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 24);
            this.BtnClose.TabIndex = 20;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // NumberOwnedLabel
            // 
            this.NumberOwnedLabel.BackColor = System.Drawing.Color.White;
            this.NumberOwnedLabel.Location = new System.Drawing.Point(10, 204);
            this.NumberOwnedLabel.Name = "NumberOwnedLabel";
            this.NumberOwnedLabel.Size = new System.Drawing.Size(218, 24);
            this.NumberOwnedLabel.TabIndex = 21;
            this.NumberOwnedLabel.Text = "NumberOwned";
            this.NumberOwnedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NonPropPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(235, 264);
            this.Controls.Add(this.NumberOwnedLabel);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.OwnerLabel);
            this.Controls.Add(this.IsMortgagedLabel);
            this.Controls.Add(this.MortgageLabel);
            this.Controls.Add(this.AmtOwedLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "NonPropPopUp";
            this.Load += new System.EventHandler(this.NonPropPopUp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label AmtOwedLabel;
        private System.Windows.Forms.Label MortgageLabel;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.Label IsMortgagedLabel;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label NumberOwnedLabel;
    }
}
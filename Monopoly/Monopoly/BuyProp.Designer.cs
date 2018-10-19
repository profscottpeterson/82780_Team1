//-----------------------------------------------------------------------
// <copyright file="BuyProp.Designer.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    /// <summary>
    /// The designer class for the form buy Prop
    /// </summary>
    public partial class BuyProp
    {

        /// <summary>
        /// Price for card
        /// </summary>
        private System.Windows.Forms.Label priceLabel;

        /// <summary>
        /// Mortgage label
        /// </summary>
        private System.Windows.Forms.Label mortgageLabel;

        /// <summary>
        /// Regular rent without house or hotel
        /// </summary>
        private System.Windows.Forms.Label rentLabel;

        /// <summary>
        /// The name of the spot
        /// </summary>
        private System.Windows.Forms.Label spotNameLabel;

        /// <summary>
        /// A question
        /// </summary>
        private System.Windows.Forms.Panel pnlQuestion;

        /// <summary>
        /// Yes button
        /// </summary>
        private System.Windows.Forms.Button btnYes;

        /// <summary>
        /// No button
        /// </summary>
        private System.Windows.Forms.Button btnNo;

        /// <summary>
        /// Label with question
        /// </summary>
        private System.Windows.Forms.Label lblQuestion;

        /// <summary>
        /// How much money you have
        /// </summary>
        private System.Windows.Forms.Label lblYourMoney;

        /// <summary>
        /// IDK another label with your money
        /// </summary>
        private System.Windows.Forms.Label lblYourMoneyText;

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
            this.priceLabel = new System.Windows.Forms.Label();
            this.mortgageLabel = new System.Windows.Forms.Label();
            this.rentLabel = new System.Windows.Forms.Label();
            this.spotNameLabel = new System.Windows.Forms.Label();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.lblYourMoney = new System.Windows.Forms.Label();
            this.lblYourMoneyText = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pnlQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // priceLabel
            // 
            this.priceLabel.BackColor = System.Drawing.SystemColors.Control;
            this.priceLabel.Location = new System.Drawing.Point(16, 52);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(334, 21);
            this.priceLabel.TabIndex = 19;
            this.priceLabel.Text = "Price";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mortgageLabel
            // 
            this.mortgageLabel.BackColor = System.Drawing.SystemColors.Control;
            this.mortgageLabel.Location = new System.Drawing.Point(11, 75);
            this.mortgageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mortgageLabel.Name = "mortgageLabel";
            this.mortgageLabel.Size = new System.Drawing.Size(339, 21);
            this.mortgageLabel.TabIndex = 16;
            this.mortgageLabel.Text = "Mortgage";
            this.mortgageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rentLabel
            // 
            this.rentLabel.BackColor = System.Drawing.SystemColors.Control;
            this.rentLabel.Location = new System.Drawing.Point(16, 100);
            this.rentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rentLabel.Name = "rentLabel";
            this.rentLabel.Size = new System.Drawing.Size(331, 107);
            this.rentLabel.TabIndex = 14;
            this.rentLabel.Text = "Rent";
            this.rentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spotNameLabel
            // 
            this.spotNameLabel.BackColor = System.Drawing.Color.White;
            this.spotNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spotNameLabel.Location = new System.Drawing.Point(-1, -2);
            this.spotNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spotNameLabel.Name = "spotNameLabel";
            this.spotNameLabel.Size = new System.Drawing.Size(372, 49);
            this.spotNameLabel.TabIndex = 13;
            this.spotNameLabel.Text = "Name";
            this.spotNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlQuestion
            // 
            this.pnlQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuestion.Controls.Add(this.lblYourMoney);
            this.pnlQuestion.Controls.Add(this.lblYourMoneyText);
            this.pnlQuestion.Controls.Add(this.btnYes);
            this.pnlQuestion.Controls.Add(this.btnNo);
            this.pnlQuestion.Controls.Add(this.lblQuestion);
            this.pnlQuestion.Location = new System.Drawing.Point(13, 217);
            this.pnlQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(334, 192);
            this.pnlQuestion.TabIndex = 23;
            // 
            // lblYourMoney
            // 
            this.lblYourMoney.AutoSize = true;
            this.lblYourMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourMoney.Location = new System.Drawing.Point(160, 89);
            this.lblYourMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYourMoney.Name = "lblYourMoney";
            this.lblYourMoney.Size = new System.Drawing.Size(72, 25);
            this.lblYourMoney.TabIndex = 27;
            this.lblYourMoney.Text = "Money";
            // 
            // lblYourMoneyText
            // 
            this.lblYourMoneyText.AutoSize = true;
            this.lblYourMoneyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourMoneyText.Location = new System.Drawing.Point(16, 89);
            this.lblYourMoneyText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYourMoneyText.Name = "lblYourMoneyText";
            this.lblYourMoneyText.Size = new System.Drawing.Size(129, 25);
            this.lblYourMoneyText.TabIndex = 26;
            this.lblYourMoneyText.Text = "Your Money: ";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(21, 142);
            this.btnYes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 28);
            this.btnYes.TabIndex = 24;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(212, 142);
            this.btnNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 28);
            this.btnNo.TabIndex = 25;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(16, 14);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(252, 50);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Would you like to purchase \r\nthis property?";
            // 
            // BuyProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 423);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.mortgageLabel);
            this.Controls.Add(this.rentLabel);
            this.Controls.Add(this.spotNameLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BuyProp";
            this.Text = "BuyProp";
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
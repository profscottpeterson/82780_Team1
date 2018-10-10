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
        /// The cards color picture box
        /// </summary>
        private System.Windows.Forms.PictureBox colorPicBox;

        /// <summary>
        /// Rent with 3 houses
        /// </summary>
        private System.Windows.Forms.Label rent3Label;

        /// <summary>
        /// Rent with 1 house
        /// </summary>
        private System.Windows.Forms.Label rent1Label;

        /// <summary>
        /// Price for card
        /// </summary>
        private System.Windows.Forms.Label priceLabel;

        /// <summary>
        /// Rent with a hotel
        /// </summary>
        private System.Windows.Forms.Label rentHotelLabel;

        /// <summary>
        /// Rent with 4 houses
        /// </summary>
        private System.Windows.Forms.Label rent4Label;

        /// <summary>
        /// Mortgage label
        /// </summary>
        private System.Windows.Forms.Label mortgageLabel;

        /// <summary>
        /// Rent with 2 houses
        /// </summary>
        private System.Windows.Forms.Label rent2Label;

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
            this.colorPicBox = new System.Windows.Forms.PictureBox();
            this.rent3Label = new System.Windows.Forms.Label();
            this.rent1Label = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.rentHotelLabel = new System.Windows.Forms.Label();
            this.rent4Label = new System.Windows.Forms.Label();
            this.mortgageLabel = new System.Windows.Forms.Label();
            this.rent2Label = new System.Windows.Forms.Label();
            this.rentLabel = new System.Windows.Forms.Label();
            this.spotNameLabel = new System.Windows.Forms.Label();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblYourMoneyText = new System.Windows.Forms.Label();
            this.lblYourMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicBox)).BeginInit();
            this.pnlQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorPicBox
            // 
            this.colorPicBox.Location = new System.Drawing.Point(12, 12);
            this.colorPicBox.Name = "colorPicBox";
            this.colorPicBox.Size = new System.Drawing.Size(251, 35);
            this.colorPicBox.TabIndex = 22;
            this.colorPicBox.TabStop = false;
            // 
            // rent3Label
            // 
            this.rent3Label.AutoSize = true;
            this.rent3Label.Location = new System.Drawing.Point(9, 188);
            this.rent3Label.Name = "rent3Label";
            this.rent3Label.Size = new System.Drawing.Size(41, 13);
            this.rent3Label.TabIndex = 21;
            this.rent3Label.Text = "label12";
            // 
            // rent1Label
            // 
            this.rent1Label.AutoSize = true;
            this.rent1Label.Location = new System.Drawing.Point(9, 130);
            this.rent1Label.Name = "rent1Label";
            this.rent1Label.Size = new System.Drawing.Size(41, 13);
            this.rent1Label.TabIndex = 20;
            this.rent1Label.Text = "label11";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(9, 73);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(41, 13);
            this.priceLabel.TabIndex = 19;
            this.priceLabel.Text = "label10";
            // 
            // rentHotelLabel
            // 
            this.rentHotelLabel.AutoSize = true;
            this.rentHotelLabel.Location = new System.Drawing.Point(113, 50);
            this.rentHotelLabel.Name = "rentHotelLabel";
            this.rentHotelLabel.Size = new System.Drawing.Size(35, 13);
            this.rentHotelLabel.TabIndex = 18;
            this.rentHotelLabel.Text = "label6";
            // 
            // rent4Label
            // 
            this.rent4Label.AutoSize = true;
            this.rent4Label.Location = new System.Drawing.Point(9, 211);
            this.rent4Label.Name = "rent4Label";
            this.rent4Label.Size = new System.Drawing.Size(35, 13);
            this.rent4Label.TabIndex = 17;
            this.rent4Label.Text = "label5";
            // 
            // mortgageLabel
            // 
            this.mortgageLabel.AutoSize = true;
            this.mortgageLabel.Location = new System.Drawing.Point(113, 73);
            this.mortgageLabel.Name = "mortgageLabel";
            this.mortgageLabel.Size = new System.Drawing.Size(35, 13);
            this.mortgageLabel.TabIndex = 16;
            this.mortgageLabel.Text = "label4";
            // 
            // rent2Label
            // 
            this.rent2Label.AutoSize = true;
            this.rent2Label.Location = new System.Drawing.Point(9, 163);
            this.rent2Label.Name = "rent2Label";
            this.rent2Label.Size = new System.Drawing.Size(35, 13);
            this.rent2Label.TabIndex = 15;
            this.rent2Label.Text = "label3";
            // 
            // rentLabel
            // 
            this.rentLabel.AutoSize = true;
            this.rentLabel.Location = new System.Drawing.Point(9, 96);
            this.rentLabel.Name = "rentLabel";
            this.rentLabel.Size = new System.Drawing.Size(35, 13);
            this.rentLabel.TabIndex = 14;
            this.rentLabel.Text = "label2";
            // 
            // spotNameLabel
            // 
            this.spotNameLabel.AutoSize = true;
            this.spotNameLabel.Location = new System.Drawing.Point(9, 50);
            this.spotNameLabel.Name = "spotNameLabel";
            this.spotNameLabel.Size = new System.Drawing.Size(35, 13);
            this.spotNameLabel.TabIndex = 13;
            this.spotNameLabel.Text = "label1";
            // 
            // pnlQuestion
            // 
            this.pnlQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuestion.Controls.Add(this.lblYourMoney);
            this.pnlQuestion.Controls.Add(this.lblYourMoneyText);
            this.pnlQuestion.Controls.Add(this.btnYes);
            this.pnlQuestion.Controls.Add(this.btnNo);
            this.pnlQuestion.Controls.Add(this.lblQuestion);
            this.pnlQuestion.Location = new System.Drawing.Point(12, 232);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(251, 156);
            this.pnlQuestion.TabIndex = 23;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(12, 11);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(202, 40);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Would you like to purchase \r\nthis property?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(16, 115);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 24;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(159, 115);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 25;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // lblYourMoneyText
            // 
            this.lblYourMoneyText.AutoSize = true;
            this.lblYourMoneyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourMoneyText.Location = new System.Drawing.Point(12, 72);
            this.lblYourMoneyText.Name = "lblYourMoneyText";
            this.lblYourMoneyText.Size = new System.Drawing.Size(102, 20);
            this.lblYourMoneyText.TabIndex = 26;
            this.lblYourMoneyText.Text = "Your Money: ";
            // 
            // lblYourMoney
            // 
            this.lblYourMoney.AutoSize = true;
            this.lblYourMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourMoney.Location = new System.Drawing.Point(120, 72);
            this.lblYourMoney.Name = "lblYourMoney";
            this.lblYourMoney.Size = new System.Drawing.Size(56, 20);
            this.lblYourMoney.TabIndex = 27;
            this.lblYourMoney.Text = "Money";
            // 
            // BuyProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 405);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.colorPicBox);
            this.Controls.Add(this.rent3Label);
            this.Controls.Add(this.rent1Label);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.rentHotelLabel);
            this.Controls.Add(this.rent4Label);
            this.Controls.Add(this.mortgageLabel);
            this.Controls.Add(this.rent2Label);
            this.Controls.Add(this.rentLabel);
            this.Controls.Add(this.spotNameLabel);
            this.Name = "BuyProp";
            this.Text = "BuyProp";
            ((System.ComponentModel.ISupportInitialize)(this.colorPicBox)).EndInit();
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
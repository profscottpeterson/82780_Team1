//-----------------------------------------------------------------------
// <copyright file="GetMoney.Designer.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    /// <summary>
    /// The GetMoney class
    /// </summary>
    partial class GetMoney
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
            this.listViewProperties = new System.Windows.Forms.ListView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblDebt = new System.Windows.Forms.Label();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblDivider = new System.Windows.Forms.Label();
            this.lblDebtCurrent = new System.Windows.Forms.Label();
            this.btnSellHouse = new System.Windows.Forms.Button();
            this.btnSellHotel = new System.Windows.Forms.Button();
            this.btnMortage = new System.Windows.Forms.Button();
            this.lblPropertyText = new System.Windows.Forms.Label();
            this.lblPropertyName = new System.Windows.Forms.Label();
            this.lblMoneyGainFromHouse = new System.Windows.Forms.Label();
            this.lblMoneyGainFromHotel = new System.Windows.Forms.Label();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPlayerNameText = new System.Windows.Forms.Label();
            this.lblMoneyText = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.btnForfeit = new System.Windows.Forms.Button();
            this.BtnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewProperties
            // 
            this.listViewProperties.Location = new System.Drawing.Point(11, 177);
            this.listViewProperties.Margin = new System.Windows.Forms.Padding(2);
            this.listViewProperties.MultiSelect = false;
            this.listViewProperties.Name = "listViewProperties";
            this.listViewProperties.Size = new System.Drawing.Size(352, 262);
            this.listViewProperties.TabIndex = 24;
            this.listViewProperties.UseCompatibleStateImageBehavior = false;
            this.listViewProperties.View = System.Windows.Forms.View.Details;
            this.listViewProperties.Click += new System.EventHandler(this.ListViewProperties_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(473, 20);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(56, 23);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.Text = "Close";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // lblDebt
            // 
            this.lblDebt.AutoSize = true;
            this.lblDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebt.Location = new System.Drawing.Point(12, 9);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(93, 37);
            this.lblDebt.TabIndex = 26;
            this.lblDebt.Text = "Debt:";
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebt.Location = new System.Drawing.Point(111, 9);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(89, 37);
            this.lblTotalDebt.TabIndex = 27;
            this.lblTotalDebt.Text = "Total";
            // 
            // lblDivider
            // 
            this.lblDivider.AutoSize = true;
            this.lblDivider.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider.Location = new System.Drawing.Point(206, 9);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(55, 37);
            this.lblDivider.TabIndex = 28;
            this.lblDivider.Text = "- >";
            // 
            // lblDebtCurrent
            // 
            this.lblDebtCurrent.AutoSize = true;
            this.lblDebtCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebtCurrent.Location = new System.Drawing.Point(267, 9);
            this.lblDebtCurrent.Name = "lblDebtCurrent";
            this.lblDebtCurrent.Size = new System.Drawing.Size(124, 37);
            this.lblDebtCurrent.TabIndex = 29;
            this.lblDebtCurrent.Text = "Current";
            // 
            // btnSellHouse
            // 
            this.btnSellHouse.Enabled = false;
            this.btnSellHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellHouse.Location = new System.Drawing.Point(384, 216);
            this.btnSellHouse.Name = "btnSellHouse";
            this.btnSellHouse.Size = new System.Drawing.Size(139, 32);
            this.btnSellHouse.TabIndex = 34;
            this.btnSellHouse.Text = "Sell House";
            this.btnSellHouse.UseVisualStyleBackColor = true;
            this.btnSellHouse.Click += new System.EventHandler(this.BtnSellHouse_Click);
            // 
            // btnSellHotel
            // 
            this.btnSellHotel.Enabled = false;
            this.btnSellHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellHotel.Location = new System.Drawing.Point(384, 301);
            this.btnSellHotel.Name = "btnSellHotel";
            this.btnSellHotel.Size = new System.Drawing.Size(139, 32);
            this.btnSellHotel.TabIndex = 40;
            this.btnSellHotel.Text = "Sell Hotel";
            this.btnSellHotel.UseVisualStyleBackColor = true;
            this.btnSellHotel.Click += new System.EventHandler(this.BtnSellHotel_Click);
            // 
            // btnMortage
            // 
            this.btnMortage.Enabled = false;
            this.btnMortage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMortage.Location = new System.Drawing.Point(384, 393);
            this.btnMortage.Name = "btnMortage";
            this.btnMortage.Size = new System.Drawing.Size(206, 34);
            this.btnMortage.TabIndex = 43;
            this.btnMortage.Text = "Mortgage Property";
            this.btnMortage.UseVisualStyleBackColor = true;
            this.btnMortage.Click += new System.EventHandler(this.BtnMortgage_Click);
            // 
            // lblPropertyText
            // 
            this.lblPropertyText.AutoSize = true;
            this.lblPropertyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyText.Location = new System.Drawing.Point(12, 110);
            this.lblPropertyText.Name = "lblPropertyText";
            this.lblPropertyText.Size = new System.Drawing.Size(100, 26);
            this.lblPropertyText.TabIndex = 45;
            this.lblPropertyText.Text = "Property:";
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.AutoSize = true;
            this.lblPropertyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyName.Location = new System.Drawing.Point(12, 136);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(193, 26);
            this.lblPropertyName.TabIndex = 46;
            this.lblPropertyName.Text = "Choose a Property";
            // 
            // lblMoneyGainFromHouse
            // 
            this.lblMoneyGainFromHouse.AutoSize = true;
            this.lblMoneyGainFromHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyGainFromHouse.Location = new System.Drawing.Point(529, 220);
            this.lblMoneyGainFromHouse.Name = "lblMoneyGainFromHouse";
            this.lblMoneyGainFromHouse.Size = new System.Drawing.Size(67, 26);
            this.lblMoneyGainFromHouse.TabIndex = 47;
            this.lblMoneyGainFromHouse.Text = "[num]";
            // 
            // lblMoneyGainFromHotel
            // 
            this.lblMoneyGainFromHotel.AutoSize = true;
            this.lblMoneyGainFromHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyGainFromHotel.Location = new System.Drawing.Point(529, 305);
            this.lblMoneyGainFromHotel.Name = "lblMoneyGainFromHotel";
            this.lblMoneyGainFromHotel.Size = new System.Drawing.Size(67, 26);
            this.lblMoneyGainFromHotel.TabIndex = 48;
            this.lblMoneyGainFromHotel.Text = "[num]";
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(365, 50);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrors.Size = new System.Drawing.Size(226, 115);
            this.txtErrors.TabIndex = 49;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(165, 47);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(74, 26);
            this.lblPlayerName.TabIndex = 50;
            this.lblPlayerName.Text = "Player";
            // 
            // lblPlayerNameText
            // 
            this.lblPlayerNameText.AutoSize = true;
            this.lblPlayerNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerNameText.Location = new System.Drawing.Point(14, 47);
            this.lblPlayerNameText.Name = "lblPlayerNameText";
            this.lblPlayerNameText.Size = new System.Drawing.Size(145, 26);
            this.lblPlayerNameText.TabIndex = 51;
            this.lblPlayerNameText.Text = "Player Name:";
            // 
            // lblMoneyText
            // 
            this.lblMoneyText.AutoSize = true;
            this.lblMoneyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyText.Location = new System.Drawing.Point(14, 77);
            this.lblMoneyText.Name = "lblMoneyText";
            this.lblMoneyText.Size = new System.Drawing.Size(83, 26);
            this.lblMoneyText.TabIndex = 53;
            this.lblMoneyText.Text = "Money:";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.Location = new System.Drawing.Point(103, 77);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(77, 26);
            this.lblMoney.TabIndex = 52;
            this.lblMoney.Text = "Money";
            // 
            // btnForfeit
            // 
            this.btnForfeit.Location = new System.Drawing.Point(536, 20);
            this.btnForfeit.Name = "btnForfeit";
            this.btnForfeit.Size = new System.Drawing.Size(56, 23);
            this.btnForfeit.TabIndex = 54;
            this.btnForfeit.Text = "Forfeit";
            this.btnForfeit.UseVisualStyleBackColor = true;
            this.btnForfeit.Click += new System.EventHandler(this.BtnForfeit_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.Location = new System.Drawing.Point(444, 20);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(23, 23);
            this.BtnHelp.TabIndex = 55;
            this.BtnHelp.Text = "?";
            this.BtnHelp.UseVisualStyleBackColor = true;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // GetMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.btnForfeit);
            this.Controls.Add(this.lblMoneyText);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.lblPlayerNameText);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.lblMoneyGainFromHotel);
            this.Controls.Add(this.lblMoneyGainFromHouse);
            this.Controls.Add(this.lblPropertyName);
            this.Controls.Add(this.lblPropertyText);
            this.Controls.Add(this.btnMortage);
            this.Controls.Add(this.btnSellHotel);
            this.Controls.Add(this.btnSellHouse);
            this.Controls.Add(this.lblDebtCurrent);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.lblTotalDebt);
            this.Controls.Add(this.lblDebt);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.listViewProperties);
            this.Name = "GetMoney";
            this.Text = "Sell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewProperties;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblDebt;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Label lblDebtCurrent;
        private System.Windows.Forms.Button btnSellHouse;
        private System.Windows.Forms.Button btnSellHotel;
        private System.Windows.Forms.Button btnMortage;
        private System.Windows.Forms.Label lblPropertyText;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.Label lblMoneyGainFromHouse;
        private System.Windows.Forms.Label lblMoneyGainFromHotel;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPlayerNameText;
        private System.Windows.Forms.Label lblMoneyText;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Button btnForfeit;
        private System.Windows.Forms.Button BtnHelp;
    }
}
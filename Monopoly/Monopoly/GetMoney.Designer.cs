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
            this.SuspendLayout();
            // 
            // listViewProperties
            // 
            this.listViewProperties.Location = new System.Drawing.Point(15, 218);
            this.listViewProperties.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewProperties.MultiSelect = false;
            this.listViewProperties.Name = "listViewProperties";
            this.listViewProperties.Size = new System.Drawing.Size(468, 322);
            this.listViewProperties.TabIndex = 24;
            this.listViewProperties.UseCompatibleStateImageBehavior = false;
            this.listViewProperties.View = System.Windows.Forms.View.Details;
            this.listViewProperties.Click += new System.EventHandler(this.ListViewProperties_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(631, 25);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 28);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.Text = "Close";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // lblDebt
            // 
            this.lblDebt.AutoSize = true;
            this.lblDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebt.Location = new System.Drawing.Point(16, 11);
            this.lblDebt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(115, 46);
            this.lblDebt.TabIndex = 26;
            this.lblDebt.Text = "Debt:";
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebt.Location = new System.Drawing.Point(148, 11);
            this.lblTotalDebt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(109, 46);
            this.lblTotalDebt.TabIndex = 27;
            this.lblTotalDebt.Text = "Total";
            // 
            // lblDivider
            // 
            this.lblDivider.AutoSize = true;
            this.lblDivider.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider.Location = new System.Drawing.Point(275, 11);
            this.lblDivider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(67, 46);
            this.lblDivider.TabIndex = 28;
            this.lblDivider.Text = "- >";
            // 
            // lblDebtCurrent
            // 
            this.lblDebtCurrent.AutoSize = true;
            this.lblDebtCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebtCurrent.Location = new System.Drawing.Point(356, 11);
            this.lblDebtCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebtCurrent.Name = "lblDebtCurrent";
            this.lblDebtCurrent.Size = new System.Drawing.Size(152, 46);
            this.lblDebtCurrent.TabIndex = 29;
            this.lblDebtCurrent.Text = "Current";
            // 
            // btnSellHouse
            // 
            this.btnSellHouse.Enabled = false;
            this.btnSellHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellHouse.Location = new System.Drawing.Point(512, 266);
            this.btnSellHouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSellHouse.Name = "btnSellHouse";
            this.btnSellHouse.Size = new System.Drawing.Size(185, 39);
            this.btnSellHouse.TabIndex = 34;
            this.btnSellHouse.Text = "Sell House";
            this.btnSellHouse.UseVisualStyleBackColor = true;
            this.btnSellHouse.Click += new System.EventHandler(this.BtnSellHouse_Click);
            // 
            // btnSellHotel
            // 
            this.btnSellHotel.Enabled = false;
            this.btnSellHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellHotel.Location = new System.Drawing.Point(512, 370);
            this.btnSellHotel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSellHotel.Name = "btnSellHotel";
            this.btnSellHotel.Size = new System.Drawing.Size(185, 39);
            this.btnSellHotel.TabIndex = 40;
            this.btnSellHotel.Text = "Sell Hotel";
            this.btnSellHotel.UseVisualStyleBackColor = true;
            this.btnSellHotel.Click += new System.EventHandler(this.BtnSellHotel_Click);
            // 
            // btnMortage
            // 
            this.btnMortage.Enabled = false;
            this.btnMortage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMortage.Location = new System.Drawing.Point(512, 484);
            this.btnMortage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMortage.Name = "btnMortage";
            this.btnMortage.Size = new System.Drawing.Size(275, 42);
            this.btnMortage.TabIndex = 43;
            this.btnMortage.Text = "Mortgage Property";
            this.btnMortage.UseVisualStyleBackColor = true;
            this.btnMortage.Click += new System.EventHandler(this.BtnMortgage_Click);
            // 
            // lblPropertyText
            // 
            this.lblPropertyText.AutoSize = true;
            this.lblPropertyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyText.Location = new System.Drawing.Point(16, 135);
            this.lblPropertyText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPropertyText.Name = "lblPropertyText";
            this.lblPropertyText.Size = new System.Drawing.Size(125, 31);
            this.lblPropertyText.TabIndex = 45;
            this.lblPropertyText.Text = "Property:";
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.AutoSize = true;
            this.lblPropertyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyName.Location = new System.Drawing.Point(16, 167);
            this.lblPropertyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(240, 31);
            this.lblPropertyName.TabIndex = 46;
            this.lblPropertyName.Text = "Choose a Property";
            // 
            // lblMoneyGainFromHouse
            // 
            this.lblMoneyGainFromHouse.AutoSize = true;
            this.lblMoneyGainFromHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyGainFromHouse.Location = new System.Drawing.Point(705, 271);
            this.lblMoneyGainFromHouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoneyGainFromHouse.Name = "lblMoneyGainFromHouse";
            this.lblMoneyGainFromHouse.Size = new System.Drawing.Size(82, 31);
            this.lblMoneyGainFromHouse.TabIndex = 47;
            this.lblMoneyGainFromHouse.Text = "[num]";
            // 
            // lblMoneyGainFromHotel
            // 
            this.lblMoneyGainFromHotel.AutoSize = true;
            this.lblMoneyGainFromHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyGainFromHotel.Location = new System.Drawing.Point(705, 375);
            this.lblMoneyGainFromHotel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoneyGainFromHotel.Name = "lblMoneyGainFromHotel";
            this.lblMoneyGainFromHotel.Size = new System.Drawing.Size(82, 31);
            this.lblMoneyGainFromHotel.TabIndex = 48;
            this.lblMoneyGainFromHotel.Text = "[num]";
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(487, 61);
            this.txtErrors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrors.Size = new System.Drawing.Size(300, 141);
            this.txtErrors.TabIndex = 49;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(220, 58);
            this.lblPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(91, 31);
            this.lblPlayerName.TabIndex = 50;
            this.lblPlayerName.Text = "Player";
            // 
            // lblPlayerNameText
            // 
            this.lblPlayerNameText.AutoSize = true;
            this.lblPlayerNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerNameText.Location = new System.Drawing.Point(19, 58);
            this.lblPlayerNameText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayerNameText.Name = "lblPlayerNameText";
            this.lblPlayerNameText.Size = new System.Drawing.Size(178, 31);
            this.lblPlayerNameText.TabIndex = 51;
            this.lblPlayerNameText.Text = "Player Name:";
            // 
            // lblMoneyText
            // 
            this.lblMoneyText.AutoSize = true;
            this.lblMoneyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyText.Location = new System.Drawing.Point(19, 95);
            this.lblMoneyText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoneyText.Name = "lblMoneyText";
            this.lblMoneyText.Size = new System.Drawing.Size(103, 31);
            this.lblMoneyText.TabIndex = 53;
            this.lblMoneyText.Text = "Money:";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.Location = new System.Drawing.Point(137, 95);
            this.lblMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(95, 31);
            this.lblMoney.TabIndex = 52;
            this.lblMoney.Text = "Money";
            // 
            // btnForfeit
            // 
            this.btnForfeit.Location = new System.Drawing.Point(714, 25);
            this.btnForfeit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnForfeit.Name = "btnForfeit";
            this.btnForfeit.Size = new System.Drawing.Size(75, 28);
            this.btnForfeit.TabIndex = 54;
            this.btnForfeit.Text = "Forfeit";
            this.btnForfeit.UseVisualStyleBackColor = true;
            this.btnForfeit.Click += new System.EventHandler(this.BtnForfeit_Click);
            // 
            // GetMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 554);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GetMoney";
            this.Text = "GetMoney";
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
    }
}
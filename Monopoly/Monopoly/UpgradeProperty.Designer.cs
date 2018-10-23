namespace Monopoly
{
    partial class UpgradeProperty
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
            this.btnClose = new System.Windows.Forms.Button();
            this.listViewProperties = new System.Windows.Forms.ListView();
            this.lblPropEligible = new System.Windows.Forms.Label();
            this.btnAddHouseToAll = new System.Windows.Forms.Button();
            this.btnAddHouse = new System.Windows.Forms.Button();
            this.btnAddHotel = new System.Windows.Forms.Button();
            this.btnAddHotelToAll = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblMoneyTotal = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPlayerText = new System.Windows.Forms.Label();
            this.lblPropertyName = new System.Windows.Forms.Label();
            this.lblPropertyDesc = new System.Windows.Forms.Label();
            this.btnUnmortgage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(11, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(465, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listViewProperties
            // 
            this.listViewProperties.Location = new System.Drawing.Point(11, 116);
            this.listViewProperties.Margin = new System.Windows.Forms.Padding(2);
            this.listViewProperties.MultiSelect = false;
            this.listViewProperties.Name = "listViewProperties";
            this.listViewProperties.Size = new System.Drawing.Size(260, 323);
            this.listViewProperties.TabIndex = 24;
            this.listViewProperties.UseCompatibleStateImageBehavior = false;
            this.listViewProperties.View = System.Windows.Forms.View.Details;
            this.listViewProperties.Click += new System.EventHandler(this.listViewProperties_Click);
            // 
            // lblPropEligible
            // 
            this.lblPropEligible.AutoSize = true;
            this.lblPropEligible.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropEligible.Location = new System.Drawing.Point(14, 11);
            this.lblPropEligible.Name = "lblPropEligible";
            this.lblPropEligible.Size = new System.Drawing.Size(463, 37);
            this.lblPropEligible.TabIndex = 25;
            this.lblPropEligible.Text = "Properties Eligible For Upgrade";
            // 
            // btnAddHouseToAll
            // 
            this.btnAddHouseToAll.Enabled = false;
            this.btnAddHouseToAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHouseToAll.Location = new System.Drawing.Point(276, 165);
            this.btnAddHouseToAll.Name = "btnAddHouseToAll";
            this.btnAddHouseToAll.Size = new System.Drawing.Size(200, 43);
            this.btnAddHouseToAll.TabIndex = 26;
            this.btnAddHouseToAll.Text = "Add House To All";
            this.btnAddHouseToAll.UseVisualStyleBackColor = true;
            this.btnAddHouseToAll.Click += new System.EventHandler(this.btnAddHouseToAll_Click);
            // 
            // btnAddHouse
            // 
            this.btnAddHouse.Enabled = false;
            this.btnAddHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHouse.Location = new System.Drawing.Point(276, 116);
            this.btnAddHouse.Name = "btnAddHouse";
            this.btnAddHouse.Size = new System.Drawing.Size(200, 43);
            this.btnAddHouse.TabIndex = 27;
            this.btnAddHouse.Text = "Add House";
            this.btnAddHouse.UseVisualStyleBackColor = true;
            this.btnAddHouse.Click += new System.EventHandler(this.btnAddHouse_Click);
            // 
            // btnAddHotel
            // 
            this.btnAddHotel.Enabled = false;
            this.btnAddHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHotel.Location = new System.Drawing.Point(276, 214);
            this.btnAddHotel.Name = "btnAddHotel";
            this.btnAddHotel.Size = new System.Drawing.Size(200, 43);
            this.btnAddHotel.TabIndex = 28;
            this.btnAddHotel.Text = "Add Hotel";
            this.btnAddHotel.UseVisualStyleBackColor = true;
            this.btnAddHotel.Click += new System.EventHandler(this.btnAddHotel_Click);
            // 
            // btnAddHotelToAll
            // 
            this.btnAddHotelToAll.Enabled = false;
            this.btnAddHotelToAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHotelToAll.Location = new System.Drawing.Point(276, 263);
            this.btnAddHotelToAll.Name = "btnAddHotelToAll";
            this.btnAddHotelToAll.Size = new System.Drawing.Size(200, 43);
            this.btnAddHotelToAll.TabIndex = 29;
            this.btnAddHotelToAll.Text = "Add Hotel To All";
            this.btnAddHotelToAll.UseVisualStyleBackColor = true;
            this.btnAddHotelToAll.Click += new System.EventHandler(this.btnAddHotelToAll_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(276, 361);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(200, 78);
            this.txtMessage.TabIndex = 30;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.Location = new System.Drawing.Point(12, 81);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(83, 26);
            this.lblMoney.TabIndex = 31;
            this.lblMoney.Text = "Money:";
            // 
            // lblMoneyTotal
            // 
            this.lblMoneyTotal.AutoSize = true;
            this.lblMoneyTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyTotal.Location = new System.Drawing.Point(101, 81);
            this.lblMoneyTotal.Name = "lblMoneyTotal";
            this.lblMoneyTotal.Size = new System.Drawing.Size(55, 26);
            this.lblMoneyTotal.TabIndex = 32;
            this.lblMoneyTotal.Text = "num";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(101, 55);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(67, 26);
            this.lblPlayerName.TabIndex = 34;
            this.lblPlayerName.Text = "name";
            // 
            // lblPlayerText
            // 
            this.lblPlayerText.AutoSize = true;
            this.lblPlayerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerText.Location = new System.Drawing.Point(15, 55);
            this.lblPlayerText.Name = "lblPlayerText";
            this.lblPlayerText.Size = new System.Drawing.Size(80, 26);
            this.lblPlayerText.TabIndex = 33;
            this.lblPlayerText.Text = "Player:";
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.AutoSize = true;
            this.lblPropertyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyName.Location = new System.Drawing.Point(272, 85);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(139, 20);
            this.lblPropertyName.TabIndex = 36;
            this.lblPropertyName.Text = "Choose a property";
            // 
            // lblPropertyDesc
            // 
            this.lblPropertyDesc.AutoSize = true;
            this.lblPropertyDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropertyDesc.Location = new System.Drawing.Point(271, 55);
            this.lblPropertyDesc.Name = "lblPropertyDesc";
            this.lblPropertyDesc.Size = new System.Drawing.Size(100, 26);
            this.lblPropertyDesc.TabIndex = 35;
            this.lblPropertyDesc.Text = "Property:";
            // 
            // btnUnmortgage
            // 
            this.btnUnmortgage.Enabled = false;
            this.btnUnmortgage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnmortgage.Location = new System.Drawing.Point(277, 312);
            this.btnUnmortgage.Name = "btnUnmortgage";
            this.btnUnmortgage.Size = new System.Drawing.Size(200, 43);
            this.btnUnmortgage.TabIndex = 37;
            this.btnUnmortgage.Text = "Un-Mortgage";
            this.btnUnmortgage.UseVisualStyleBackColor = true;
            this.btnUnmortgage.Click += new System.EventHandler(this.btnUnmortgage_Click);
            // 
            // UpgradeProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 483);
            this.Controls.Add(this.btnUnmortgage);
            this.Controls.Add(this.lblPropertyName);
            this.Controls.Add(this.lblPropertyDesc);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblPlayerText);
            this.Controls.Add(this.lblMoneyTotal);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnAddHotelToAll);
            this.Controls.Add(this.btnAddHotel);
            this.Controls.Add(this.btnAddHouse);
            this.Controls.Add(this.btnAddHouseToAll);
            this.Controls.Add(this.lblPropEligible);
            this.Controls.Add(this.listViewProperties);
            this.Controls.Add(this.btnClose);
            this.Name = "UpgradeProperty";
            this.Text = "UpgradeProperty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listViewProperties;
        private System.Windows.Forms.Label lblPropEligible;
        private System.Windows.Forms.Button btnAddHouseToAll;
        private System.Windows.Forms.Button btnAddHouse;
        private System.Windows.Forms.Button btnAddHotel;
        private System.Windows.Forms.Button btnAddHotelToAll;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblMoneyTotal;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPlayerText;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.Label lblPropertyDesc;
        private System.Windows.Forms.Button btnUnmortgage;
    }
}
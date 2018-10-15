namespace Monopoly
{
    partial class Trade
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
            this.lblRequester = new System.Windows.Forms.Label();
            this.lblRequesteeProperties = new System.Windows.Forms.Label();
            this.lblRequesterProperties = new System.Windows.Forms.Label();
            this.lblRequestee = new System.Windows.Forms.Label();
            this.lblRequesterName = new System.Windows.Forms.Label();
            this.txtRequesterMoney = new System.Windows.Forms.TextBox();
            this.lblRequesterMoney = new System.Windows.Forms.Label();
            this.lblRequesteeMoney = new System.Windows.Forms.Label();
            this.lblNotice1 = new System.Windows.Forms.Label();
            this.lblNotice2 = new System.Windows.Forms.Label();
            this.grpRequesterOffering = new System.Windows.Forms.GroupBox();
            this.lblRequesterMoneyNew = new System.Windows.Forms.Label();
            this.lblArrow1 = new System.Windows.Forms.Label();
            this.lblRequesterMoneyOffering = new System.Windows.Forms.Label();
            this.lstRequesterOffering = new System.Windows.Forms.ListBox();
            this.txtRequesterMoneyOffering = new System.Windows.Forms.TextBox();
            this.grpRequesteeOffering = new System.Windows.Forms.GroupBox();
            this.lblRequesteeMoneyNew = new System.Windows.Forms.Label();
            this.lblArrow2 = new System.Windows.Forms.Label();
            this.lblRequsteeMoneyOffering = new System.Windows.Forms.Label();
            this.txtRequesteeMoneyOffering = new System.Windows.Forms.TextBox();
            this.lstRequesteeOffering = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmboRequestee = new System.Windows.Forms.ComboBox();
            this.lblRequesteeTotal = new System.Windows.Forms.Label();
            this.lblRequesterTotal = new System.Windows.Forms.Label();
            this.lstRequesteeProperties = new System.Windows.Forms.ListView();
            this.lstRequesterProperties = new System.Windows.Forms.ListView();
            this.grpRequesterOffering.SuspendLayout();
            this.grpRequesteeOffering.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRequester
            // 
            this.lblRequester.AutoSize = true;
            this.lblRequester.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequester.Location = new System.Drawing.Point(12, 9);
            this.lblRequester.Name = "lblRequester";
            this.lblRequester.Size = new System.Drawing.Size(118, 26);
            this.lblRequester.TabIndex = 0;
            this.lblRequester.Text = "Requester:";
            // 
            // lblRequesteeProperties
            // 
            this.lblRequesteeProperties.AutoSize = true;
            this.lblRequesteeProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeProperties.Location = new System.Drawing.Point(257, 52);
            this.lblRequesteeProperties.Name = "lblRequesteeProperties";
            this.lblRequesteeProperties.Size = new System.Drawing.Size(111, 26);
            this.lblRequesteeProperties.TabIndex = 1;
            this.lblRequesteeProperties.Text = "Properties";
            // 
            // lblRequesterProperties
            // 
            this.lblRequesterProperties.AutoSize = true;
            this.lblRequesterProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterProperties.Location = new System.Drawing.Point(12, 52);
            this.lblRequesterProperties.Name = "lblRequesterProperties";
            this.lblRequesterProperties.Size = new System.Drawing.Size(111, 26);
            this.lblRequesterProperties.TabIndex = 2;
            this.lblRequesterProperties.Text = "Properties";
            // 
            // lblRequestee
            // 
            this.lblRequestee.AutoSize = true;
            this.lblRequestee.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestee.Location = new System.Drawing.Point(257, 9);
            this.lblRequestee.Name = "lblRequestee";
            this.lblRequestee.Size = new System.Drawing.Size(123, 26);
            this.lblRequestee.TabIndex = 4;
            this.lblRequestee.Text = "Requestee:";
            // 
            // lblRequesterName
            // 
            this.lblRequesterName.AutoSize = true;
            this.lblRequesterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterName.Location = new System.Drawing.Point(136, 9);
            this.lblRequesterName.Name = "lblRequesterName";
            this.lblRequesterName.Size = new System.Drawing.Size(74, 26);
            this.lblRequesterName.TabIndex = 5;
            this.lblRequesterName.Text = "Player";
            // 
            // txtRequesterMoney
            // 
            this.txtRequesterMoney.Enabled = false;
            this.txtRequesterMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequesterMoney.Location = new System.Drawing.Point(78, 201);
            this.txtRequesterMoney.Name = "txtRequesterMoney";
            this.txtRequesterMoney.Size = new System.Drawing.Size(62, 26);
            this.txtRequesterMoney.TabIndex = 8;
            this.txtRequesterMoney.Text = "0";
            this.txtRequesterMoney.TextChanged += new System.EventHandler(this.txtRequesterMoney_TextChanged);
            // 
            // lblRequesterMoney
            // 
            this.lblRequesterMoney.AutoSize = true;
            this.lblRequesterMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterMoney.Location = new System.Drawing.Point(12, 203);
            this.lblRequesterMoney.Name = "lblRequesterMoney";
            this.lblRequesterMoney.Size = new System.Drawing.Size(60, 20);
            this.lblRequesterMoney.TabIndex = 10;
            this.lblRequesterMoney.Text = "Money:";
            // 
            // lblRequesteeMoney
            // 
            this.lblRequesteeMoney.AutoSize = true;
            this.lblRequesteeMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeMoney.Location = new System.Drawing.Point(262, 204);
            this.lblRequesteeMoney.Name = "lblRequesteeMoney";
            this.lblRequesteeMoney.Size = new System.Drawing.Size(60, 20);
            this.lblRequesteeMoney.TabIndex = 13;
            this.lblRequesteeMoney.Text = "Money:";
            // 
            // lblNotice1
            // 
            this.lblNotice1.AutoSize = true;
            this.lblNotice1.Location = new System.Drawing.Point(14, 233);
            this.lblNotice1.Name = "lblNotice1";
            this.lblNotice1.Size = new System.Drawing.Size(195, 26);
            this.lblNotice1.TabIndex = 14;
            this.lblNotice1.Text = "Making the number negative symbolizes\r\ngiving money to the other player.";
            // 
            // lblNotice2
            // 
            this.lblNotice2.AutoSize = true;
            this.lblNotice2.Location = new System.Drawing.Point(259, 233);
            this.lblNotice2.Name = "lblNotice2";
            this.lblNotice2.Size = new System.Drawing.Size(195, 26);
            this.lblNotice2.TabIndex = 15;
            this.lblNotice2.Text = "Making the number negative symbolizes\r\ngiving money to the other player.";
            // 
            // grpRequesterOffering
            // 
            this.grpRequesterOffering.Controls.Add(this.lblRequesterMoneyNew);
            this.grpRequesterOffering.Controls.Add(this.lblArrow1);
            this.grpRequesterOffering.Controls.Add(this.lblRequesterMoneyOffering);
            this.grpRequesterOffering.Controls.Add(this.lstRequesterOffering);
            this.grpRequesterOffering.Controls.Add(this.txtRequesterMoneyOffering);
            this.grpRequesterOffering.Location = new System.Drawing.Point(17, 279);
            this.grpRequesterOffering.Name = "grpRequesterOffering";
            this.grpRequesterOffering.Size = new System.Drawing.Size(200, 159);
            this.grpRequesterOffering.TabIndex = 16;
            this.grpRequesterOffering.TabStop = false;
            this.grpRequesterOffering.Text = "Offering";
            // 
            // lblRequesterMoneyNew
            // 
            this.lblRequesterMoneyNew.AutoSize = true;
            this.lblRequesterMoneyNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterMoneyNew.Location = new System.Drawing.Point(152, 130);
            this.lblRequesterMoneyNew.Name = "lblRequesterMoneyNew";
            this.lblRequesterMoneyNew.Size = new System.Drawing.Size(40, 17);
            this.lblRequesterMoneyNew.TabIndex = 25;
            this.lblRequesterMoneyNew.Text = "Total";
            // 
            // lblArrow1
            // 
            this.lblArrow1.AutoSize = true;
            this.lblArrow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow1.Location = new System.Drawing.Point(129, 127);
            this.lblArrow1.Name = "lblArrow1";
            this.lblArrow1.Size = new System.Drawing.Size(23, 20);
            this.lblArrow1.TabIndex = 24;
            this.lblArrow1.Text = "->";
            // 
            // lblRequesterMoneyOffering
            // 
            this.lblRequesterMoneyOffering.AutoSize = true;
            this.lblRequesterMoneyOffering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterMoneyOffering.Location = new System.Drawing.Point(8, 126);
            this.lblRequesterMoneyOffering.Name = "lblRequesterMoneyOffering";
            this.lblRequesterMoneyOffering.Size = new System.Drawing.Size(60, 20);
            this.lblRequesterMoneyOffering.TabIndex = 22;
            this.lblRequesterMoneyOffering.Text = "Money:";
            // 
            // lstRequesterOffering
            // 
            this.lstRequesterOffering.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstRequesterOffering.Enabled = false;
            this.lstRequesterOffering.FormattingEnabled = true;
            this.lstRequesterOffering.Location = new System.Drawing.Point(7, 19);
            this.lstRequesterOffering.Name = "lstRequesterOffering";
            this.lstRequesterOffering.Size = new System.Drawing.Size(185, 95);
            this.lstRequesterOffering.TabIndex = 17;
            this.lstRequesterOffering.DoubleClick += new System.EventHandler(this.lstRequesterOffering_DoubleClick);
            // 
            // txtRequesterMoneyOffering
            // 
            this.txtRequesterMoneyOffering.Enabled = false;
            this.txtRequesterMoneyOffering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequesterMoneyOffering.Location = new System.Drawing.Point(74, 124);
            this.txtRequesterMoneyOffering.Name = "txtRequesterMoneyOffering";
            this.txtRequesterMoneyOffering.Size = new System.Drawing.Size(49, 26);
            this.txtRequesterMoneyOffering.TabIndex = 21;
            // 
            // grpRequesteeOffering
            // 
            this.grpRequesteeOffering.Controls.Add(this.lblRequesteeMoneyNew);
            this.grpRequesteeOffering.Controls.Add(this.lblArrow2);
            this.grpRequesteeOffering.Controls.Add(this.lblRequsteeMoneyOffering);
            this.grpRequesteeOffering.Controls.Add(this.txtRequesteeMoneyOffering);
            this.grpRequesteeOffering.Controls.Add(this.lstRequesteeOffering);
            this.grpRequesteeOffering.Location = new System.Drawing.Point(262, 279);
            this.grpRequesteeOffering.Name = "grpRequesteeOffering";
            this.grpRequesteeOffering.Size = new System.Drawing.Size(200, 159);
            this.grpRequesteeOffering.TabIndex = 0;
            this.grpRequesteeOffering.TabStop = false;
            this.grpRequesteeOffering.Text = "Offering";
            // 
            // lblRequesteeMoneyNew
            // 
            this.lblRequesteeMoneyNew.AutoSize = true;
            this.lblRequesteeMoneyNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeMoneyNew.Location = new System.Drawing.Point(152, 130);
            this.lblRequesteeMoneyNew.Name = "lblRequesteeMoneyNew";
            this.lblRequesteeMoneyNew.Size = new System.Drawing.Size(40, 17);
            this.lblRequesteeMoneyNew.TabIndex = 26;
            this.lblRequesteeMoneyNew.Text = "Total";
            // 
            // lblArrow2
            // 
            this.lblArrow2.AutoSize = true;
            this.lblArrow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow2.Location = new System.Drawing.Point(124, 128);
            this.lblArrow2.Name = "lblArrow2";
            this.lblArrow2.Size = new System.Drawing.Size(23, 20);
            this.lblArrow2.TabIndex = 25;
            this.lblArrow2.Text = "->";
            // 
            // lblRequsteeMoneyOffering
            // 
            this.lblRequsteeMoneyOffering.AutoSize = true;
            this.lblRequsteeMoneyOffering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequsteeMoneyOffering.Location = new System.Drawing.Point(6, 127);
            this.lblRequsteeMoneyOffering.Name = "lblRequsteeMoneyOffering";
            this.lblRequsteeMoneyOffering.Size = new System.Drawing.Size(60, 20);
            this.lblRequsteeMoneyOffering.TabIndex = 20;
            this.lblRequsteeMoneyOffering.Text = "Money:";
            // 
            // txtRequesteeMoneyOffering
            // 
            this.txtRequesteeMoneyOffering.Enabled = false;
            this.txtRequesteeMoneyOffering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequesteeMoneyOffering.Location = new System.Drawing.Point(72, 125);
            this.txtRequesteeMoneyOffering.Name = "txtRequesteeMoneyOffering";
            this.txtRequesteeMoneyOffering.Size = new System.Drawing.Size(46, 26);
            this.txtRequesteeMoneyOffering.TabIndex = 19;
            // 
            // lstRequesteeOffering
            // 
            this.lstRequesteeOffering.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstRequesteeOffering.Enabled = false;
            this.lstRequesteeOffering.FormattingEnabled = true;
            this.lstRequesteeOffering.Location = new System.Drawing.Point(7, 19);
            this.lstRequesteeOffering.Name = "lstRequesteeOffering";
            this.lstRequesteeOffering.Size = new System.Drawing.Size(185, 95);
            this.lstRequesteeOffering.TabIndex = 18;
            this.lstRequesteeOffering.DoubleClick += new System.EventHandler(this.lstRequesteeOffering_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(446, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(16, 456);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(444, 23);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmboRequestee
            // 
            this.cmboRequestee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRequestee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboRequestee.FormattingEnabled = true;
            this.cmboRequestee.Location = new System.Drawing.Point(380, 13);
            this.cmboRequestee.Name = "cmboRequestee";
            this.cmboRequestee.Size = new System.Drawing.Size(74, 24);
            this.cmboRequestee.TabIndex = 19;
            this.cmboRequestee.SelectedValueChanged += new System.EventHandler(this.cmboRequestee_SelectedValueChanged);
            // 
            // lblRequesteeTotal
            // 
            this.lblRequesteeTotal.AutoSize = true;
            this.lblRequesteeTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeTotal.Location = new System.Drawing.Point(328, 204);
            this.lblRequesteeTotal.Name = "lblRequesteeTotal";
            this.lblRequesteeTotal.Size = new System.Drawing.Size(44, 20);
            this.lblRequesteeTotal.TabIndex = 20;
            this.lblRequesteeTotal.Text = "Total";
            // 
            // lblRequesterTotal
            // 
            this.lblRequesterTotal.AutoSize = true;
            this.lblRequesterTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterTotal.Location = new System.Drawing.Point(146, 203);
            this.lblRequesterTotal.Name = "lblRequesterTotal";
            this.lblRequesterTotal.Size = new System.Drawing.Size(52, 20);
            this.lblRequesterTotal.TabIndex = 21;
            this.lblRequesterTotal.Text = "/ Total";
            // 
            // lstRequesteeProperties
            // 
            this.lstRequesteeProperties.Enabled = false;
            this.lstRequesteeProperties.Location = new System.Drawing.Point(262, 100);
            this.lstRequesteeProperties.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstRequesteeProperties.MultiSelect = false;
            this.lstRequesteeProperties.Name = "lstRequesteeProperties";
            this.lstRequesteeProperties.Size = new System.Drawing.Size(198, 95);
            this.lstRequesteeProperties.TabIndex = 22;
            this.lstRequesteeProperties.UseCompatibleStateImageBehavior = false;
            this.lstRequesteeProperties.View = System.Windows.Forms.View.Details;
            this.lstRequesteeProperties.DoubleClick += new System.EventHandler(this.lstRequesteeProperties_DoubleClick);
            // 
            // lstRequesterProperties
            // 
            this.lstRequesterProperties.Enabled = false;
            this.lstRequesterProperties.Location = new System.Drawing.Point(17, 100);
            this.lstRequesterProperties.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstRequesterProperties.MultiSelect = false;
            this.lstRequesterProperties.Name = "lstRequesterProperties";
            this.lstRequesterProperties.Size = new System.Drawing.Size(198, 95);
            this.lstRequesterProperties.TabIndex = 23;
            this.lstRequesterProperties.UseCompatibleStateImageBehavior = false;
            this.lstRequesterProperties.View = System.Windows.Forms.View.Details;
            this.lstRequesterProperties.DoubleClick += new System.EventHandler(this.lstRequesterProperties_DoubleClick);
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 522);
            this.Controls.Add(this.lstRequesterProperties);
            this.Controls.Add(this.lstRequesteeProperties);
            this.Controls.Add(this.lblRequesterTotal);
            this.Controls.Add(this.lblRequesteeTotal);
            this.Controls.Add(this.cmboRequestee);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpRequesteeOffering);
            this.Controls.Add(this.grpRequesterOffering);
            this.Controls.Add(this.lblNotice2);
            this.Controls.Add(this.lblNotice1);
            this.Controls.Add(this.lblRequesteeMoney);
            this.Controls.Add(this.lblRequesterMoney);
            this.Controls.Add(this.txtRequesterMoney);
            this.Controls.Add(this.lblRequesterName);
            this.Controls.Add(this.lblRequestee);
            this.Controls.Add(this.lblRequesterProperties);
            this.Controls.Add(this.lblRequesteeProperties);
            this.Controls.Add(this.lblRequester);
            this.Name = "Trade";
            this.Text = "Trade";
            this.Load += new System.EventHandler(this.Trade_Load);
            this.grpRequesterOffering.ResumeLayout(false);
            this.grpRequesterOffering.PerformLayout();
            this.grpRequesteeOffering.ResumeLayout(false);
            this.grpRequesteeOffering.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRequester;
        private System.Windows.Forms.Label lblRequesteeProperties;
        private System.Windows.Forms.Label lblRequesterProperties;
        private System.Windows.Forms.Label lblRequestee;
        private System.Windows.Forms.Label lblRequesterName;
        private System.Windows.Forms.TextBox txtRequesterMoney;
        private System.Windows.Forms.Label lblRequesterMoney;
        private System.Windows.Forms.Label lblRequesteeMoney;
        private System.Windows.Forms.Label lblNotice1;
        private System.Windows.Forms.Label lblNotice2;
        private System.Windows.Forms.GroupBox grpRequesterOffering;
        private System.Windows.Forms.Label lblRequesterMoneyOffering;
        private System.Windows.Forms.ListBox lstRequesterOffering;
        private System.Windows.Forms.TextBox txtRequesterMoneyOffering;
        private System.Windows.Forms.GroupBox grpRequesteeOffering;
        private System.Windows.Forms.Label lblRequsteeMoneyOffering;
        private System.Windows.Forms.TextBox txtRequesteeMoneyOffering;
        private System.Windows.Forms.ListBox lstRequesteeOffering;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmboRequestee;
        private System.Windows.Forms.Label lblRequesteeTotal;
        private System.Windows.Forms.Label lblRequesterTotal;
        private System.Windows.Forms.Label lblRequesterMoneyNew;
        private System.Windows.Forms.Label lblArrow1;
        private System.Windows.Forms.Label lblRequesteeMoneyNew;
        private System.Windows.Forms.Label lblArrow2;
        private System.Windows.Forms.ListView lstRequesteeProperties;
        private System.Windows.Forms.ListView lstRequesterProperties;
    }
}
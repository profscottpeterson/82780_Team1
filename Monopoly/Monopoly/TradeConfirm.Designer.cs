//-----------------------------------------------------------------------
// <copyright file="TradeConfirm.Designer.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    /// <summary>
    /// The class for the trade confirm form
    /// </summary>
    partial class TradeConfirm
    {
        /// <summary>
        /// The group box for what the requestee is offering
        /// </summary>
        private System.Windows.Forms.GroupBox grpRequesteeOffering;

        /// <summary>
        /// The label for how much the requestee offered
        /// </summary>
        private System.Windows.Forms.Label lblRequesteeMoneyNew;

        /// <summary>
        /// A label for an arrow
        /// </summary>
        private System.Windows.Forms.Label lblArrow2;

        /// <summary>
        /// The label for how much the requestee is offering
        /// </summary>
        private System.Windows.Forms.Label lblRequsteeMoneyOffering;

        /// <summary>
        /// A list box of properties
        /// </summary>
        private System.Windows.Forms.ListBox lstRequesteeOffering;

        /// <summary>
        /// A group box for something
        /// </summary>
        private System.Windows.Forms.GroupBox grpRequesterOffering;

        /// <summary>
        /// A label for the requester money
        /// </summary>
        private System.Windows.Forms.Label lblRequesterMoneyNew;

        /// <summary>
        /// Also a label for an arrow
        /// </summary>
        private System.Windows.Forms.Label lblArrow1;

        /// <summary>
        /// Also a label
        /// </summary>
        private System.Windows.Forms.Label lblRequesterMoneyOffering;

        /// <summary>
        /// What the requester is offering
        /// </summary>
        private System.Windows.Forms.ListBox lstRequesterOffering;

        /// <summary>
        /// ANOTHER ARROW
        /// </summary>
        private System.Windows.Forms.Label lblDoubleArrow;

        /// <summary>
        /// The label for a question
        /// </summary>
        private System.Windows.Forms.Label lblQuestion;

        /// <summary>
        /// The button for yes
        /// </summary>
        private System.Windows.Forms.Button btnYes;

        /// <summary>
        /// The button for no
        /// </summary>
        private System.Windows.Forms.Button btnNo;

        /// <summary>
        /// The original money the requestee had
        /// </summary>
        private System.Windows.Forms.Label lblRequesteeOriginTotal;

        /// <summary>
        /// The original money for the requester
        /// </summary>
        private System.Windows.Forms.Label lblRequesterOriginTotal;

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
            this.grpRequesteeOffering = new System.Windows.Forms.GroupBox();
            this.lblRequesteeOriginTotal = new System.Windows.Forms.Label();
            this.lblRequesteeMoneyNew = new System.Windows.Forms.Label();
            this.lblArrow2 = new System.Windows.Forms.Label();
            this.lblRequsteeMoneyOffering = new System.Windows.Forms.Label();
            this.lstRequesteeOffering = new System.Windows.Forms.ListBox();
            this.grpRequesterOffering = new System.Windows.Forms.GroupBox();
            this.lblRequesterOriginTotal = new System.Windows.Forms.Label();
            this.lblRequesterMoneyNew = new System.Windows.Forms.Label();
            this.lblArrow1 = new System.Windows.Forms.Label();
            this.lblRequesterMoneyOffering = new System.Windows.Forms.Label();
            this.lstRequesterOffering = new System.Windows.Forms.ListBox();
            this.lblDoubleArrow = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblRequesterBeforeJailCard = new System.Windows.Forms.Label();
            this.lblJailRequesterArrow = new System.Windows.Forms.Label();
            this.lblRequesterAfterJailCard = new System.Windows.Forms.Label();
            this.lblJailText = new System.Windows.Forms.Label();
            this.lblRequesteeBeforeJailCard = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRequesteeAfterJailCard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpRequesteeOffering.SuspendLayout();
            this.grpRequesterOffering.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRequesteeOffering
            // 
            this.grpRequesteeOffering.Controls.Add(this.lblRequesteeBeforeJailCard);
            this.grpRequesteeOffering.Controls.Add(this.lblRequesteeOriginTotal);
            this.grpRequesteeOffering.Controls.Add(this.label2);
            this.grpRequesteeOffering.Controls.Add(this.lblRequesteeMoneyNew);
            this.grpRequesteeOffering.Controls.Add(this.lblRequesteeAfterJailCard);
            this.grpRequesteeOffering.Controls.Add(this.lblArrow2);
            this.grpRequesteeOffering.Controls.Add(this.label4);
            this.grpRequesteeOffering.Controls.Add(this.lblRequsteeMoneyOffering);
            this.grpRequesteeOffering.Controls.Add(this.lstRequesteeOffering);
            this.grpRequesteeOffering.Location = new System.Drawing.Point(257, 12);
            this.grpRequesteeOffering.Name = "grpRequesteeOffering";
            this.grpRequesteeOffering.Size = new System.Drawing.Size(200, 194);
            this.grpRequesteeOffering.TabIndex = 17;
            this.grpRequesteeOffering.TabStop = false;
            this.grpRequesteeOffering.Text = "Offering";
            // 
            // lblRequesteeOriginTotal
            // 
            this.lblRequesteeOriginTotal.AutoSize = true;
            this.lblRequesteeOriginTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeOriginTotal.Location = new System.Drawing.Point(72, 131);
            this.lblRequesteeOriginTotal.Name = "lblRequesteeOriginTotal";
            this.lblRequesteeOriginTotal.Size = new System.Drawing.Size(40, 17);
            this.lblRequesteeOriginTotal.TabIndex = 27;
            this.lblRequesteeOriginTotal.Text = "Total";
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
            // lstRequesteeOffering
            // 
            this.lstRequesteeOffering.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstRequesteeOffering.Enabled = false;
            this.lstRequesteeOffering.FormattingEnabled = true;
            this.lstRequesteeOffering.Location = new System.Drawing.Point(7, 19);
            this.lstRequesteeOffering.Name = "lstRequesteeOffering";
            this.lstRequesteeOffering.Size = new System.Drawing.Size(185, 95);
            this.lstRequesteeOffering.TabIndex = 18;
            // 
            // grpRequesterOffering
            // 
            this.grpRequesterOffering.Controls.Add(this.lblRequesterBeforeJailCard);
            this.grpRequesterOffering.Controls.Add(this.lblRequesterOriginTotal);
            this.grpRequesterOffering.Controls.Add(this.lblJailRequesterArrow);
            this.grpRequesterOffering.Controls.Add(this.lblRequesterMoneyNew);
            this.grpRequesterOffering.Controls.Add(this.lblRequesterAfterJailCard);
            this.grpRequesterOffering.Controls.Add(this.lblArrow1);
            this.grpRequesterOffering.Controls.Add(this.lblJailText);
            this.grpRequesterOffering.Controls.Add(this.lblRequesterMoneyOffering);
            this.grpRequesterOffering.Controls.Add(this.lstRequesterOffering);
            this.grpRequesterOffering.Location = new System.Drawing.Point(12, 12);
            this.grpRequesterOffering.Name = "grpRequesterOffering";
            this.grpRequesterOffering.Size = new System.Drawing.Size(200, 194);
            this.grpRequesterOffering.TabIndex = 18;
            this.grpRequesterOffering.TabStop = false;
            this.grpRequesterOffering.Text = "Offering";
            // 
            // lblRequesterOriginTotal
            // 
            this.lblRequesterOriginTotal.AutoSize = true;
            this.lblRequesterOriginTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterOriginTotal.Location = new System.Drawing.Point(83, 131);
            this.lblRequesterOriginTotal.Name = "lblRequesterOriginTotal";
            this.lblRequesterOriginTotal.Size = new System.Drawing.Size(40, 17);
            this.lblRequesterOriginTotal.TabIndex = 26;
            this.lblRequesterOriginTotal.Text = "Total";
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
            // 
            // lblDoubleArrow
            // 
            this.lblDoubleArrow.AutoSize = true;
            this.lblDoubleArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoubleArrow.Location = new System.Drawing.Point(212, 76);
            this.lblDoubleArrow.Name = "lblDoubleArrow";
            this.lblDoubleArrow.Size = new System.Drawing.Size(45, 26);
            this.lblDoubleArrow.TabIndex = 19;
            this.lblDoubleArrow.Text = "<->";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(57, 242);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(347, 26);
            this.lblQuestion.TabIndex = 20;
            this.lblQuestion.Text = "Do both parties agree to the trade?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(137, 298);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 21;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(257, 298);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 22;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblRequesterBeforeJailCard
            // 
            this.lblRequesterBeforeJailCard.AutoSize = true;
            this.lblRequesterBeforeJailCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterBeforeJailCard.Location = new System.Drawing.Point(124, 160);
            this.lblRequesterBeforeJailCard.Name = "lblRequesterBeforeJailCard";
            this.lblRequesterBeforeJailCard.Size = new System.Drawing.Size(18, 20);
            this.lblRequesterBeforeJailCard.TabIndex = 33;
            this.lblRequesterBeforeJailCard.Text = "0";
            // 
            // lblJailRequesterArrow
            // 
            this.lblJailRequesterArrow.AutoSize = true;
            this.lblJailRequesterArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJailRequesterArrow.Location = new System.Drawing.Point(153, 160);
            this.lblJailRequesterArrow.Name = "lblJailRequesterArrow";
            this.lblJailRequesterArrow.Size = new System.Drawing.Size(23, 20);
            this.lblJailRequesterArrow.TabIndex = 32;
            this.lblJailRequesterArrow.Text = "->";
            // 
            // lblRequesterAfterJailCard
            // 
            this.lblRequesterAfterJailCard.AutoSize = true;
            this.lblRequesterAfterJailCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesterAfterJailCard.Location = new System.Drawing.Point(179, 160);
            this.lblRequesterAfterJailCard.Name = "lblRequesterAfterJailCard";
            this.lblRequesterAfterJailCard.Size = new System.Drawing.Size(18, 20);
            this.lblRequesterAfterJailCard.TabIndex = 31;
            this.lblRequesterAfterJailCard.Text = "0";
            // 
            // lblJailText
            // 
            this.lblJailText.AutoSize = true;
            this.lblJailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJailText.Location = new System.Drawing.Point(12, 160);
            this.lblJailText.Name = "lblJailText";
            this.lblJailText.Size = new System.Drawing.Size(111, 20);
            this.lblJailText.TabIndex = 30;
            this.lblJailText.Text = "Jail Free Card:";
            // 
            // lblRequesteeBeforeJailCard
            // 
            this.lblRequesteeBeforeJailCard.AutoSize = true;
            this.lblRequesteeBeforeJailCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeBeforeJailCard.Location = new System.Drawing.Point(118, 160);
            this.lblRequesteeBeforeJailCard.Name = "lblRequesteeBeforeJailCard";
            this.lblRequesteeBeforeJailCard.Size = new System.Drawing.Size(18, 20);
            this.lblRequesteeBeforeJailCard.TabIndex = 37;
            this.lblRequesteeBeforeJailCard.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "->";
            // 
            // lblRequesteeAfterJailCard
            // 
            this.lblRequesteeAfterJailCard.AutoSize = true;
            this.lblRequesteeAfterJailCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequesteeAfterJailCard.Location = new System.Drawing.Point(173, 160);
            this.lblRequesteeAfterJailCard.Name = "lblRequesteeAfterJailCard";
            this.lblRequesteeAfterJailCard.Size = new System.Drawing.Size(18, 20);
            this.lblRequesteeAfterJailCard.TabIndex = 35;
            this.lblRequesteeAfterJailCard.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Jail Free Card:";
            // 
            // TradeConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 349);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblDoubleArrow);
            this.Controls.Add(this.grpRequesteeOffering);
            this.Controls.Add(this.grpRequesterOffering);
            this.Name = "TradeConfirm";
            this.Text = "TradeConfirm";
            this.Load += new System.EventHandler(this.TradeConfirm_Load);
            this.grpRequesteeOffering.ResumeLayout(false);
            this.grpRequesteeOffering.PerformLayout();
            this.grpRequesterOffering.ResumeLayout(false);
            this.grpRequesterOffering.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRequesteeBeforeJailCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRequesteeAfterJailCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRequesterBeforeJailCard;
        private System.Windows.Forms.Label lblJailRequesterArrow;
        private System.Windows.Forms.Label lblRequesterAfterJailCard;
        private System.Windows.Forms.Label lblJailText;
    }
}
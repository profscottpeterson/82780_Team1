﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class NonPropPopUp : Form
    {
        private Spot spot;
        private Game game;

        public NonPropPopUp(Spot spot, Game game)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.spot = spot;
            this.game = game;
            InitializeComponent();
        }

        private void NonPropPopUp_Load(object sender, EventArgs e)
        {
            this.Text = this.spot.SpotName;
            this.NameLabel.Text = this.spot.SpotName;
            this.PriceLabel.Text = "Price: " + this.spot.Price.ToString("C0");
            //AmtOwedLabel.Text = "Rent: " + spot.Rent.ToString("C0");
            this.MortgageLabel.Text = "Mortgage: " + this.spot.Mortgage.ToString("C0");

            if (this.spot.Type == SpotType.Utility)
            {
                this.AmtOwedLabel.Text = "If one Utility is owned, rent is 4 times amount shown on dice." + '\n';
                this.AmtOwedLabel.Text += "If both Utilities are owned, rent is 10 times amount shown on dice.";

                if (!this.spot.IsAvailable)
                {
                    this.NumberOwnedLabel.Text = "Number of Utilities Owned by Owner: ";
                    if (this.game.BothUtilitiesOwned(this.spot))
                    {
                        this.NumberOwnedLabel.Text += "2";
                    }
                    else
                    {
                        this.NumberOwnedLabel.Text += "1";
                    }
                }
                else
                {
                    this.NumberOwnedLabel.Text = "-";
                }
            }
            else
            {
                string text = "";
                text += "Rent: " + this.spot.Rent.ToString("C0") + '\n';
                text += "If 2 are owned: " + (this.spot.Rent * 2).ToString("C0") + '\n';
                text += "If 3 are owned: " + (this.spot.Rent * 4).ToString("C0") + '\n';
                text += "If 4 are owned: " + (this.spot.Rent * 8).ToString("C0");
                this.AmtOwedLabel.Text = text;
                this.AmtOwedLabel.TextAlign = ContentAlignment.MiddleCenter;

                if (!this.spot.IsAvailable)
                {
                    this.NumberOwnedLabel.Text = "Number of Railroads Owned by Owner: " + this.game.NumberRailroadsOwned(this.spot);
                }
                else
                {
                    this.NumberOwnedLabel.Text = "-";
                }
            }

            // If property is owned, display owner name
            if (!this.spot.IsAvailable && this.spot.Owner != null)
            {
                this.OwnerLabel.Text = "Property's owner: " + this.spot.Owner.PlayerName;
            }
            else
            {
                this.OwnerLabel.Text = "This property is not owned.";
            }

            // Check whether property is mortgaged and display results
            if (this.spot.IsMortgaged)
            {
                this.IsMortgagedLabel.Text = "Property is currently mortgaged.";
            }
            else
            {
                this.IsMortgagedLabel.Text = "Property is not currently mortgaged.";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

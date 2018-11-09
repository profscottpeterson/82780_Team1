//-----------------------------------------------------------------------
// <copyright file="TradeConfirm.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------

namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The TradeConfirm class extends the Form class
    /// </summary>
    public partial class TradeConfirm : Form
    {
        /// <summary>
        /// Reason that the form was closed
        /// </summary>
        public string reason = string.Empty;

        /// <summary>
        /// The game class instance
        /// </summary>
        private Game game;

        /// <summary>
        /// Player initiating the trade
        /// </summary>
        private Player main;

        /// <summary>
        /// The player that is the desired trade target
        /// </summary>
        private Player target;

        /// <summary>
        /// Player initiating the trades offered properties
        /// </summary>
        private List<Spot> mainList;

        /// <summary>
        /// target players desired properties
        /// </summary>
        private List<Spot> targetList;

        /// <summary>
        /// The moneychange ocurring, negative means giving to target player while positive is receiving money from target player
        /// </summary>
        private int moneyChange = 0;

        /// <summary>
        /// jailcards being sent back and forth, negative is giving to target player while positive is receiving from them
        /// </summary>
        private int jailCardChange = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeConfirm"/> class
        /// </summary>
        /// <param name="g">The current game instance</param>
        /// <param name="main">player initiating the trade</param>
        /// <param name="target">The player that is the target of the trade</param>
        /// <param name="mainList">The list of properties the player initiating the trade is offering</param>
        /// <param name="targetList">The list of properties wanted from the target player</param>
        /// <param name="moneyChange">The money flow</param>
        /// <param name="jailCardChange">The jail card flow</param>
        public TradeConfirm(Game g, Player main, Player target, List<Spot> mainList, List<Spot> targetList, int moneyChange, int jailCardChange)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.InitializeComponent();
            this.game = g;
            this.main = main;
            this.target = target;
            this.mainList = mainList;
            this.targetList = targetList;
            this.moneyChange = moneyChange;
            this.jailCardChange = jailCardChange;
        }

        /// <summary>
        /// The button click event for the No button
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">the eventArgs for the button</param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            // Set the reason to No
            this.reason = "No";

            this.Close();
        }

        /// <summary>
        /// The button click event for the Yes button
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">the eventArgs for the button</param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            // For each offering to target, set them as the owner to each of those properties
            foreach (Spot s in this.mainList)
            {
                this.game.Board[s.SpotId].Owner = this.target;
            }

            // Also set the target money to be updated
            this.game.Players[this.target.PlayerId].Money = this.target.Money - this.moneyChange;

            // For each offering to origin, set them as the owner to each of those properties
            foreach (Spot s in this.targetList)
            {
                this.game.Board[s.SpotId].Owner = this.main;
            }

            // Also set the target money to be updated
            this.game.Players[this.main.PlayerId].Money = this.main.Money + this.moneyChange;

            if (this.jailCardChange == 2)
            {
                Card temp2 = this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards[1];
                this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards.RemoveAt(1);
                Card temp1 = this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards[0];
                this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards.Add(temp1);
                this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards.Add(temp2);
            }
            else if (this.jailCardChange == 1)
            {
                Card temp1 = this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards[0];
                this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards.Add(temp1);
            }
            else if (this.jailCardChange == -1)
            {
                Card temp1 = this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards[0];
                this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards.Add(temp1);
            }
            else if (this.jailCardChange == -2)
            {
                Card temp2 = this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards[1];
                this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards.RemoveAt(1);
                Card temp1 = this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards[0];
                this.game.Players[this.main.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards.Add(temp1);
                this.game.Players[this.target.PlayerId].GetOutOfJailFreeCards.Add(temp2);
            }

            if (this.target.IsAi == true)
            {
                int targetMoney = 0;
                int mainMoney = 0;

                // TODO see why alex did this, it doesn't make sense to add the same amount to both players
                // ONE of them must lose money
                if (this.moneyChange > 0)
                {
                    mainMoney += this.moneyChange;
                }
                else
                {
                    targetMoney += this.moneyChange; // this should probably be -=
                }

                foreach (Spot s in this.targetList)
                {
                    if (s.IsMortgaged == true)
                    {
                        targetMoney += s.Price / 2;
                    }
                    else
                    {
                        targetMoney += s.Price;
                    }
                }

                foreach (Spot s in this.mainList)
                {
                    if (s.IsMortgaged == true)
                    {
                        mainMoney += s.Price / 2;
                    }
                    else
                    {
                        mainMoney += s.Price;
                    }
                }

                if (targetMoney > mainMoney)
                {
                    // Set the reason to Yes
                    this.reason = "No";

                    // close the form
                    this.Close();
                }
                else
                {
                    // Set the reason to Yes
                    this.reason = "Yes";

                    // close the form
                    this.Close();
                }
            }
            else
            {
                // Set the reason to Yes
                this.reason = "Yes";

                // close the form
                this.Close();
            }
        }

        /// <summary>
        /// The load event for the TradeConfirm form
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">the eventArgs for the button</param>
        private void TradeConfirm_Load(object sender, EventArgs e)
        {
            // Fill the requesters list box with their offerings
            foreach (Spot s in this.mainList)
            {
                this.lstRequesterOffering.Items.Add(s.SpotName);
            }

            // Fill the targets list box with their offerings
            foreach (Spot s in this.targetList)
            {
                this.lstRequesteeOffering.Items.Add(s.SpotName);
            }

            // Display the changes to the money and jail card changes//

            // Requester
            this.lblRequesterOriginTotal.Text = this.main.Money.ToString();
            this.lblRequesterMoneyNew.Text = (this.main.Money + this.moneyChange).ToString();
            this.lblRequesterBeforeJailCard.Text = this.main.GetOutOfJailFreeCards.Count.ToString();
            this.lblRequesterAfterJailCard.Text = (this.main.GetOutOfJailFreeCards.Count + this.jailCardChange).ToString();

            // Target
            this.lblRequesteeOriginTotal.Text = this.target.Money.ToString();
            this.lblRequesteeMoneyNew.Text = (this.target.Money - this.moneyChange).ToString();
            this.lblRequesteeBeforeJailCard.Text = this.target.GetOutOfJailFreeCards.Count.ToString();
            this.lblRequesteeAfterJailCard.Text = (this.target.GetOutOfJailFreeCards.Count - this.jailCardChange).ToString();
        }
    }
}

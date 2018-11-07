using System;
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
    public partial class TradeConfirm : Form
    {
        private Game game;
        private Player main;
        private Player target;
        private List<Spot> mainList;
        private List<Spot> targetList;
        private int moneyChange = 0;
        public string reason = "";
        private int jailCardChange = 0;

        public TradeConfirm(Game g, Player main, Player target, List<Spot> mainList, List<Spot> targetList, int moneyChange, int jailCardChange)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
            this.game = g;
            this.main = main;
            this.target = target;
            this.mainList = mainList;
            this.targetList = targetList;
            this.moneyChange = moneyChange;
            this.jailCardChange = jailCardChange;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            // Set the reason to No
            this.reason = "No";

            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //For each offering to target, set them as the owner to each of those properties
            foreach (Spot s in mainList)
            {
                game.Board[s.SpotId].Owner = target;
            }

            // Also set the target money to be updated
            game.Players[target.PlayerId].Money = target.Money - moneyChange;

            // For each offering to origin, set them as the owner to each of those properties
            foreach(Spot s in targetList)
            {
                game.Board[s.SpotId].Owner = main;
            }

            // Also set the target money to be updated
            game.Players[main.PlayerId].Money = main.Money + moneyChange;

            if (jailCardChange == 2)
            {
                Card temp2 = game.Players[target.PlayerId].GetOutOfJailFreeCards[1];
                game.Players[target.PlayerId].GetOutOfJailFreeCards.RemoveAt(1);
                Card temp1 = game.Players[target.PlayerId].GetOutOfJailFreeCards[0];
                game.Players[target.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                game.Players[main.PlayerId].GetOutOfJailFreeCards.Add(temp1);
                game.Players[main.PlayerId].GetOutOfJailFreeCards.Add(temp2);
            }
            else if (jailCardChange == 1)
            {
                Card temp1 = game.Players[target.PlayerId].GetOutOfJailFreeCards[0];
                game.Players[target.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                game.Players[main.PlayerId].GetOutOfJailFreeCards.Add(temp1);
            }
            else if (jailCardChange == -1)
            {
                Card temp1 = game.Players[main.PlayerId].GetOutOfJailFreeCards[0];
                game.Players[main.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                game.Players[target.PlayerId].GetOutOfJailFreeCards.Add(temp1);
            }
            else if (jailCardChange == -2)
            {
                Card temp2 = game.Players[main.PlayerId].GetOutOfJailFreeCards[1];
                game.Players[main.PlayerId].GetOutOfJailFreeCards.RemoveAt(1);
                Card temp1 = game.Players[main.PlayerId].GetOutOfJailFreeCards[0];
                game.Players[main.PlayerId].GetOutOfJailFreeCards.RemoveAt(0);

                game.Players[target.PlayerId].GetOutOfJailFreeCards.Add(temp1);
                game.Players[target.PlayerId].GetOutOfJailFreeCards.Add(temp2);
            }

            if (target.IsAi == true)
            {
                int targetMoney = 0;
                int mainMoney = 0;

                if (moneyChange > 0)
                {
                    mainMoney += moneyChange;
                }
                else
                {
                    targetMoney += moneyChange;
                }

                foreach (Spot s in targetList)
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

                foreach (Spot s in mainList)
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

        private void TradeConfirm_Load(object sender, EventArgs e)
        {
            // Fill the requesters list box with their offerings
            foreach (Spot s in mainList)
            {
                lstRequesterOffering.Items.Add(s.SpotName);
            }

            // Fill the targets list box with their offerings
            foreach (Spot s in targetList)
            {
                lstRequesteeOffering.Items.Add(s.SpotName);
            }

            // Display the changes to the money and jail card changes//

            // Requester
            lblRequesterOriginTotal.Text = main.Money.ToString();
            lblRequesterMoneyNew.Text = (main.Money + moneyChange).ToString();
            lblRequesterBeforeJailCard.Text = main.GetOutOfJailFreeCards.Count.ToString();
            lblRequesterAfterJailCard.Text = (main.GetOutOfJailFreeCards.Count + jailCardChange).ToString();


            // Target
            lblRequesteeOriginTotal.Text = target.Money.ToString();
            lblRequesteeMoneyNew.Text = (target.Money - moneyChange).ToString();
            lblRequesteeBeforeJailCard.Text = target.GetOutOfJailFreeCards.Count.ToString();
            lblRequesteeAfterJailCard.Text = (target.GetOutOfJailFreeCards.Count - jailCardChange).ToString();
        }
    }
}

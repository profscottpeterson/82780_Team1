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
        private Game game = new Game();
        private Player main = new Player();
        private Player target = new Player();
        private List<Spot> mainList = new List<Spot>();
        private List<Spot> targetList = new List<Spot>();
        private int moneyChange = 0;
        public string reason = "";

        public TradeConfirm(Game g, Player main, Player target, List<Spot> mainList, List<Spot> targetList, int moneyChange)
        {
            InitializeComponent();
            this.game = g;
            this.main = main;
            this.target = target;
            this.mainList = mainList;
            this.targetList = targetList;
            this.moneyChange = moneyChange;
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

            // Set the reason to Yes
            this.reason = "Yes";

            // close the form
            this.Close();
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

            // Display the changes to the money //

            // Requester
            lblRequesterOriginTotal.Text = main.Money.ToString();
            lblRequesterMoneyNew.Text = (main.Money + moneyChange).ToString();

            // Target
            lblRequesteeOriginTotal.Text = target.Money.ToString();
            lblRequesteeMoneyNew.Text = (target.Money - moneyChange).ToString();
        }
    }
}

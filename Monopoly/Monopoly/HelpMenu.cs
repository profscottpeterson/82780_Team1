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
    public partial class HelpMenu : Form
    {
        string[] message;

        public HelpMenu(string textStart)
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.message = new string[lstOptions.Items.Count];
            this.fillMessages();
            this.lstOptions.SelectedItem = textStart;
        }

        private void lstOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rtbDesc.Text = this.message[this.lstOptions.SelectedIndex];
        }

        public void fillMessages()
        {
            // Gane rules
            this.message[0] = "Rolling - The player clicks the roll button and his or her piece moves forward as determined by the sum of the dice.\n" +
                " - If a player lands on an unowned colored property, railroad or utility, he or she may purchase the property if he or she has enough money.\n" +
                " - If a player lands on an owned, unmortgaged colored property, he or she must pay the owner the sum determined by houses, hotels and base rent.\n" +
                " - If a player lands on an owned railroad, he or she must pay the rent as determined by the owner's number of railroads. (1 owned = $25, 2 owned = $50, 3 owned = $100, 4 owned = $200)\n" +
                " - If a player lands on an owned utility, he or she must pay the rent as his or her role multiplied by 4x or 10x for one or both utilities being owned, respectively.\n" +
                " - If a player lands on his or her own property, or a mortgaged property, nothing happens.\n" +
                " - If a player lands on \"Luxury Tax\" or \"Income Tax\", he or she must pay $200 or 10% of his or her total net worth. This is automatically chosen.\n" +
                " - If a player passes or lands on \"GO\" he or she gets $200.\n" +
                " - If a player lands on \"Chance\" or \"Community Chest\", he or she is given a card from the respective pile and the action described is taken.\n" +
                " - If a player lands on the \"Jail\" space, he or she is \"Just Visiting\".\n" +
                " - If a player lands on the \"Go To Jail\" space, he or she is immediately send to jail. If hr or she passes \"Go\", he ro she doesn't get the $200.\n" +
                " - If a player rolls doubles (both die are the same number), he or she can roll and move again.\n" +
                " - If a player rolls three doubles in a single turn, he or she is sent directly to jail.\n\n" +
                "Jail - A player in jail can trade, collect rent, sell and upgrade properties. He or she must get out of jail before being able to move.\n" +
                " - A player can get out of jail by rolling doubles while in jail. He or she then moves out of jail as determined by the sum of the dice.\n" +
                " - A player can pay $50 to get out of jail on any turn and will be placed in the \"Just Visiting\" area. He or she will be able to roll next turn.\n" +
                " - A player can use a \"Get Out of Jail Free\" card and will be placed in the \"Just Visiting\" area. He or she will be able to roll next turn.\n" +
                " - If a player in jail doesn't get doubles after 3 rolls in jail, he or she must pay $50 and will move the number of spaces as determined by the third roll.\n\n" +
                "Rent - A player landing on a property owned by another player must pay that player rent.\n" +
                " - Once a player owns all properties of a single color, the base rent for those properties is doubled. This still applies if a property is mortgaged.\n" +
                " - Houses and hotels increase the rent per property to the amount stated on the property card.\n\n" +
                "Constructions - Houses and hotels may be purchased on properties where the owner owns all properties of that color group.\n" +
                " - Up to four houses and one hotel may be placed on a single property.\n" +
                " - A hotel can only be placed on properties where all the properties in that color group have four houses.\n" +
                " - All buildings must be created evenly. One property cannot have more than 1 more house or hotel than the other properties of the same color. " +
                "For example, a second house can only be added after all the properties of that color have 1 house.\n" +
                " - A player can sell houses or hotels back to the bank for half of what was paid for them.\n" +
                " - Mortgaged properties cannot be upgraded.\n\n" +
                "Properties\n" +
                " - When a property is first landed on, the player may purchase the property for the listed price.\n" +
                " - Properties with no houses or hotels can be mortgaged to the bank to reclaim the mortgage value on the card.\n" +
                " - Mortgaged properties can be unmortgaged by paying the mortgage value + 10%.";

            // Game setup 
            this.message[1] = "This window is for choosing how many players are playing and who is an AI player.\n\n" +
                " - The first step is to choose a number of players from the drop down box.\n\n" +
                " - Options for each of the players (1 - the number you chose) will appear below. A picture and name can be chosen for each player. Each player other than " +
                "player one will also have an option to be an AI.\n\n" +
                " - The start button will be available after choosing the number of players. Clicking this button will start the game with the selected amount of players.";

            // board 
            this.message[2] = "This is the main game window. The board and options for the players to perform on his or her turns are featured on this window. \n\n" +
                "The current player's information and properties is displayed in the top right. By selecting the radio buttons under the current player's information, he or she can see other " +
                "players properties. \n\n" +
                "By clicking on a property, either on the board or on the list of a player's properties, a box will pop up with information " +
                "about that property. \n\n" +
                "Roll Button - This button will roll the dice for the player. The player will then move on the board the number of spaces determined by the total of the dice. If the " +
                "player rolls doubles, he or she will be able to roll again.\n\n" +
                "Next Turn Button Button - This button is how a player ends his or her turn. The player will be able to perform trades, selling properties, upgrading properties and viewing properties " +
                "even after his or her role.\n\n" +
                "Pay $50 to Get Out of jail Button - This button is available if a player is in jail. Choosing this button will not allow the player to roll but will take them out of jail.\n\n" +
                "Use Get Out of Jail Free Card Button - This button is available if a player is in jail and he or she has a \"Get Out of Jail Free\" card. It will not allow the player to roll and will consume the player's \"Get Out of Jail Free\" card, but it will take the player out of jail.\n\n" +
                "Trade Request button - This button brings up a window that allows the user to trade with another player.\n\n" +
                "Sell Button - This button brings up a form that allows the player to sell his or her buildings or mortgage his or her properties.\n\n" +
                "Upgrade Button - This button brings up a form that will allow the user to put houses and hotels on eligible properties.\n\n" +
                "Restart Game Button - This button will end the current game and bring up the Game Setup window.\n\n" +
                "Quit Game Button - This button will quit the Monopoly application.";

            // Trade Request 
            this.message[3] = "This window allows the player to trade with another player.\n\n" +
                "A player to trade with has to be selected in the drop down box in the top right of the window in order for the window options to be accessible.\n\n" +
                "The player initiating the trade is displayed on the left, and the player they are trading with is displayed on the right.\n\n" +
                "Double-clicking on either list of properties under a players name those properties will be \"offered\" to the other player.\n\n" +
                "A text box on the left allows the player initiating the trade to either request or give money to the other player. A positive number " +
                "means they will receive money, while a negative number means they will give money to the other player.\n\n" +
                "Clicking the \"-\" or \"+\" buttons to the left or right of the number of \"Get Out of Jail Free\" cards count will give or request cards from the other player.\n\n" +
                "A synopsis of the deal is displayed at the bottom of the window.\n\n" +
                "Submit Button - This button will bring open the trade confirm window with the current offerings.\n\n" +
                "Close Button - This button cancels the trade.";

            // Trade confirm
            this.message[4] = "This window brings up the full trade deal and prompts the responding party to accept or decline the trade.\n\n" +
                "Yes Button - Accepts the trade and the money, property and \"Get Out of Jail Free\" card changes are enacted.\n\n" +
                "No Button - The responding party does not accept the trade and the trade confirm window is cancelled.";

            // Upgrade
            this.message[5] = "This window allows the player to build houses and hotels on his or her properties. A player can also un-mortgage properties here. " +
                "This button will not work if the player does not currently own any mortgaged properties or properties that are eligible for an upgrade." +
                "The text box under the unmortgage button will show errors if they arise.\n\n" +
                "The list of player properties on the left of the screen shows the properties that are eligible for an upgrade or can be un-mortgaged. When " +
                "a property is clicked from the list, the available buttons are enabled.\n\n" +
                "Add House Button - This button will add a house to the selected property.\n\n" +
                "Add House To All Button - This button will add a house to all properties of the same color as the selected property.\n\n" +
                "Add Hotel button - This button will add a hotel to the selected property.\n\n" +
                "Add Hotel To All Button - This button will add a hotel to all properties of the same color as the selected property.\n\n" +
                "Un-Mortgage Button - This button will un-mortgage a property if it is mortgaged.\n\n" +
                "Close Button - This button will close the upgrade window.";
            
            // Sell 
            this.message[6] = "This window allows the player to mortgage properties or sell buildings that are currently on properties. If this window was brought up because " +
                "of an inability to pay with his or her current balance (dictated by the debt on the top of the window), he or she will not be able to close the window until " +
                "his or her debt is paid. The box on the top right of the screen shows errors if they arise.\n\n" +
                "A list of the players properties is on the left as well as current houses, hotels and whether each property is mortgaged. By clicking on one of these properties, " +
                "the \"Sell House\", \"Sell Hotel\" and \"Mortgage\" buttons will appear if that property can perform any of those actions. The amount to be gained will appear next to the " +
                "button when a property is clicked.\n\n" +
                "Sell House Button - This button will sell a house that is currently on the property.\n\n" +
                "Sell Hotel Button - This button will sell a hotel that is currently on the property.\n\n" +
                "Mortgage Button - This button will mortgage the selected property.\n\n" +
                "Close Button - This button will close the window. (Note: This button will not do anything if the debt is greater than zero)\n\n" +
                "Forfeit Button - This button removes the player from the game.";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

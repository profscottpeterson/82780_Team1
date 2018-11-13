//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="null">
//     Company null (not copyrighted)
// </copyright>
//-----------------------------------------------------------------------
namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Monopoly.Properties;

    /// <summary>
    /// The class for a game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        /// <param name="chanceImages">The image list for the change cards</param>
        /// <param name="communityChestImages">The image list for the community cards</param>
        public Game(ImageList chanceImages, ImageList communityChestImages)
        {
            // Construct all the properties  
            this.Board = new List<Spot>();
            this.InstantiateList();

            // Construct all the chance cards
            this.ChanceCards = new List<Card>();
            this.RandomizedChanceCards = new List<Card>();

            // Construct all the community chest cards
            this.CommunityChestCards = new List<Card>();
            this.RandomizedCommunityChestCards = new List<Card>();

            // Creates community and chance cards
            this.CreateCards(chanceImages, communityChestImages);

            // Randomize community and chance cards
            this.RandomizedCards();

            // Initialize the list of players
            this.Players = new List<Player>();

            // Only house rules change this - in official rules, free parking is just a safe space
            this.FreeParkingTotal = 0;

            this.RestartGame = false;
        }

        /// <summary>
        /// Gets the list of spots of the board
        /// </summary>
        public List<Spot> Board { get; }

        /// <summary>
        /// Gets the list of chance cards
        /// </summary>
        public List<Card> ChanceCards { get; }

        /// <summary>
        /// Gets the list of chance cards
        /// </summary>
        public List<Card> RandomizedChanceCards { get; }

        /// <summary>
        /// Gets the list of community chest cards
        /// </summary>
        public List<Card> CommunityChestCards { get; }

        /// <summary>
        /// Gets the list of community chest cards
        /// </summary>
        public List<Card> RandomizedCommunityChestCards { get; }

        /// <summary>
        /// Gets or sets the list of players
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the amount of money that Free Parking has
        /// </summary>
        public int FreeParkingTotal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game needs to be restarted
        /// </summary>
        public bool RestartGame { get; set; }

        /// <summary>
        /// Checks to see what type of spot the current player landed on
        /// and does corresponding action
        /// </summary>
        /// <param name="currentPlayer">The current player whose turn it is</param>
        public void RollChecks(Player currentPlayer)
        {
            // handle chance or community cards
            currentPlayer.OnChanceCard = false; // "reset"
            currentPlayer.OnComCard = false; // "reset"

            if (currentPlayer.CurrentLocation.Type == SpotType.Chance || currentPlayer.CurrentLocation.Type == SpotType.CommunityChest)
            {
                string formTitle = string.Empty; // This will be the title of the pop up form
                Card cardDrawn; // Card that will be shown to the player

                switch (currentPlayer.CurrentLocation.Type)
                {
                    case SpotType.Chance:
                        currentPlayer.OnChanceCard = true;
                        formTitle = "Chance";
                        cardDrawn = this.ChanceCards[0]; // Get "top" card
                        this.DrawCard(this.ChanceCards, currentPlayer); // Draw card and perform actions
                                                                                  // Set picture in picturebox
                                                                                  // cardPopup.picture.Image = new Bitmap("filename");
                                                                                  // Other logic
                        break;
                    case SpotType.CommunityChest:
                        currentPlayer.OnComCard = true;
                        formTitle = "Community";
                        cardDrawn = this.CommunityChestCards[0];  // Get "top" card
                        this.DrawCard(this.CommunityChestCards, currentPlayer); // Draw card and perform actions
                                                                                          // Set picture in picturebox
                                                                                          // cardPopup.picture.Image = new Bitmap("filename");
                                                                                          // Other logic
                        break;
                    default:
                        cardDrawn = null;
                        break;
                }

                if (cardDrawn != null)
                {
                    MiscCardForm miscCardForm = new MiscCardForm(formTitle, cardDrawn, currentPlayer); // instantiate form
                    miscCardForm.ShowDialog(); // Show the card form
                }
            }

            // Check to see if rent needs to be paid and pay it if so
            this.CheckPayRent(currentPlayer, currentPlayer.CurrentLocation);

            // Check to see if spot landed on can be bought
            if (this.ShowBuyPropertyButton(currentPlayer, currentPlayer.CurrentLocation))
            {
                ////TODO: CHECK THE BUY PROPERTY CODE - AKA THE BUYPROP FORM AND CODE IN THIS IF STATEMENT AND THERE
                BuyProp buyProp = new BuyProp(currentPlayer.CurrentLocation, currentPlayer, this);
                if (buyProp.IsDisposed == false)
                {
                    buyProp.StartPosition = FormStartPosition.CenterParent;
                    buyProp.ShowDialog();
                }
            }

            // Check to see if tax needs to be paid and pay it if yes
            this.CheckPayTax(currentPlayer, currentPlayer.CurrentLocation);

            // Check to see if player landed on "Go to Jail"
            this.CheckGoToJail(currentPlayer, currentPlayer.CurrentLocation);
        }

        /// <summary>
        /// Checks to see if the player passed Go, and adds 200 to their money if they did
        /// </summary>
        /// <param name="prevLocation">Where on the board the player was previously</param>
        /// <param name="currentLocation">Where on the board the player moved to</param>
        /// <param name="currentPlayer">The current player</param>
        public void CheckPassGo(Spot prevLocation, Spot currentLocation, Player currentPlayer)
        {
            // Check to see if the previous location id is greater than the current location id
            // the second part is for the "go back 3 spaces" card
            if (prevLocation.SpotId > currentLocation.SpotId && prevLocation.SpotId != (currentLocation.SpotId + 3) % this.Board.Count)
            {
                this.Players[this.Players.IndexOf(currentPlayer)].Money += 200;
            }
        }

        /// <summary>
        /// Changes a player's current location property and checks to see if they passed Go
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="spacesForward">The number of spaces to move forward</param>
        public void MovePlayerLocation(Player currentPlayer, int spacesForward)
        {
            // Get the player's current location
            int currentLocationSpotId = currentPlayer.CurrentLocation.SpotId;

            // Find the player's new location
            int newLocationSpotId = (spacesForward + currentLocationSpotId) % this.Board.Count;

            // Check to see if they passed Go
            this.CheckPassGo(this.Board[currentLocationSpotId], this.Board[newLocationSpotId], currentPlayer);

            // Change Current Location property of player to new location
            this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation = this.Board[newLocationSpotId];
        }

        /// <summary>
        /// Has given player pay rent for given spot
        /// </summary>
        /// <param name="currentPlayer">The player to pay rent</param>
        /// <param name="currentLocation">The location the player is at</param>
        public void CheckPayRent(Player currentPlayer, Spot currentLocation)
        {
            // Check to see if the current location is a property, railroad, or utility
            if (currentLocation.Type == SpotType.Property || currentLocation.Type == SpotType.Railroad ||
                currentLocation.Type == SpotType.Utility)
            {
                // If property is not mortgaged
                if (!currentLocation.IsMortgaged)
                {
                    // Find the owner
                    Player owner = currentLocation.Owner;

                    if (!currentLocation.IsAvailable && owner != currentPlayer)
                    {
                        // Find the rent
                        int rent = currentLocation.Rent;

                        // If the current location is a railroad
                        if (currentLocation.Type == SpotType.Railroad)
                        {
                            // Find the rent based on how many railroads the owner of the current location owns
                            rent = currentLocation.FindCurrentRentOfRailroad(this.Board);
                        }

                        // If the current location is a utility
                        if (currentLocation.Type == SpotType.Utility)
                        {
                            // Find the rent based on how many utilities the owner of the current location owns
                            // and the dice roll (random number)
                            rent = currentLocation.FindRentOfUtility(this.Board, currentPlayer);
                        }

                        // if the current location is a property with houses
                        if (currentLocation.Type == SpotType.Property)
                        {
                            rent = currentLocation.FindRentOfRegularProperty(this.Board);
                        }

                        if (currentPlayer.TotalNetWorth(this.Board) < rent)
                        {
                            MessageBox.Show("You do not have enough net worth to pay rent!", currentPlayer.PlayerName + " is bankrupt!");

                            // Get the value of the unmortgaged properties so they are not double counted in value 
                            // (mortgaged properties are not included in the total net worth)
                            int valueOfUnmortgagedProperties = 0;

                            // Only bother handing over properties if there are more than 2 players - otherwise the game is almost over
                            if (this.ActivePlayers() > 2)
                            {
                                // Hand over all properties
                                foreach (Spot property in currentPlayer.GetPlayersPropertyList(this.Board))
                                {
                                    this.Board[property.SpotId].Owner = owner;
                                    if (this.Board[property.SpotId].IsMortgaged)
                                    {
                                        // Pay interest on mortgaged property
                                        this.Players[this.Players.IndexOf(owner)].Money -=
                                            (int)(this.Board[property.SpotId].Price * 0.1);

                                        // Ask owner of current location if they would like to unmortgage received mortgaged property
                                        string message = property.SpotName + " is mortgaged. Do you want to unmortgage it now?\n";
                                        message += "If you choose later, interest will be paid twice.\n";
                                        message += owner.PlayerName + "'s current balance is " + owner.Money.ToString("c0") + " and the mortgage value of the property is " + property.Mortgage.ToString("c0") + ".";
                                        DialogResult result = MessageBox.Show(message, "Receive Property - " + owner.PlayerName, MessageBoxButtons.YesNo);
                                        if (result == DialogResult.Yes)
                                        {
                                            // Unmortgage property
                                            this.Board[property.SpotId].IsMortgaged = false;
                                            this.Players[this.Players.IndexOf(owner)].Money -= this.Board[property.SpotId].Mortgage;
                                        }
                                    }
                                    else
                                    {
                                        valueOfUnmortgagedProperties += property.Mortgage;
                                    }
                                }
                            }

                            // Give the owner everything
                            this.Players[this.Players.IndexOf(owner)].Money += currentPlayer.TotalNetWorth(this.Board) - valueOfUnmortgagedProperties;

                            // Have current player give up everything to pay rent
                            this.Players[this.Players.IndexOf(currentPlayer)].Money -= currentPlayer.TotalNetWorth(this.Board) - valueOfUnmortgagedProperties;
                            this.Forfeit(currentPlayer);
                        }
                        else
                        {
                            // Give the owner the rent
                            this.Players[this.Players.IndexOf(owner)].Money += rent;

                            // Have current player pay rent
                            this.Players[this.Players.IndexOf(currentPlayer)].Money -= rent;

                            // Check if current player could not afford rent
                            this.CheckIfPlayerHasEnoughMoney(currentPlayer);
                        } 
                    }
                }
            }
        }

        /// <summary>
        /// Returns a boolean indicating whether the spot landed on can be bought
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="currentLocation">The spot landed on</param>
        /// <returns>A boolean indicating whether the spot landed on can be bought</returns>
        public bool ShowBuyPropertyButton(Player currentPlayer, Spot currentLocation)
        {
            // Check to see if the current location is a property, railroad, or utility
            if (currentLocation.Type == SpotType.Property || currentLocation.Type == SpotType.Railroad ||
                currentLocation.Type == SpotType.Utility)
            {
                // Check to see whether the spot is available and player has enough money to buy it
                if (currentLocation.IsAvailable && currentPlayer.Money >= currentLocation.Price)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check to see if tax needs to be paid
        /// </summary>
        /// <param name="currentPlayer">Player to pay tax</param>
        /// <param name="currentLocation">Spot landed on</param>
        public void CheckPayTax(Player currentPlayer, Spot currentLocation)
        {
            if (currentLocation.Type == SpotType.Tax)
            {
                // TODO: or pay 10% - add form
                int tenPercent = (int)(currentPlayer.TotalNetWorth(this.Board) * .1);
                
                // Choose for the player whether the 200 or 10% of their total net worth is lower
                if (currentLocation.Rent > tenPercent)
                {
                    // Pay Tax
                    this.Players[this.Players.IndexOf(currentPlayer)].Money -= currentLocation.Rent;
                }
                else
                {
                    this.Players[this.Players.IndexOf(currentPlayer)].Money -= tenPercent;
                }

                // Check that player had enough money to pay tax
                this.CheckIfPlayerHasEnoughMoney(currentPlayer);
            }
        }

        /// <summary>
        /// Checks to see if player landed on "Go to Jail" and sends them to jail if yes
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="currentLocation">The spot landed on</param>
        public void CheckGoToJail(Player currentPlayer, Spot currentLocation)
        {
            if (currentLocation.Type == SpotType.GoToJail)
            {
                // Send player to Jail
                currentPlayer.SendToJail(this.GetSpotByName("Jail"));
            }
        }

        /// <summary>
        /// Finds a spot by using its name
        /// </summary>
        /// <param name="name">The name of the spot</param>
        /// <returns>The spot that has the given name</returns>
        public Spot GetSpotByName(string name)
        {
            // Loop through the spots on the board
            foreach (Spot spot in this.Board)
            {
                // If the current spot name equals the given name
                if (spot.SpotName == name)
                {
                    // return that spot
                    return spot;
                }
            }

            // no spot with that name was found
            return null;
        }

        /// <summary>
        /// Does the actions of the Chance and Community Chest cards
        /// </summary>
        /// <param name="pile">The card pile the card drawn is from</param>
        /// <param name="currentPlayer">The player's whose turn it is</param>
        public void DrawCard(List<Card> pile, Player currentPlayer)
        {
            Card top = pile[0];

            if (top.GetOutOfJailFree)
            {
                // Card is a get out of jail free card
                this.Players[this.Players.IndexOf(currentPlayer)].GetOutOfJailFreeCards.Add(top);
                if (top.Type == CardType.Chance)
                {
                    this.ChanceCards.Remove(top);
                }
                else
                {
                    this.CommunityChestCards.Remove(top);
                }
            }
            else if (top.Amount > 0)
            {
                // Card involves collecting or paying money
                if (top.Collect)
                {
                    // Player collects money
                    if (top.Bank)
                    {
                        // Money is collected from the bank
                        this.Players[this.Players.IndexOf(currentPlayer)].Money += top.Amount;
                    }
                    else
                    {
                        // Money is collected from other players
                        for (int i = 0; i < this.Players.Count; i++)
                        {
                            if (this.Players[i] == currentPlayer)
                            {
                                // Give current player the amount listed on the card times the number of other players
                                this.Players[this.Players.IndexOf(currentPlayer)].Money += top.Amount * (this.Players.Count - 1);
                            }
                            else
                            {
                                // Collect money from player still in the game
                                if (this.Players[i].IsActive)
                                {
                                    // Take money from other players
                                    this.Players[i].Money -= top.Amount;

                                    // Check if player cannot afford to pay current player
                                    this.CheckIfPlayerHasEnoughMoney(this.Players[i]);
                                }
                            }
                        }
                    }

                    // Move card to bottom of pile
                    this.MoveCardToBottomOfPile(top);
                }
                else
                {
                    // Player pays money
                    if (top.Bank)
                    {
                        if (top.Description.Contains("general repairs"))
                        {
                            foreach (Spot s in currentPlayer.GetPlayersPropertyList(this.Board))
                            {
                                this.Players[this.Players.IndexOf(currentPlayer)].Money -= s.NumberOfHouses * 25;
                                if (s.HasHotel)
                                {
                                    this.Players[this.Players.IndexOf(currentPlayer)].Money -= 100;
                                }
                            }
                        }
                        else if (top.Description.Contains("street repairs"))
                        {
                            foreach (Spot s in currentPlayer.GetPlayersPropertyList(this.Board))
                            {
                                this.Players[this.Players.IndexOf(currentPlayer)].Money -= s.NumberOfHouses * 40;
                                if (s.HasHotel)
                                {
                                    this.Players[this.Players.IndexOf(currentPlayer)].Money -= 115;
                                }
                            }
                        }
                        else
                        {
                            // Money is paid to the bank
                            this.Players[this.Players.IndexOf(currentPlayer)].Money -= top.Amount;
                        }

                        // Check if current player cannot afford to pay other players
                        this.CheckIfPlayerHasEnoughMoney(currentPlayer);
                    }
                    else
                    {
                        // Money is paid to other players
                        for (int i = 0; i < this.Players.Count; i++)
                        {
                            if (this.Players[i] == currentPlayer)
                            {
                                // Current player pays the amount listed on the card times the number of other players
                                this.Players[this.Players.IndexOf(currentPlayer)].Money -= top.Amount * (this.ActivePlayers() - 1);

                                // Check if current player cannot afford to pay other players
                                this.CheckIfPlayerHasEnoughMoney(currentPlayer);
                            }
                            else
                            {
                                // Give the other players the amount the card says
                                this.Players[i].Money += top.Amount;
                            }
                        }
                    }

                    // Move card to bottom of pile
                    this.MoveCardToBottomOfPile(top);
                }
            }
            else
            {
                // Card is a movement card
                if (top.NewLocation == null)
                {
                    if (top.Description.Contains("Railroad"))
                    {
                        // Find the nearest railroad
                        top.NewLocation = currentPlayer.CurrentLocation.FindNearestSpotOfGivenType(this.Board, SpotType.Railroad);
                    }
                    else if (top.Description.Contains("Utility"))
                    {
                        // Find the nearest utility
                        top.NewLocation = currentPlayer.CurrentLocation.FindNearestSpotOfGivenType(this.Board, SpotType.Utility);
                    }
                    else
                    {
                        // Card is go back 3 spaces
                        int index = this.Board.IndexOf(currentPlayer.CurrentLocation);
                        index = (index - 3 + this.Board.Count) % this.Board.Count;
                        top.NewLocation = this.Board[index];
                    }
                }

                if (top.NewLocation.Type != SpotType.Jail)
                {
                    // If player was not sent to jail, check to see if they passed Go
                    this.CheckPassGo(this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation, top.NewLocation, currentPlayer);

                    // Reset player's current location
                    this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation = top.NewLocation;
                }
                else
                {
                    // Send player to jail
                    currentPlayer.SendToJail(this.GetSpotByName("Jail"));
                }        

                // Move card to bottom of pile
                this.MoveCardToBottomOfPile(top);
            }
        }

        /// <summary>
        /// Returns the number of players still playing
        /// </summary>
        /// <returns>Number of players still playing</returns>
        public int ActivePlayers()
        {
            int playerCount = 0;

            foreach (Player player in this.Players)
            {
                if (player.IsActive)
                {
                    playerCount++;
                }
            }

            return playerCount;
        }

        /// <summary>
        /// Gets a player out of jail and adds the "get out of jail free" card back into its deck
        /// </summary>
        /// <param name="currentPlayer">The player who is using the card</param>
        public void PlayGetOutOfJailFreeCard(Player currentPlayer)
        {
            // Set current player's in jail status to false
            this.Players[this.Players.IndexOf(currentPlayer)].InJail = false;

            // Get the first card from current players "get out of jail free" card list
            // list should be checked for not empty before this method is called
            Card card = this.Players[this.Players.IndexOf(currentPlayer)].GetOutOfJailFreeCards[0];

            // Remove "get out of jail free" card from player
            this.Players[this.Players.IndexOf(currentPlayer)].GetOutOfJailFreeCards.Remove(card);

            // Check to see if the card was from the chance or community chest pile
            if (card.Type == CardType.Chance)
            {
                // Add the card back to the chance pile
                this.ChanceCards.Add(card);
            }
            else
            {
                // Add the card back to the community chest pile
                this.CommunityChestCards.Add(card);
            }
        }

        /// <summary>
        /// Moves a card to the bottom of its pile
        /// </summary>
        /// <param name="top">The card that was on top of the pile</param>
        public void MoveCardToBottomOfPile(Card top)
        {
            if (top.Type == CardType.Chance)
            {
                this.ChanceCards.Remove(top);
                this.ChanceCards.Add(top);
            }
            else
            {
                this.CommunityChestCards.Remove(top);
                this.CommunityChestCards.Add(top);
            }
        }

        /// <summary>
        /// Finds the next player whose turn it would be and returns them
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>The player whose turn it would be next</returns>
        public Player NextPlayer(Player currentPlayer)
        {
            // Find the index of the current player in the Players list
            int index = currentPlayer.PlayerId;

            do
            {
                // Increase the index by one and mod it by the number of players
                index = (index + 1) % this.Players.Count;
            }
            while (!this.Players[index].IsActive);
            
            // Return the player with the calculated index
            return this.Players[index];
        }

        /// <summary>
        /// Checks the cash and total net worth of a player to determine the players options
        /// if they cannot pay (are they bankrupt or do they have to sell something)
        /// </summary>
        /// <param name="player">The player</param>
        public void CheckIfPlayerHasEnoughMoney(Player player)
        {
            if (player.NeedMoreMoney() && player.TotalNetWorth(this.Board) > 0)
            {
                GetMoney money = new GetMoney(this, player, player.Money * -1);
                money.ShowDialog();
            }
            else if (player.NeedMoreMoney() && player.TotalNetWorth(this.Board) <= 0)
            {
                // Player is bankrupt
                MessageBox.Show(player.PlayerName + " is bankrupt!");
                this.Forfeit(player);
            }
        }

        /// <summary>
        /// Removes a player from the game and resets any properties they may have
        /// </summary>
        /// <param name="player">The player to remove</param>
        public void Forfeit(Player player)
        {
            // Get the player's list of properties
            List<Spot> properties = player.GetPlayersPropertyList(this.Board);

            // If the player still owns properties
            if (properties.Count > 0)
            {
                // Loop through the properties they own
                foreach (Spot property in properties)
                {
                    // Reset values of property so property is not owned
                    property.Owner = null;
                    property.IsAvailable = true;
                    property.HasHotel = false;
                    property.NumberOfHouses = 0;
                    property.IsMortgaged = false;

                    // Set the spot on the board to the spot with changed values
                    this.Board[property.SpotId] = property;
                }
            }

            // Set player to inactive
            player.IsActive = false;
            player.PlayerPictureBox.Visible = false;

            // Get the next player
            this.NextPlayer(player);

            if (this.ActivePlayers() == 1)
            {
                foreach (Player p in this.Players)
                {
                    if (p.IsActive)
                    {
                        DialogResult result = MessageBox.Show("Do you want to play again?", p.PlayerName + " has won!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            this.RestartGame = true;
                        }
                        else
                        {
                            Application.Exit();
                        }

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of colors for every property that is eligible for a house.
        /// </summary>
        /// <param name="prop">The players properties</param>
        /// <returns>A list of colors</returns>
        public static List<Color> CheckIfEligibleForHouse(List<Spot> prop)
        {
            // create a list of colors to hold which colors are eligible for houses 
            List<Color> houseOkay = new List<Color>();

            // Create counters for every color
            int numPurple = 0; // out of 2
            int numLightBlue = 0; // out of 3
            int numPink = 0; // out of 3
            int numOrange = 0; // out of 3
            int numRed = 0; // out of 3
            int numYellow = 0; // out of 3
            int numGreen = 0; // out of 3
            int numDarkBlue = 0; // out of 2

            // Check through the list and add each color to the respective counter
            foreach (Spot s in prop)
            {
                if (s.Color == Color.Purple)
                {
                    numPurple++;
                }
                else if (s.Color == Color.LightBlue)
                {
                    numLightBlue++;
                }
                else if (s.Color == Color.MediumVioletRed)
                {
                    numPink++;
                }
                else if (s.Color == Color.DarkOrange)
                {
                    numOrange++;
                }
                else if (s.Color == Color.Red)
                {
                    numRed++;
                }
                else if (s.Color == Color.Yellow)
                {
                    numYellow++;
                }
                else if (s.Color == Color.Green)
                {
                    numGreen++;
                }
                else if (s.Color == Color.DarkBlue)
                {
                    numDarkBlue++;
                }
            }

            // Check each color to see if they have all of one color THEN ADD IT TO THE COLOR LIST
            if (numPurple == 2)
            {
                houseOkay.Add(Color.Purple);
            }

            if (numLightBlue == 3)
            {
                houseOkay.Add(Color.LightBlue);
            }

            if (numPink == 3)
            {
                houseOkay.Add(Color.MediumVioletRed);
            }

            if (numOrange == 3)
            {
                houseOkay.Add(Color.DarkOrange);
            }

            if (numRed == 3)
            {
                houseOkay.Add(Color.Red);
            }

            if (numYellow == 3)
            {
                houseOkay.Add(Color.Yellow);
            }

            if (numGreen == 3)
            {
                houseOkay.Add(Color.Green);
            }

            if (numDarkBlue == 2)
            {
                houseOkay.Add(Color.DarkBlue);
            }

            // return the list
            return houseOkay;
        }

        /// <summary>
        /// Randomizes the cards in a deck
        /// </summary>
        public void RandomizedCards()
        {
            // Randomize Chance
            Card c = new Card(1, null, CardType.Chance, null);
            Random rng = new Random();
            int n = this.ChanceCards.Count;
            while (n >= 1)
            {
                n--;
                int k = rng.Next(n + 1);
                c = this.ChanceCards[k];
                this.RandomizedChanceCards.Add(c);
                this.ChanceCards.Remove(c);
            }

            n = this.RandomizedChanceCards.Count;
            while (n >= 1)
            {
                n--;
                c = this.RandomizedChanceCards[n];
                this.RandomizedChanceCards.Remove(c);
                this.ChanceCards.Add(c);
            }

            // Randomize Community Chest
            c = new Card(1, null, CardType.CommunityChest, null);
            n = this.CommunityChestCards.Count;
            while (n >= 1)
            {
                n--;
                int k = rng.Next(n + 1);
                c = this.CommunityChestCards[k];
                this.RandomizedCommunityChestCards.Add(c);
                this.CommunityChestCards.Remove(c);
            }

            n = this.RandomizedCommunityChestCards.Count;
            while (n >= 1)
            {
                n--;
                c = this.RandomizedCommunityChestCards[n];
                this.RandomizedCommunityChestCards.Remove(c);
                this.CommunityChestCards.Add(c);
            }
        }

        /// <summary>
        /// The method used to instantiate the spots
        /// </summary>
        public void InstantiateList()
        {
            // First Row
            Spot temp = new Spot(0, "Go", SpotType.Go);
            this.Board.Add(temp);

            temp = new Spot(1, "Mediterranean Avenue", Color.Purple, 60, 2, 10, 30, 90, 160, 250, 30, 50, 50);
            this.Board.Add(temp);

            temp = new Spot(2, "Community Chest #1", SpotType.CommunityChest);
            this.Board.Add(temp);

            temp = new Spot(3, "Baltic Avenue", Color.Purple, 60, 4, 20, 60, 180, 320, 450, 30, 50, 50);
            this.Board.Add(temp);

            temp = new Spot(4, "Income Tax", 200);
            this.Board.Add(temp);

            temp = new Spot(5, "Reading Railroad", SpotType.Railroad, 200, 25);
            this.Board.Add(temp);

            temp = new Spot(6, "Oriental Avenue", Color.LightBlue, 100, 6, 30, 90, 270, 400, 550, 50, 50, 50);
            this.Board.Add(temp);

            temp = new Spot(7, "Chance #1", SpotType.Chance);
            this.Board.Add(temp);

            temp = new Spot(8, "Vermont Avenue", Color.LightBlue, 100, 6, 30, 90, 270, 400, 550, 50, 50, 50);
            this.Board.Add(temp);

            temp = new Spot(9, "Connecticut Avenue", Color.LightBlue, 120, 8, 40, 100, 300, 450, 600, 60, 50, 50);
            this.Board.Add(temp);

            // Second Row
            temp = new Spot(10, "Jail", SpotType.Jail);
            this.Board.Add(temp);

            temp = new Spot(11, "St. Charles Place", Color.MediumVioletRed, 140, 10, 50, 150, 450, 625, 750, 70, 100, 100);
            this.Board.Add(temp);

            temp = new Spot(12, "Electric Company", SpotType.Utility, 150, 75);
            this.Board.Add(temp);

            temp = new Spot(13, "States Avenue", Color.MediumVioletRed, 140, 10, 50, 150, 450, 625, 750, 70, 100, 100);
            this.Board.Add(temp);

            temp = new Spot(14, "Virginia Avenue", Color.MediumVioletRed, 160, 12, 60, 180, 500, 700, 900, 80, 100, 100);
            this.Board.Add(temp);

            temp = new Spot(15, "Pennsylvania Railroad", SpotType.Railroad, 200, 25);
            this.Board.Add(temp);

            temp = new Spot(16, "St. James Place", Color.DarkOrange, 180, 14, 70, 200, 550, 750, 950, 90, 100, 100);
            this.Board.Add(temp);

            temp = new Spot(17, "Community Chest #2", SpotType.CommunityChest);
            this.Board.Add(temp);

            temp = new Spot(18, "Tennessee Avenue", Color.DarkOrange, 180, 14, 70, 200, 550, 750, 950, 90, 100, 100);
            this.Board.Add(temp);

            temp = new Spot(19, "New York Avenue", Color.DarkOrange, 200, 16, 80, 220, 600, 800, 1000, 100, 100, 100);
            this.Board.Add(temp);

            // Third Row
            temp = new Spot(20, "Free Parking", SpotType.FreeParking);
            this.Board.Add(temp);

            temp = new Spot(21, "Kentucky Avenue", Color.Red, 220, 18, 90, 250, 700, 875, 1050, 110, 150, 150);
            this.Board.Add(temp);

            temp = new Spot(22, "Chance #2", SpotType.Chance);
            this.Board.Add(temp);

            temp = new Spot(23, "Indiana Avenue", Color.Red, 220, 18, 90, 250, 700, 875, 1050, 110, 150, 150);
            this.Board.Add(temp);

            temp = new Spot(24, "Illinois Avenue", Color.Red, 240, 20, 100, 300, 750, 925, 1100, 120, 150, 150);
            this.Board.Add(temp);

            temp = new Spot(25, "B. & O. Railroad", SpotType.Railroad, 200, 25);
            this.Board.Add(temp);

            temp = new Spot(26, "Atlantic Avenue", Color.Yellow, 260, 22, 110, 330, 800, 975, 1150, 130, 150, 150);
            this.Board.Add(temp);

            temp = new Spot(27, "Ventnor Avenue", Color.Yellow, 260, 22, 110, 330, 800, 975, 1150, 130, 150, 150);
            this.Board.Add(temp);

            temp = new Spot(28, "Water Works", SpotType.Utility, 150, 75);
            this.Board.Add(temp);

            temp = new Spot(29, "Marvin Gardens", Color.Yellow, 280, 24, 120, 360, 850, 1025, 1200, 140, 150, 150);
            this.Board.Add(temp);

            // Fourth Row
            temp = new Spot(30, "Go To Jail", SpotType.GoToJail);
            this.Board.Add(temp);

            temp = new Spot(31, "Pacific Avenue", Color.Green, 300, 26, 130, 390, 900, 1100, 1275, 150, 200, 200);
            this.Board.Add(temp);

            temp = new Spot(32, "North Carolina Avenue", Color.Green, 300, 26, 130, 390, 900, 1100, 1275, 150, 200, 200);
            this.Board.Add(temp);

            temp = new Spot(33, "Community Chest #3", SpotType.CommunityChest);
            this.Board.Add(temp);

            temp = new Spot(34, "Pennsylvania Avenue", Color.Green, 320, 28, 150, 450, 1000, 1200, 1400, 160, 200, 200);
            this.Board.Add(temp);

            temp = new Spot(35, "Short Line", SpotType.Railroad, 200, 25);
            this.Board.Add(temp);

            temp = new Spot(36, "Chance #3", SpotType.Chance);
            this.Board.Add(temp);

            temp = new Spot(37, "Park Place", Color.DarkBlue, 350, 35, 175, 500, 1100, 1300, 1500, 175, 200, 200);
            this.Board.Add(temp);

            temp = new Spot(38, "Luxury Tax", 200);
            this.Board.Add(temp);

            temp = new Spot(39, "Boardwalk", Color.DarkBlue, 400, 50, 200, 600, 1400, 1700, 2000, 200, 200, 200);
            this.Board.Add(temp);
        }

        /// <summary>
        /// The method used to create the chance and community chest cards
        /// </summary>
        /// <param name="chanceImages">ImageList of change cards</param>
        /// <param name="communityChestImages">ImageList of community chest cards</param>
        public void CreateCards(ImageList chanceImages, ImageList communityChestImages)
        {
            // Chance Cards
            Card tempCard = new Card(0, "Advance To Go", CardType.Chance, this.Board[0], chanceImages.Images[0]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(1, "Advance to Illinois Ave", CardType.Chance, this.Board[23], chanceImages.Images[1]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(2, "Advance to St. Charles Place", CardType.Chance, this.Board[11], chanceImages.Images[2]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(3, "Advance token to nearest Utility", CardType.Chance, null, chanceImages.Images[3]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(4, "Advance token to the nearest Railroad", CardType.Chance, null, chanceImages.Images[4]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(5, "Advance token to the nearest Railroad", CardType.Chance, null, chanceImages.Images[4]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(6, "Bank pays you dividend of $50", CardType.Chance, 50, true, true, chanceImages.Images[5]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(7, "Get out of Jail Free", CardType.Chance, chanceImages.Images[6]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(8, "Go Back Three Spaces", CardType.Chance, null, chanceImages.Images[7]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(9, "Go directly to Jail", CardType.Chance, this.Board[10], chanceImages.Images[8]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(10, "Make general repairs on all your property", CardType.Chance, chanceImages.Images[9]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(11, "Pay poor tax of $15", CardType.Chance, 15, true, false, chanceImages.Images[10]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(12, "Take a trip to Reading Railroad", CardType.Chance, this.Board[5], chanceImages.Images[11]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(13, "Take a walk on the Boardwalk", CardType.Chance, this.Board[39], chanceImages.Images[12]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(14, "You have been elected Chairman of the Board", CardType.Chance, 50, false, false, chanceImages.Images[13]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(15, "Your building and loan matures", CardType.Chance, 150, true, true, chanceImages.Images[14]);
            this.ChanceCards.Add(tempCard);

            tempCard = new Card(16, "You have won a crossword competition", CardType.Chance, 100, true, true, chanceImages.Images[15]);
            this.ChanceCards.Add(tempCard);

            // Community Chest Cards
            tempCard = new Card(0, "Advance To Go", CardType.CommunityChest, this.Board[0], communityChestImages.Images[0]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(1, "Doctor's fees", CardType.CommunityChest, 50, true, false, communityChestImages.Images[1]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(2, "Get Out of Jail Free", CardType.CommunityChest, communityChestImages.Images[2]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(3, "Go to Jail", CardType.CommunityChest, this.Board[10], communityChestImages.Images[3]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(4, "Grand Opera Night", CardType.CommunityChest, 50, false, true, communityChestImages.Images[4]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(5, "Holiday Fund matures", CardType.CommunityChest, 100, true, true, communityChestImages.Images[5]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(6, "Income tax refund", CardType.CommunityChest, 20, true, true, communityChestImages.Images[6]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(7, "It is your birthday", CardType.CommunityChest, 10, false, true, communityChestImages.Images[7]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(8, "Life insurance matures", CardType.CommunityChest, 100, true, true, communityChestImages.Images[8]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(9, "Hospital Fees", CardType.CommunityChest, 50, true, false, communityChestImages.Images[9]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(10, "School fees", CardType.CommunityChest, 50, true, false, communityChestImages.Images[10]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(11, "Receive $25 consultancy fee", CardType.CommunityChest, 25, true, true, communityChestImages.Images[11]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(12, "You have won second prize in a beauty contest", CardType.CommunityChest, 10, true, true, communityChestImages.Images[12]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(13, "You inherit $100", CardType.CommunityChest, 100, true, true, communityChestImages.Images[13]);
            this.CommunityChestCards.Add(tempCard);

            tempCard = new Card(14, "You are assessed for street repairs", CardType.CommunityChest, 40, true, false, communityChestImages.Images[14]);
            this.CommunityChestCards.Add(tempCard);
        }

        /// <summary>
        /// Returns the list of a player's properties that have hotels on them
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>The list of properties with hotels on them</returns>
        public List<Spot> GetListOfPlayersPropertiesWithHotel(Player currentPlayer)
        {
            // Declare and initialize a list of spots
            List<Spot> propertiesWithHotel = new List<Spot>();

            // Get the current player's property list
            List<Spot> propertyList = currentPlayer.GetPlayersPropertyList(this.Board);

            // Loop through the given player's list of properties
            foreach (Spot property in propertyList)
            {
                // If that property has a hotel
                if (property.HasHotel)
                {
                    // Add property to list
                    propertiesWithHotel.Add(property);
                }
            }

            // return list that was created
            return propertiesWithHotel;
        }

        /// <summary>
        /// Returns the list of a player's properties that have at least one house on them
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>The list of properties with at least one house on them</returns>
        public List<Spot> GetListOfPlayersPropertiesWithHouses(Player currentPlayer)
        {
            // Declare and initialize a list of spots
            List<Spot> propertiesWithHouses = new List<Spot>();

            // Get the current player's property list
            List<Spot> propertyList = currentPlayer.GetPlayersPropertyList(this.Board);

            // Loop through the given player's list of properties
            foreach (Spot property in propertyList)
            {
                // If the number of houses is greater than zero
                if (property.NumberOfHouses > 0)
                {
                    // Add property to list
                    propertiesWithHouses.Add(property);
                }
            }

            // return list that was created
            return propertiesWithHouses;
        }

        /// <summary>
        /// Returns the list of a player's properties that are mortgageable
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>The list of properties that are mortgageable</returns>
        public List<Spot> GetListOfPlayersMortgageableProperties(Player currentPlayer)
        {
            // Declare and initialize a list of spots
            List<Spot> mortgageableProperties = new List<Spot>();

            // Get the current player's property list
            List<Spot> propertyList = currentPlayer.GetPlayersPropertyList(this.Board);

            // Loop through the given player's list of properties
            foreach (Spot property in propertyList)
            {
                // Declare a bool for whether a color group has all its properties not having houses
                bool colorGroupHasNoHouses = true;

                // If the number of houses is zero
                if (property.NumberOfHouses == 0)
                {
                    // Loop through the given player's list of properties
                    foreach (Spot p in propertyList)
                    {
                        // if the color of the property of the inner loop matches the color of the property of the outer loop
                        // and the number of houses of the property of  the inner loop is greater than zero
                        if (property.Color == p.Color && p.NumberOfHouses > 0)
                        {
                            // The color group does not have all its properties not having houses
                            colorGroupHasNoHouses = false;
                        }
                    }

                    // if the color group has all its properties not having houses
                    if (colorGroupHasNoHouses)
                    {
                        // Add property to list
                        mortgageableProperties.Add(property);
                    }
                }
            }

            // return list that was created
            return mortgageableProperties;
        }

        /// <summary>
        /// Method for checking if a player can purchase a property.
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="property">The selected property</param>
        public void PlayerBuysProperty(Player currentPlayer, Spot property)
        {
            if (property.IsAvailable && currentPlayer.Money >= property.Price)
            {
                DialogResult result = MessageBox.Show("Do you wish to buy " + property.SpotName + "?", string.Empty, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    property.Owner = currentPlayer;
                    currentPlayer.Money -= property.Price;
                    property.IsAvailable = false;
                }
            }
        }

        /// <summary>
        /// Checks to see if player landed on Chance and draws a Chance Card
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="currentLocation">The spot landed on</param>
        /// <returns>A boolean indicating whether the spot is a chance spot</returns>
        public bool CheckChance(Player currentPlayer, Spot currentLocation)
        {
            if (currentLocation.Type == SpotType.Chance)
            {
                // Draws a Card
                this.DrawCard(this.ChanceCards, currentPlayer);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if player landed on Chance and draws a Chance Card
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <param name="currentLocation">The spot landed on</param>
        /// <returns>A boolean indicating whether the spot is a community chest spot</returns>
        public bool CheckCommunityChest(Player currentPlayer, Spot currentLocation)
        {
            if (currentLocation.Type == SpotType.CommunityChest)
            {
                // Draws a Card
                this.DrawCard(this.CommunityChestCards, currentPlayer);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Finds a spot by using its id
        /// </summary>
        /// <param name="id">The id of the spot</param>
        /// <returns>The spot that has the given id</returns>
        public Spot GetSpotById(int id)
        {
            // Loop through the spots on the board
            foreach (Spot spot in this.Board)
            {
                // If the current spot name equals the given name
                if (spot.SpotId == id)
                {
                    // return that spot
                    return spot;
                }
            }

            // no spot with that name was found
            return null;
        }
    }
}

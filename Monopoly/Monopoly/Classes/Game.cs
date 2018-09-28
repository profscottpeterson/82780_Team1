namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Windows.Forms;

    public class Game
    {
        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        public Game()
        {
            // Construct all the properties  
            this.Board = new List<Spot>();
            this.instantiateList();

            // Construct all the chance cards
            this.ChanceCards = new List<Card>();

            // Construct all the community chest cards
            this.CommunityChestCards = new List<Card>();

            // Creates community and chance cards
            this.CreateCards();

            // Initialize the list of players
            this.Players = new List<Player>();

            // Only house rules change this - in official rules, free parking is just a safe space
            this.FreeParkingTotal = 0;
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
        /// Gets the list of community chest cards
        /// </summary>
        public List<Card> CommunityChestCards { get; }

        /// <summary>
        /// Gets or sets the list of players
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the amount of money that Free Parking has
        /// </summary>
        public int FreeParkingTotal { get; set; }

        /// <summary>
        /// Gets the list of properties a given player owns
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>The list of properties the given player owns</returns>
        public List<Spot> GetPlayersPropertyList(Player currentPlayer)
        {
            // Declare and initialize a list of Spots
            List<Spot> playersPropertyList = new List<Spot>();

            // Loop through all the spots on the board
            foreach (Spot spot in this.Board)
            {
                // if the spot's owner is the given player
                if (spot.Owner == currentPlayer)
                {
                    // add that spot to the list
                    playersPropertyList.Add(spot);
                }
            }

            // return the list
            return playersPropertyList;
        }

        /// <summary>
        /// Finds the nearest spot to the spot given that matches the spot type given
        /// </summary>
        /// <param name="currentLocation">The player's current location</param>
        /// <param name="type">The type of spot to look for like property or railroad or utility</param>
        /// <returns>The nearest spot of given type</returns>
        public Spot FindNearestSpotOfGivenType(Spot currentLocation, SpotType type)
        {
            // Loop through the spots on the board starting at the one after the current one the player is on to the last spot on the board
            for (int i = currentLocation.SpotId + 1; i < this.Board.Count; i++)
            {
                // If the type of the current spot equals the type given as a parameter
                if (this.Board[i].Type == type)
                {
                    // return that spot
                    return this.Board[i];
                }
            }

            // Loop through the spots on the board starting at Go until the spot right before the spot the current player is on
            for (int i = 0; i < currentLocation.SpotId; i++)
            {
                // If the type of the current spot equals the type given as a parameter
                if (this.Board[i].Type == type)
                {
                    // return that spot
                    return this.Board[i];
                }
            }

            // No spot of given type was found
            return null;
        }

        /// <summary>
        /// Checks to see if the player passed Go, and adds 200 to their money if they did
        /// </summary>
        /// <param name="prevLocation">Where on the board the player was previously</param>
        /// <param name="currentLocation">Where on the board the player moved to</param>
        /// <param name="currentPlayer">The current player</param>
        public void CheckPassGo(Spot prevLocation, Spot currentLocation, Player currentPlayer)
        {
            if (prevLocation.SpotId > currentLocation.SpotId)
            {
                this.Players[this.Players.IndexOf(currentPlayer)].Money += 200;
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

        /// <summary>
        /// Does the actions of the Chance and Community Chest cards
        /// </summary>
        /// <param name="pile">The card pile the card drawn is from</param>
        /// <param name="currentPlayer">The player's whose turn it is</param>
        public void DrawCard(List<Card> pile, Player currentPlayer)
        {
            Card top = pile[0];

            if (top.GetOutOfJailFree == true)
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
                if (top.Collect == true)
                {
                    // Player collects money
                    if (top.Bank == true)
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
                                // Take money from other players
                                this.Players[i].Money -= top.Amount;
                            }
                        }
                    }

                    // Move card to bottom of pile
                    this.MoveCardToBottomOfPile(top);
                }
                else
                {
                    // Player pays money
                    if (top.Bank == true)
                    {
                        // Money is paid to the bank
                        this.Players[this.Players.IndexOf(currentPlayer)].Money -= top.Amount;
                    }
                    else
                    {
                        // Money is paid to other players
                        for (int i = 0; i < this.Players.Count; i++)
                        {
                            if (this.Players[i] == currentPlayer)
                            {
                                // Current player pays the amount listed on the card times the number of other players
                                this.Players[this.Players.IndexOf(currentPlayer)].Money -= top.Amount * (this.Players.Count - 1);
                            }
                            else
                            {
                                // Give the other players the amount the card says
                                this.Players[i].Money += top.Amount;
                            }
                        }
                    }
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
                        top.NewLocation = FindNearestSpotOfGivenType(this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation, SpotType.Railroad);
                    }
                    else if (top.Description.Contains("Utility"))
                    {
                        // Find the nearest utility
                        top.NewLocation = FindNearestSpotOfGivenType(this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation, SpotType.Utility);
                    }
                    else
                    {
                        // Card is go back 3 spaces
                        int index = this.Board.IndexOf(top.NewLocation);
                        index -= 3;
                        if (index < 0)
                        {
                            index = this.Board.Count + index - 1;
                        }

                        top.NewLocation = this.Board[index];
                    }
                }

                
                if (top.NewLocation.Type != SpotType.Jail)
                {
                    // If player was not sent to jail, check to see if they passed Go
                    this.CheckPassGo(this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation, top.NewLocation, currentPlayer);
                }

                this.Players[this.Players.IndexOf(currentPlayer)].CurrentLocation = top.NewLocation;

                // Move card to bottom of pile
                this.MoveCardToBottomOfPile(top);
            }
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
        /// Mortgages a given property
        /// </summary>
        /// <param name="currentPlayer">The owner of the property</param>
        /// <param name="property">The property to be mortgaged</param>
        public void MortageProperty(Player currentPlayer, Spot property)
        {
            // Set the is mortgaged value to true of the property in the Board's list of spots
            this.Board[this.Board.IndexOf(property)].IsMortgaged = true;

            // Give the current player the mortgage value of the given property
            this.Players[this.Players.IndexOf(currentPlayer)].Money += property.Mortgage;
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
            List<Spot> propertyList = this.GetPlayersPropertyList(currentPlayer);

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
            List<Spot> propertyList = this.GetPlayersPropertyList(currentPlayer);

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
            List<Spot> propertyList = this.GetPlayersPropertyList(currentPlayer);

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
        /// Finds the next player whose turn it would be and returns them
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>The player whose turn it would be next</returns>
        public Player NextPlayer(Player currentPlayer)
        {
            // Find the index of the current player in the Players list
            int index = currentPlayer.PlayerId;

            // Increment the index by one
            index++;

            // If index is greater than or equal to the count of the players list
            // (index would be out of bounds)
            if (index == this.Players.Count)
            {
                // Set index back to 0
                index = 0;
            }

            // Return the player with the calculated index
            return this.Players[index];
        }

        /// <summary>
        /// Method for checking if a player can purchase a property.
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <param name="property"></param>
        public void PlayerBuysProperty(Player currentPlayer, Spot property)
        {
            if (property.IsAvailable == true && currentPlayer.Money >= property.Price)
            {
                DialogResult result = MessageBox.Show("Do you wish to buy " + property.SpotName + "?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    property.Owner = currentPlayer;
                    currentPlayer.Money -= property.Price;
                    property.IsAvailable = false;
                }
            }
        }

        public void instantiateList()
        {
            //First Row
            Spot temp = new Spot(0, "Go", SpotType.Go);
            Board.Add(temp);

            temp = new Spot(1, "Mediteranean Avenue", Color.Brown, 60, 2, 10, 30, 90, 160, 250, 30, 50, 50);
            Board.Add(temp);

            temp = new Spot(2, "Community Chest #1", SpotType.CommunityChest);
            Board.Add(temp);

            temp = new Spot(3, "Baltic Avenue", Color.Brown, 60, 4, 20, 60, 180, 320, 450, 30, 50, 50);
            Board.Add(temp);

            temp = new Spot(4, "Income Tax", 200);
            Board.Add(temp);

            temp = new Spot(5, "Reading Railroad", SpotType.Railroad, 200, 100);
            Board.Add(temp);

            temp = new Spot(6, "Oriental Avenue", Color.LightBlue, 100, 6, 30, 90, 270, 400, 550, 50, 50, 50);
            Board.Add(temp);

            temp = new Spot(7, "Chance #1", SpotType.Chance);
            Board.Add(temp);

            temp = new Spot(8, "Vermont Avenue", Color.LightBlue, 100, 6, 30, 90, 270, 400, 550, 50, 50, 50);
            Board.Add(temp);

            temp = new Spot(9, "Connecticut Avenue", Color.LightBlue, 120, 8, 40, 100, 300, 450, 600, 60, 50, 50);
            Board.Add(temp);

            //Second Row
            temp = new Spot(10, "Jail", SpotType.Jail);
            Board.Add(temp);

            temp = new Spot(11, "St. Charles Place", Color.Pink, 140, 10, 50, 150, 450, 625, 750, 70, 100, 100);
            Board.Add(temp);

            temp = new Spot(12, "Electric Company", SpotType.Utility, 150, 75);
            Board.Add(temp);

            temp = new Spot(13, "States Avenue", Color.Pink, 140, 10, 50, 150, 450, 625, 750, 70, 100, 100);
            Board.Add(temp);

            temp = new Spot(14, "Virginia Avenue", Color.Pink, 160, 12, 60, 180, 500, 700, 900, 80, 100, 100);
            Board.Add(temp);

            temp = new Spot(15, "Pennsylvania Railroad", SpotType.Railroad, 200, 100);
            Board.Add(temp);

            temp = new Spot(16, "St. James Place", Color.Orange, 180, 14, 70, 200, 550, 750, 950, 90, 100, 100);
            Board.Add(temp);

            temp = new Spot(17, "Community Chest #2", SpotType.CommunityChest);
            Board.Add(temp);

            temp = new Spot(18, "Tennessee Avenue", Color.Orange, 180, 14, 70, 200, 550, 750, 950, 90, 100, 100);
            Board.Add(temp);

            temp = new Spot(19, "New York Avenue", Color.Orange, 200, 16, 80, 220, 600, 800, 1000, 100, 100, 100);
            Board.Add(temp);

            //Third Row
            temp = new Spot(20, "Free Parking", SpotType.FreeParking);
            Board.Add(temp);

            temp = new Spot(21, "Kentucky Avenue", Color.Red, 220, 18, 90, 250, 700, 875, 1050, 110, 150, 150);
            Board.Add(temp);

            temp = new Spot(22, "Chance #2", SpotType.Chance);
            Board.Add(temp);

            temp = new Spot(23, "Indiana Avenue", Color.Red, 220, 18, 90, 250, 700, 875, 1050, 110, 150, 150);
            Board.Add(temp);

            temp = new Spot(24, "Illinois Avenue", Color.Red, 240, 20, 100, 300, 750, 925, 1100, 120, 150, 150);
            Board.Add(temp);

            temp = new Spot(25, "B. & O. Railroad", SpotType.Railroad, 200, 100);
            Board.Add(temp);

            temp = new Spot(26, "Atlantic Avenue", Color.Yellow, 260, 22, 110, 330, 800, 975, 1150, 130, 150, 150);
            Board.Add(temp);

            temp = new Spot(27, "Ventnor Avenue", Color.Yellow, 260, 22, 110, 330, 800, 975, 1150, 130, 150, 150);
            Board.Add(temp);

            temp = new Spot(28, "Water Works", SpotType.Utility, 150, 75);
            Board.Add(temp);

            temp = new Spot(29, "Marvin Gardens", Color.Yellow, 280, 24, 120, 360, 850, 1025, 1200, 140, 150, 150);
            Board.Add(temp);

            //Fourth Row
            temp = new Spot(30, "Go To Jail", SpotType.GoToJail);
            Board.Add(temp);

            temp = new Spot(31, "Pacific Avenue", Color.Green, 300, 26, 130, 390, 900, 1100, 1275, 150, 200, 200);
            Board.Add(temp);

            temp = new Spot(32, "North Carolina Avenue", Color.Green, 300, 26, 130, 390, 900, 1100, 1275, 150, 200, 200);
            Board.Add(temp);

            temp = new Spot(33, "Community Chest #3", SpotType.CommunityChest);
            Board.Add(temp);

            temp = new Spot(34, "Pennsylvania Avenue", Color.Green, 320, 28, 150, 450, 1000, 1200, 1400, 160, 200, 200);
            Board.Add(temp);

            temp = new Spot(35, "Short Line", SpotType.Railroad, 200, 100);
            Board.Add(temp);

            temp = new Spot(36, "Chance #3", SpotType.Chance);
            Board.Add(temp);

            temp = new Spot(37, "Park Place", Color.DarkBlue, 350, 35, 175, 500, 1100, 1300, 1500, 175, 200, 200);
            Board.Add(temp);

            temp = new Spot(38, "Luxury Tax", 200);
            Board.Add(temp);

            temp = new Spot(39, "Boardwalk", Color.DarkBlue, 400, 50, 200, 600, 1400, 1700, 2000, 200, 200, 200);
            Board.Add(temp);
        }

        public void CreateCards()
        {
            // Chance Cards

            Card TempCard = new Card(0, "Advance To Go", CardType.Chance, Board[0]);
            ChanceCards.Add(TempCard);

            TempCard = new Card(1, "Advance to Illinois Ave", CardType.Chance, Board[23]);
            ChanceCards.Add(TempCard);

            TempCard = new Card(2, "Advance to St. Charles Place", CardType.Chance, Board[11]);
            ChanceCards.Add(TempCard);

            TempCard = new Card(3, "Advance token to nearest Utility", CardType.Chance, null);
            ChanceCards.Add(TempCard);

            TempCard = new Card(4, "Advance token to the nearest Railroad", CardType.Chance, null);
            ChanceCards.Add(TempCard);

            TempCard = new Card(5, "Advance token to the nearest Railroad", CardType.Chance, null);
            ChanceCards.Add(TempCard);

            TempCard = new Card(6, "Bank pays you dividend of $50", CardType.Chance, 50, true, false);
            ChanceCards.Add(TempCard);

            TempCard = new Card(7, "Get out of Jail Free", CardType.Chance);
            ChanceCards.Add(TempCard);

            TempCard = new Card(8, "Go Back Three Spaces", CardType.Chance, null);
            ChanceCards.Add(TempCard);

            TempCard = new Card(9, "Go directly to Jail", CardType.Chance, Board[10]);
            ChanceCards.Add(TempCard);

            TempCard = new Card(10, "Make general repairs on all your property", CardType.Chance);
            ChanceCards.Add(TempCard);

            TempCard = new Card(11, "Pay poor tax of $15", CardType.Chance, 15, true, true);
            ChanceCards.Add(TempCard);

            TempCard = new Card(12, "Take a trip to Reading Railroad", CardType.Chance, Board[5]);
            ChanceCards.Add(TempCard);

            TempCard = new Card(13, "Take a walk on the Boardwalk", CardType.Chance, Board[39]);
            ChanceCards.Add(TempCard);

            TempCard = new Card(14, "You have been elected Chairman of the Board", CardType.Chance, 50, false, false);
            ChanceCards.Add(TempCard);

            TempCard = new Card(15, "Your building {and} loan matures", CardType.Chance, 150, true, true);
            ChanceCards.Add(TempCard);

            TempCard = new Card(16, "You have won a crossword competition", CardType.Chance, 100, true, true);
            ChanceCards.Add(TempCard);

            //Community Chest Cards

            TempCard = new Card(0, "Advance To Go", CardType.CommunityChest, Board[0]);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(1, "Doctor's fees", CardType.CommunityChest, 50, true, false);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(2, "Get Out of Jail Free", CardType.CommunityChest);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(3, "Go to Jail", CardType.CommunityChest, Board[10]);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(4, "Grand Opera Night", CardType.CommunityChest, 50, false, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(5, "Holiday Fund matures", CardType.CommunityChest, 100, true, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(6, "Income tax refund", CardType.CommunityChest, 20, true, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(7, "It is your birthday", CardType.CommunityChest, 10, false, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(8, "Life insurance matures", CardType.CommunityChest, 100, true, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(9, "Hospital Fees", CardType.CommunityChest, 50, true, false);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(10, "School fees", CardType.CommunityChest, 50, true, false);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(11, "Receive $25 consultancy fee", CardType.CommunityChest, 25, true, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(12, "You have won second prize in a beauty contest", CardType.CommunityChest, 10, true, true);
            CommunityChestCards.Add(TempCard);

            TempCard = new Card(13, "You inherit $100", CardType.CommunityChest, 100, true, true);
            CommunityChestCards.Add(TempCard);
        }
    }
}

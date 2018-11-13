//-----------------------------------------------------------------------
// <copyright file="Spot.cs" company="null">
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

    /// <summary>
    /// The class for a spot
    /// </summary>
    public class Spot
    {
        /// <summary>
        /// Initializes a new instance of the Spot class.
        /// Use for Chance, Community Chest, Go, Jail, Go to Jail, Free Parking
        /// </summary>
        /// <param name="spotId">The id of the spot</param>
        /// <param name="spotName">The name of the spot</param>
        /// <param name="type">The type of spot</param>
        public Spot(int spotId, string spotName, SpotType type)
        {
            this.SpotId = spotId;
            this.SpotName = spotName;
            this.Type = type;
            this.Color = Color.Black;
            this.Price = 0;
            this.Rent = 0;
            this.Rent1House = 0;
            this.Rent2Houses = 0;
            this.Rent3Houses = 0;
            this.Rent4Houses = 0;
            this.RentHotel = 0;
            this.Mortgage = 0;
            this.HouseCost = 0;
            this.HotelCost = 0;
            this.IsAvailable = true;
            this.IsMortgaged = false;
            this.NumberOfHouses = 0;
            this.HasHotel = false;
            this.Owner = null;
            this.SpotBox = new PictureBox();
        }

        /// <summary>
        /// Initializes a new instance of the Spot class.
        /// Use for tax spots
        /// </summary>
        /// <param name="spotId">The id of the spot</param>
        /// <param name="spotName">The name of the spot</param>
        /// <param name="rent">The amount paid to the bank for landing on that spot</param>
        public Spot(int spotId, string spotName, int rent)
        {
            this.SpotId = spotId;
            this.SpotName = spotName;
            this.Type = SpotType.Tax;
            this.Color = Color.Black;
            this.Price = 0;
            this.Rent = rent;
            this.Rent1House = 0;
            this.Rent2Houses = 0;
            this.Rent3Houses = 0;
            this.Rent4Houses = 0;
            this.RentHotel = 0;
            this.Mortgage = 0;
            this.HouseCost = 0;
            this.HotelCost = 0;
            this.IsAvailable = true;
            this.IsMortgaged = false;
            this.NumberOfHouses = 0;
            this.HasHotel = false;
            this.Owner = null;
            this.SpotBox = new PictureBox();
        }

        /// <summary>
        /// Initializes a new instance of the Spot class.
        /// Use for railroads and utilities
        /// </summary>
        /// <param name="spotId">The id of the spot</param>
        /// <param name="spotName">The name of the spot</param>
        /// <param name="type">The type of spot</param>
        /// <param name="price">The price to buy the property</param>
        /// <param name="rent">The amount a player pays when they land on a property that is owned by another player</param>
        public Spot(int spotId, string spotName, SpotType type, int price, int rent)
        {
            this.SpotId = spotId;
            this.SpotName = spotName;
            this.Type = type;
            this.Color = Color.Black;
            this.Price = price;
            this.Rent = rent;
            this.Rent1House = 0;
            this.Rent2Houses = 0;
            this.Rent3Houses = 0;
            this.Rent4Houses = 0;
            this.RentHotel = 0;
            this.HouseCost = 0;
            this.HotelCost = 0;
            this.IsAvailable = true;
            this.IsMortgaged = false;
            this.NumberOfHouses = 0;
            this.HasHotel = false;
            this.Owner = null;
            this.SpotBox = new PictureBox();

            if (type == SpotType.Railroad)
            {
                this.Mortgage = 100;
            }
            else if (type == SpotType.Utility)
            {
                this.Mortgage = 75;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Spot class.
        /// </summary>
        /// <param name="spotId">The spot ID</param>
        /// <param name="spotName">The spot name</param>
        /// <param name="color">The spot color</param>
        /// <param name="price">The price to buy a property</param>
        /// <param name="rent">The price a player pays if they land on someone else's property without buildings</param>
        /// <param name="rent1House">The price a player pays when they land on someone else's property and it has one house</param>
        /// <param name="rent2Houses">The price a player pays when they land on someone else's property and it has two houses</param>
        /// <param name="rent3Houses">The price a player pays when they land on someone else's property and it has three houses</param>
        /// <param name="rent4Houses">The price a player pays when they land on someone else's property and it has four houses</param>
        /// <param name="rentHotel">The price a player pays when they land on someone else's property and it has a hotel</param>
        /// <param name="mortgage">The price of a property's mortgage</param>
        /// <param name="houseCost">The cost to buy a house</param>
        /// <param name="hotelCost">The cost to buy a hotel</param>
        public Spot(
               int spotId, 
               string spotName, 
               Color color, 
               int price, 
               int rent, 
               int rent1House,
               int rent2Houses, 
               int rent3Houses, 
               int rent4Houses, 
               int rentHotel, 
               int mortgage, 
               int houseCost, 
               int hotelCost)
        {
            this.SpotId = spotId;
            this.SpotName = spotName;
            this.Color = color;
            this.Price = price;
            this.Rent = rent;
            this.Rent1House = rent1House;
            this.Rent2Houses = rent2Houses;
            this.Rent3Houses = rent3Houses;
            this.Rent4Houses = rent4Houses;
            this.RentHotel = rentHotel;
            this.Mortgage = mortgage;
            this.HouseCost = houseCost;
            this.HotelCost = hotelCost;
            this.IsAvailable = true;
            this.IsMortgaged = false;
            this.NumberOfHouses = 0;
            this.Type = SpotType.Property;
            this.Owner = null;
            this.SpotBox = new PictureBox();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Spot"/> class.
        /// </summary>
        public Spot()
        {
        }

        /// <summary>
        /// Gets the ID of the spot
        /// </summary>
        public int SpotId { get; }

        /// <summary>
        /// Gets the name of the spot
        /// </summary>
        public string SpotName { get; }

        /// <summary>
        /// Gets the type of spot the spot is
        /// </summary>
        public SpotType Type { get; }

        /// <summary>
        /// Gets the spot's (normally is a property) color
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// Gets the price to buy the property
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Gets the price a player pays when they land on someone else's property without buildings
        /// </summary>
        public int Rent { get; }

        /// <summary>
        /// Gets the price a player pays when they land on someone else's property and it has one house
        /// </summary>
        public int Rent1House { get; }

        /// <summary>
        /// Gets the price a player pays when they land on someone else's property and it has two houses
        /// </summary>
        public int Rent2Houses { get; }

        /// <summary>
        /// Gets the price a player pays when they land on someone else's property and it has three houses
        /// </summary>
        public int Rent3Houses { get; }

        /// <summary>
        /// Gets the price a player pays when they land on someone else's property and it has four houses
        /// </summary>
        public int Rent4Houses { get; }

        /// <summary>
        /// Gets the price a player pays when they land on someone else's property and it has a hotel
        /// </summary>
        public int RentHotel { get; }

        /// <summary>
        /// Gets the mortgage price of the property
        /// The player gets this amount when they put the property on mortgage - and stop receiving rent
        /// The player has to pay this amount plus 10 percent interest to unmortgage the property
        /// </summary>
        public int Mortgage { get; }

        /// <summary>
        /// Gets the cost to buy a house
        /// </summary>
        public int HouseCost { get; }

        /// <summary>
        /// Gets the cost to buy a hotel
        /// </summary>
        public int HotelCost { get; }

        /// <summary>
        /// Gets or sets a value indicating whether a property is owned
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a property is mortgaged
        /// </summary>
        public bool IsMortgaged { get; set; }

        /// <summary>
        /// Gets or sets the number of houses a property has
        /// </summary>
        public int NumberOfHouses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property has a hotel
        /// </summary>
        public bool HasHotel { get; set; }

        /// <summary>
        /// Gets or sets the owner of a property.
        /// </summary>
        public Player Owner { get; set; }

        /// <summary>
        /// Gets or sets the spots picture box
        /// </summary>
        public PictureBox SpotBox { get; set; }

        /// <summary>
        /// Finds the nearest spot that matches the spot type given
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <param name="type">The type of spot to look for like property or railroad or utility</param>
        /// <returns>The nearest spot of given type</returns>
        public Spot FindNearestSpotOfGivenType(List<Spot> board, SpotType type)
        {
            // Loop through the spots on the board starting at the one after the current one the player is on to the last spot on the board
            for (int i = this.SpotId + 1; i < board.Count; i++)
            {
                // If the type of the current spot equals the type given as a parameter
                if (board[i].Type == type)
                {
                    // return that spot
                    return board[i];
                }
            }

            // Loop through the spots on the board starting at Go until the spot right before the spot the current player is on
            for (int i = 0; i < this.SpotId; i++)
            {
                // If the type of the current spot equals the type given as a parameter
                if (board[i].Type == type)
                {
                    // return that spot
                    return board[i];
                }
            }

            // No spot of given type was found
            return null;
        }

        /// <summary>
        /// Returns how many of a property type are owned by the owner of a property of that type
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <returns>How many of a property type are owned by the owner of a property of that type</returns>
        public int NumberPropertyTypeOwned(List<Spot> board)
        {
            int numberOwned = 0;

            // Double check to make sure railroad has an owner
            if (this.Owner != null)
            {
                // Loop through the spots on the board
                foreach (Spot spot in board)
                {
                    // If the spot is a railroad and the owner is the same as the given railroad's
                    if (spot.Type == this.Type && spot.Owner == this.Owner)
                    {
                        numberOwned++;
                    }
                }
            }

            return numberOwned;
        }

        /// <summary>
        /// Finds out what the rent of a railroad should be based on the number of railroads 
        /// the player that owns the given railroad owns
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <returns>Returns the rent owned for the railroad</returns>
        public int FindCurrentRentOfRailroad(List<Spot> board)
        {
            // Find rent if just one railroad is owned
            int rent = this.Rent;

            // Find the number of railroads the owner of the current railroad owns
            int numberOwned = this.NumberPropertyTypeOwned(board);

            // Calculate rent based off of the number of railroads owned
            // (rent doubles for each railroad owned)
            rent = 25 * (int)Math.Pow(2, numberOwned - 1);

            return rent;
        }

        /// <summary>
        /// Find what what the rent should be based on how many utilities the owner of  
        /// a utility owns and the number on the dice rolled (random number generated)
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <param name="p">Player to pay the calculated rent</param>
        /// <returns>Returns the rent to be paid for the utility</returns>
        public int FindRentOfUtility(List<Spot> board, Player p)
        {
            // Declare and initialize a number that the rent is multiplied by depending on utilities owned
            int multiplyFactor = 4;

            // If owner of given utility owns both utilities
            if (this.NumberPropertyTypeOwned(board) == 2)
            {
                // Set multiplyFactor to 10
                multiplyFactor = 10;
            }

            // Declare and initialize a new random object
            Random random = new Random();

            // Get a random number between 1 and 6 (values of a die)
            // For some reason, this is always the value of die 1
            int rent = random.Next(6) + 1;

            if (p.IsAi == false)
            {
                // Message box informing player of die roll and rent to be paid
                MessageBox.Show(
                    "You rolled a " + rent + ". Your rent will be " + (rent * multiplyFactor).ToString("c0") + ".",
                    "Utility Rent");
            }

            // Increase rent by multiptyFactor
            rent *= multiplyFactor;

            return rent;
        }

        /// <summary>
        /// Finds out what the rent of a property should be based off of the buildings
        /// and how many of the color group are owned by the same owner
        /// </summary>
        /// <param name="board">The list of all spots on the board</param>
        /// <returns>Returns the rent owned</returns>
        public int FindRentOfRegularProperty(List<Spot> board)
        {
            // Find base rent 
            int rent = this.Rent;

            if (this.HasHotel)
            {
                rent = this.RentHotel;
            }
            else if (this.NumberOfHouses == 4)
            {
                rent = this.Rent4Houses;
            }
            else if (this.NumberOfHouses == 3)
            {
                rent = this.Rent3Houses;
            }
            else if (this.NumberOfHouses == 2)
            {
                rent = this.Rent2Houses;
            }
            else if (this.NumberOfHouses == 1)
            {
                rent = this.Rent1House;
            }
            else if (Game.CheckIfEligibleForHouse(this.Owner.GetPlayersPropertyList(board)).Contains(this.Color))
            {
                // If owner owns all of the color current location is, double the rent on unimproved property
                rent *= 2;
            }

            return rent;
        }
    }
}

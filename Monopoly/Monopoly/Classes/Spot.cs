namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            this.Mortgage = 0;
            this.HouseCost = 0;
            this.HotelCost = 0;
            this.IsAvailable = true;
            this.IsMortgaged = false;
            this.NumberOfHouses = 0;
            this.HasHotel = false;
            this.Owner = null;
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
        public Spot(int spotId, string spotName, Color color, int price, int rent, int rent1House,
            int rent2Houses, int rent3Houses, int rent4Houses, int rentHotel, int mortgage, int houseCost, int hotelCost)
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
    }
}

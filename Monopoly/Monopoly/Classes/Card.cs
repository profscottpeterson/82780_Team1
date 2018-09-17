﻿namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Card
    {
        /// <summary>
        /// Initializes a new instance of the Card class.
        /// For get out of jail free cards
        /// </summary>
        /// <param name="id">The card's id</param>
        /// <param name="description">What the card says</param>
        /// <param name="type">Is the card a Chance or Community Chest Card</param>
        public Card(int id, string description, CardType type)
        {
            this.Id = id;
            this.Description = description;
            this.Type = type;
            this.Amount = 0;
            this.Bank = true;
            this.Collect = false;
            this.NewLocation = null;
            this.GetOutOfJailFree = true;
        }

        /// <summary>
        /// Initializes a new instance of the Card class.
        /// For cards that involve money
        /// </summary>
        /// <param name="id">The card's id</param>
        /// <param name="description">What the card says</param>
        /// <param name="type">Is the card a Chance or Community Chest Card</param>
        /// <param name="amount">Amount of money to be collected or paid</param>
        /// <param name="bank">A boolean indicating whether the bank or other players are involved in the flow of money</param>
        /// <param name="collect">A boolean indicating whether the money is being collected or paid</param>
        public Card(int id, string description, CardType type, int amount, bool bank, bool collect)
        {
            this.Id = id;
            this.Description = description;
            this.Type = type;
            this.Amount = amount;
            this.Bank = bank;
            this.Collect = collect;
            this.NewLocation = null;
        }

        /// <summary>
        /// Initializes a new instance of the Card class.
        /// Use for cards that force player to move
        /// </summary>
        /// <param name="id">The card's id</param>
        /// <param name="description">What the card says</param>
        /// <param name="type">Is the card a Chance or Community Chest Card</param>
        /// <param name="newLocation">The location on the board the card says to move to (use null if not known)</param>
        public Card(int id, string description, CardType type, Spot newLocation)
        {
            this.Id = id;
            this.Description = description;
            this.Type = type;
            this.Amount = 0;
            this.Bank = true;
            this.Collect = false;
            this.NewLocation = newLocation;
        }

        /// <summary>
        /// Gets the card's id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the card's description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the card's type - Chance or Community Chest
        /// </summary>
        public CardType Type { get; }

        /// <summary>
        /// Gets the amount of money a player collects or pays from receiving card
        /// </summary>
        public int Amount { get; }

        /// <summary>
        /// Gets a value indicating whether the bank or other players are involved in the flow of money
        /// </summary>
        public bool Bank { get; }

        /// <summary>
        /// Gets a value indicating whether money is collected or paid
        /// </summary>
        public bool Collect { get; }

        /// <summary>
        /// Gets or sets the new location on the board to move to
        /// </summary>
        public Spot NewLocation { get; set; }

        /// <summary>
        /// Gets a value indicating whether a card is a get out of jail free card
        /// </summary>
        public bool GetOutOfJailFree { get; }
    }
}

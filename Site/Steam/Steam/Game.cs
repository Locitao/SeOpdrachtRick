using System;

namespace Steam
{
    /// <summary>
    ///     This class is used as a base to store instances of games which are collected from the database.
    /// </summary>
    public class Game
    {
        public Game(int gameId, int categoryId, string description, string name, int price)
        {
            GameId = gameId;
            CategoryId = categoryId;
            Description = description;
            Name = name;
            Price = price;
        }

        /// <summary>
        ///     Auto-properties.
        /// </summary>
        public int GameId { get; set; }

        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            var data = Convert.ToString(GameId) + ", " + Name + ", " + Description + ".";
            return data;
        }
    }
}
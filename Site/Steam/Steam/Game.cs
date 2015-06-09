using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Steam
{
    public class Game
    {
        public int GameId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        public Game(int gameId, int categoryId, string description, string name, int price)
        {
            GameId = gameId;
            CategoryId = categoryId;
            Description = description;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            var data = Convert.ToString(GameId) + ", " + Name + ", " + Description + ".";
            return data;
        }
    }
}
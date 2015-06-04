using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Steam
{
    public class Game
    {
        public int GameId { get { return GameId; } set { GameId = value;} }
        public int CategoryId { get { return CategoryId; } set { CategoryId = value;} }
        public string Description { get { return Description; } set
        {
            if (value == null) throw new ArgumentNullException("value");
            Description = value; } }
        public string Name { get { return Name; } set
        {
            if (value == null) throw new ArgumentNullException("value");
            Name = value; } }

        public override string ToString()
        {
            var data = Convert.ToString(GameId) + ", " + Name + ", " + Description + ".";
            return data;
        }
    }
}
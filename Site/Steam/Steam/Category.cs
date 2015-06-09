using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    /// <summary>
    /// This class is a base for the categories to which a game can belong.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// First the properties.
        /// </summary>
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public Category(int categoryId, string description)
        {
            CategoryId = categoryId;
            Description = description;
        }
    }
}
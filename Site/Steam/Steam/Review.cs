using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    /// <summary>
    /// To keep track of the collected reviews.
    /// </summary>
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int AccId { get; set; }
        public int ProductId { get; set; }

        public Review(int id, string description, int rating, int accId, int productId)
        {
            Id = id;
            Description = description;
            Rating = rating;
            AccId = accId;
            ProductId = productId;
        }
    }
}
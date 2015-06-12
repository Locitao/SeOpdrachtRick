namespace Steam
{
    /// <summary>
    ///     This class is a base for the categories to which a game can belong.
    /// </summary>
    public class Category
    {
        public Category(int categoryId, string description)
        {
            CategoryId = categoryId;
            Description = description;
        }

        /// <summary>
        ///     First the properties.
        /// </summary>
        public int CategoryId { get; set; }

        public string Description { get; set; }
    }
}
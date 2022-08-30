using System.ComponentModel.DataAnnotations;

namespace eComerceWebsite.Models
{

    /// <summary>
    /// Represent a single product available for purchase.
    /// </summary>
    public class Products
    {
        /// <summary>
        /// The unique identifier for each product.
        /// </summary>
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// The name of the Product.
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// The rating of a product.
        /// If applicable.
        /// </summary>
        public string? Rating { get; set; }

        /// <summary>
        /// The type of Product it is classified as. 
        /// Comic, action figure, poster etc...
        /// </summary>
        [Required]
        public string ProductType { get; set; }

        /// <summary>
        /// The category ID of the product that coresponds to its type
        /// Example: Comics will be stored under 000001, action figures 00002 etc...
        /// </summary>
        [Required]
        public int ProductCategoryID { get; set; }

        /// <summary>
        /// A brief description of the product.
        /// </summary>
        public string? ProductDescription { get; set; }

        /// <summary>
        /// The suggesteed MSRP of the product.
        /// </summary>
        [Required]
        [Range(0, 1000)]
        public double ProductPrice { get; set; }
    }
}

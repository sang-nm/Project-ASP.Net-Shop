using System.ComponentModel.DataAnnotations;

namespace Project_ASP.Net_Shop.Models
{
    public class Products
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        [Range(1, 99999.99)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        
        public string Specifications { get; set; }
        

        public string ProductBanner { get; set; }

        
        public string ProductThumbnail { get; set; }
        
    }
}
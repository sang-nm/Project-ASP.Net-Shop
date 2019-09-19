using System.ComponentModel.DataAnnotations;

namespace Project_ASP.Net_Shop.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Comment { get; set; }
    }
}
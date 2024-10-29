using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductBrand { get; set; }
        public string? ProductDetail { get; set; }
        public int ProductPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}

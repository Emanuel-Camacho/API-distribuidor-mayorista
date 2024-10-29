using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductBrand { get; set; }
        public string? ProductDetail { get; set; }
        public int ProductPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}

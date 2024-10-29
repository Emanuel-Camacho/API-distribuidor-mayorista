using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();

        public int AddProduct(Product product);

        public void DeleteProduct(int id);
    }
}

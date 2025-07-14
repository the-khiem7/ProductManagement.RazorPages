
using BussiessObjects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> SaveProductAsync(Product p);
        Task DeleteProductAsync(Product p);
        Task UpdateProductAsync(Product p);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}

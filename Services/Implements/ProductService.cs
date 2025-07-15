
using Repositories;
using BussiessObjects.Entities;
using Services.Interfaces;

namespace Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public void DeleteProduct(Product p)
        {
            _productRepository.DeleteProduct(p);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product SaveProduct(Product p)
        {
            return _productRepository.SaveProduct(p);
        }

        public void UpdateProduct(Product p)
        {
            _productRepository.UpdateProduct(p);
        }
    }
}

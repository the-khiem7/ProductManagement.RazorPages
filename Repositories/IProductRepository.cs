using BussiessObjects.Entities;


namespace Repositories
{
    public interface IProductRepository
    {
        Product SaveProduct(Product p);
        void DeleteProduct(Product p);

        void UpdateProduct(Product p);

        List<Product> GetProducts();

        Product GetProductById(int id);

    }
}

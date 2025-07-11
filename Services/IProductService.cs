﻿
using BussiessObjects.Entities;

namespace Services
{
    public interface IProductService
    {
        Product SaveProduct(Product p);
        void DeleteProduct(Product p);

        void UpdateProduct(Product p);

        List<Product> GetProducts();

        Product GetProductById(int id);
    }
}

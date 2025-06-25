using BussiessObjects.Entities;
using BussiessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var db = new MyStoreContext();
                listProducts = db.Products.Include(f => f.Category).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        private static readonly object _lockObject = new object();
        
        public static Product SaveProduct(Product p)
        {

                try
                {
                    using var context = new MyStoreContext();                    
                    var maxId = context.Products.Any() ? context.Products.Max(product => product.ProductId) : 0;
                    p.ProductId = maxId + 1;
                    
                    context.Products.Add(p);
                    context.SaveChanges();
                    return p;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using var context = new MyStoreContext();
                var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                context.Products.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static Product GetProductById(int id)
        {
            using var context = new MyStoreContext();
            return context.Products.Include(p => p.Category).FirstOrDefault(c => c.ProductId.Equals(id));
        }
    }
}

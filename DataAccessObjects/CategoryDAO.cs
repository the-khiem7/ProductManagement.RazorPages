using BussiessObjects;
using BussiessObjects.Entities;

namespace DataAccessObjects
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
           var listCategories = new List<Category>();
            try
            {
                using var context = new MyStoreContext();
                listCategories = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories", ex);
            }
            return listCategories;
        }
    }
}

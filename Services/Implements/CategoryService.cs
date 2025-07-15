
using BussiessObjects.Entities;
using Repositories;
using Services.Interfaces;

namespace Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }
        public List<Category> GetCategories()
        {
           return _categoryRepository.GetCategories();
        }
    }
}

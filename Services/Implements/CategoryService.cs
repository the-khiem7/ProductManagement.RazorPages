
using BussiessObjects.Entities;
using Services.Interfaces;
using Repositories.Interfaces;
using BussiessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork<MyStoreContext> _unitOfWork;
        public CategoryService(IUnitOfWork<MyStoreContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<Category>();
                var list = await repo.GetListAsync();
                return new List<Category>(list);
            });
        }
    }
}

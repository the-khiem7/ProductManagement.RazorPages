
using BussiessObjects.Entities;
using Services.Interfaces;
using Repositories.Interfaces;
using BussiessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork<MyStoreContext> _unitOfWork;
        public ProductService(IUnitOfWork<MyStoreContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteProductAsync(Product p)
        {
            await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<Product>();
                repo.DeleteAsync(p);
                await _unitOfWork.CommitAsync();
            });
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<Product>();
                // Assuming ProductId is int, not Guid
                return await repo.SingleOrDefaultAsync(predicate: x => x.ProductId == id);
            });
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<Product>();
                var list = await repo.GetListAsync();
                return new List<Product>(list);
            });
        }
        public async Task<Product> SaveProductAsync(Product p)
        {
            return await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<Product>();
                await repo.InsertAsync(p);
                await _unitOfWork.CommitAsync();
                return p;
            });
        }
        public async Task UpdateProductAsync(Product p)
        {
            await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<Product>();
                repo.UpdateAsync(p);
                await _unitOfWork.CommitAsync();
            });
        }
    }
}

using BussiessObjects.Entities;
using Services.Interfaces;
using Repositories.Interfaces;
using BussiessObjects;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork<MyStoreContext> _unitOfWork;
        public AccountService(IUnitOfWork<MyStoreContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AccountMember> GetAccountByEmailAsync(string email)
        {
            return await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<AccountMember>();
                return await repo.SingleOrDefaultAsync(predicate: a => a.EmailAddress == email);
            });
        }
        public async Task<AccountMember> GetAccountByIdAsync(string accountID)
        {
            return await _unitOfWork.ProcessInTransactionAsync(async () =>
            {
                var repo = _unitOfWork.GetRepository<AccountMember>();
                return await repo.SingleOrDefaultAsync(predicate: a => a.MemberId == accountID);
            });
        }
    }
}

using BussiessObjects.Entities;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountMemberRepository;

        public AccountService()
        {
            _accountMemberRepository = new AccountRepository();
        }

        public AccountMember GetAccountByEmail(string email)
        {
           return _accountMemberRepository.GetAccountByEmail(email);
        }

        public AccountMember GetAccountById(string accountID)
        {
           return _accountMemberRepository.GetAccountById(accountID);
        }
    }
}

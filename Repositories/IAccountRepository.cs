using BussiessObjects.Entities;

namespace Repositories
{
    public interface IAccountRepository
    {
        AccountMember GetAccountById(string accoutnID);
        AccountMember GetAccountByEmail(string email);

    }
}

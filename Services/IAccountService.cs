using BussiessObjects.Entities;

namespace Services
{
    public interface IAccountService
    {
        AccountMember GetAccountById(string accountID);
        AccountMember GetAccountByEmail(string email);
    }
}

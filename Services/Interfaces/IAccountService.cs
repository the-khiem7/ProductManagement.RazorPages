using BussiessObjects.Entities;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        AccountMember GetAccountById(string accountID);
        AccountMember GetAccountByEmail(string email);
    }
}

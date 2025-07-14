using BussiessObjects.Entities;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountMember> GetAccountByIdAsync(string accountID);
        Task<AccountMember> GetAccountByEmailAsync(string email);
    }
}


using BussiessObjects;
using BussiessObjects.Entities;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountID)
        {
            using var db = new MyStoreContext();
            return db.AccountMembers.FirstOrDefault(a => a.MemberId.Equals(accountID));
        }
        public static AccountMember GetAccountByEmail(string email)
        {
            using var context = new MyStoreContext();
            return context.AccountMembers.FirstOrDefault(a => a.EmailAddress.Equals(email));
        }
    }
}

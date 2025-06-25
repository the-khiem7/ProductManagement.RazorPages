using BussiessObjects.Entities;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountByEmail(string email) => AccountDAO.GetAccountByEmail(email);

        public AccountMember GetAccountById(string accoutnID) => AccountDAO.GetAccountById(accoutnID);

    }
}

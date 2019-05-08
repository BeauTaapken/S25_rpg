using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Account;

namespace S25_rpg.Factory
{
    public static class AccountFactory
    {
        public static IAccountRepo MySqlAccountRepo()
        {
            return new AccountRepository(new AccountContextSql());
        }

        public static IAccountRepo MemoryAccountRepo()
        {
            return new AccountRepository();
        }
    }
}

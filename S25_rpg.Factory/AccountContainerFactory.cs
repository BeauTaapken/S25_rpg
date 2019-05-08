using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Account;
using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Memory;

namespace S25_rpg.Factory
{
    public static class AccountContainerFactory
    {
        public static IAccountContainerRepo MySqlAccountContainerRepo()
        {
           return new AccountRepository(new AccountContextSql());
        }

        public static IAccountContainerRepo MemoryAccountContainerRepo()
        {
            return new AccountRepository();
        }
    }
}

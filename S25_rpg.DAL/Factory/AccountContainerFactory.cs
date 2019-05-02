using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class AccountContainerFactory
    {
        public static IAccountContainerRepo AccountContainerRepo = new AccountRepository(new AccountContextSql());
    }
}

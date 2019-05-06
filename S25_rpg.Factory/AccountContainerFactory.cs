using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Account;
using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;

namespace S25_rpg.Factory
{
    public static class AccountContainerFactory
    {
        public static IAccountContainerRepo AccountContainerRepo()
        {
           return new AccountRepository(new AccountContextSql());
        } 
    }
}

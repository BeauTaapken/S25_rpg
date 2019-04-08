using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.DAL.Memory;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountCollectionLogic
    {
        IAccountCollectionRepo repo = new AccountRepository(new AccountContextSql());

        //private IAccountCollectionRepo repo = new AccountRepository(new AccountContextMemory());

        public IAccount Login(IAccount account)
        {
            return repo.Login(account);
        }

        public int GetUserId(IAccount account)
        {
            return repo.GetAccountId(account);
        }

        public void InsertAccount(IAccount account)
        {
            repo.CreateAccount(account);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return repo.CheckIfAccountExist(account);
        }
    }
}

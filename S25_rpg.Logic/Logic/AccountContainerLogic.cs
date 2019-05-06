using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Memory;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountContainerLogic
    {
        private IAccountContainerRepo container = AccountContainerFactory.AccountContainerRepo();
        public IAccount Login(IAccount account)
        {
            return container.Login(account);
        }

        public void InsertAccount(IAccount account)
        {
            container.CreateAccount(account);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return container.CheckIfAccountExist(account);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Memory;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountContainerLogic
    {
        private IAccountContainerRepo container;

        public AccountContainerLogic(IAccountContainerRepo repo = null)
        {
            container = repo ?? AccountContainerFactory.MySqlAccountContainerRepo();
        }

        public Account Login(Account account)
        {
            return container.Login(account);
        }

        public void InsertAccount(Account account)
        {
            container.CreateAccount(account);
        }

        public bool CheckIfAccountExist(Account account)
        {
            return container.CheckIfAccountExist(account);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Factory;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.DAL.Memory;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountContainerLogic : AccountContainerFactory
    {
        public IAccount Login(IAccount account)
        {
            return AccountContainerRepo.Login(account);
        }

        public void InsertAccount(IAccount account)
        {
            AccountContainerRepo.CreateAccount(account);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return AccountContainerRepo.CheckIfAccountExist(account);
        }
    }
}

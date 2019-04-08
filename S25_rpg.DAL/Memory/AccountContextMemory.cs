using System;
using System.Collections.Generic;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class AccountContextMemory : IAccountContext
    {
        private List<IAccount> accounts;
        public AccountContextMemory()
        {
            accounts = new List<IAccount>();
            accounts.Add(new Account(1, "beau", "test", "beau@lioncode.nl"));
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            
            throw new NotImplementedException();
        }

        public void CreateAccount(IAccount account)
        {
            throw new NotImplementedException();
        }

        public int GetAccountId(IAccount account)
        {
            throw new NotImplementedException();
        }

        public IAccount Login(IAccount account)
        {
            return accounts.Find(x => x.Username == account.Username && x.Password == account.Password);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL
{
    public class AccountRepository
    {
        private readonly IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public bool Login(IAccount account)
        {
            return _accountContext.CheckAccount(account);
        }

        public int GetAccountId(IAccount account)
        {
            return _accountContext.getAccountId(account);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return _accountContext.checkIfAccountExist(account);
        }

        public void AddAccount(IAccount account)
        {
            _accountContext.AddAccount(account);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL;
using S25_rpg.DAL.IContext;
using S25_rpg.Interfaces;
using UnitTests.Dto;

namespace UnitTests.MockContent
{
    class AccountContextMock : IAccountContext
    {
        public void AddAccount(IAccount account)
        {
            var newAccount = new Account
            {
                Username = account.Username,
                Password = account.Password,
                Email = account.Email
            };
        }

        public bool Login(IAccount account)
        {
            if (account.Username == "unitTest" && account.Password == "unitTest")
            {
                return true;
            }

            return false;
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            if (account.Username == "unitTest" || account.Email == "unittest@test.com")
            {
                return true;
            }

            return false;
        }

        public int GetAccountId(IAccount account)
        {
            if (account.Username == "firstUsername" && account.Password == "firstPassword")
            {
                return 1;
            }
            if (account.Username == "secondUsername" && account.Password == "secondPassword")
            {
                return 2;
            }

            return 0;
        }
    }
}

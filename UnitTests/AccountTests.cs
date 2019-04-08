using S25_rpg.Logic;
using System;
using S25_rpg.DAL;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests
{
    public class AccountTests
    {
        AccountLogic _accountLogic;
        AccountCollectionLogic _accountCollectionLogic;
        public AccountTests()
        {
            _accountLogic = new AccountLogic();
        }

        [Fact]
        public void LoginCorrectly()
        {
            IAccount result = _accountCollectionLogic.Login(new Account(0, "unittest", "unittest", "email"));
            
            //TODO assert
        }

        [Fact]
        public void LoginIncorrectly()
        {
            IAccount result = _accountCollectionLogic.Login(new Account(0, "wrong", "wrong", "email"));

            //TODO assert
        }

        [Fact]
        public void AccountWithUsernameExists()
        {
            var result = _accountCollectionLogic.CheckIfAccountExist(new Account(0, "unittest", "unittest", "email"));

            Assert.True(result);
        }

        [Fact]
        public void AccountWithEmailExists()
        {
            var result = _accountCollectionLogic.CheckIfAccountExist(new Account(0, "unittest", "unittest", "email"));

            Assert.True(result);
        }

        [Fact]
        public void AccountNotExists()
        {
            var result = _accountCollectionLogic.CheckIfAccountExist(new Account(0, "unittest", "unittest", "email"));
            
            Assert.False(result);
        }

        [Fact]
        public void FirstAccountId()
        {
            var result = _accountCollectionLogic.GetUserId(new Account(0, "unittest", "unittest", "email"));

            Assert.Equal(1, result);
        }

        [Fact]
        public void SecondAccountId()
        {
            var result = _accountCollectionLogic.GetUserId(new Account(0, "unittest", "unittest", "email"));

            Assert.Equal(2, result);
        }

        [Fact]
        public void NoAccountId()
        {
            var result = _accountCollectionLogic.GetUserId(new Account(0, "unittest", "unittest", "email"));
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddAccount()
        {
            _accountCollectionLogic.InsertAccount(new Account(0, "unittest", "unittest", "email"));
        }
    }
}

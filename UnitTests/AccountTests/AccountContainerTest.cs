using S25_rpg.Logic;
using System;
using System.Reflection;
using S25_rpg.DAL;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.AccountTests
{
    public class AccountContainerTest
    {
        private AccountContainerLogic _accountContainerLogic;
        private IAccount existingAccount = new Account(1, "beau", "test", "beau@lioncode.nl");
        private IAccount nonExistengAccount = new Account(0, "FakeAccount", "fakePassword", "fake@fake.com");

        public AccountContainerTest()
        {
            _accountContainerLogic = new AccountContainerLogic(AccountContainerFactory.MemoryAccountContainerRepo());
        }

        [Fact]
        public void LoginCorrectly()
        {
            IAccount result = _accountContainerLogic.Login(existingAccount);

            Assert.Equal(existingAccount.idAccount, result.idAccount);
        }

        [Fact]
        public void LoginIncorrectly()
        {
            IAccount result = _accountContainerLogic.Login(nonExistengAccount);

            Assert.Null(result);
        }

        [Fact]
        public void AccountWithUsernameExists()
        {
            var result = _accountContainerLogic.CheckIfAccountExist(existingAccount);

            Assert.True(result);
        }

        [Fact]
        public void AccountWithEmailExists()
        {
            var result = _accountContainerLogic.CheckIfAccountExist(existingAccount);

            Assert.True(result);
        }

        [Fact]
        public void AccountNotExists()
        {
            var result = _accountContainerLogic.CheckIfAccountExist(nonExistengAccount);
            
            Assert.False(result);
        }
    }
}

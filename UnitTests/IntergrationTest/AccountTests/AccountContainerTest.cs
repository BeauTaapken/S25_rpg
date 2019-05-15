using S25_rpg.Logic;
using System;
using System.Reflection;
using S25_rpg.DAL;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;
using Xunit;
using Microsoft.AspNetCore.Hosting;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Tests.IntergrationTest.AccountTests
{
    public class AccountContainerTest : SetDatabase
    {
        private AccountContainerLogic _accountContainerLogic;
        private Account existingAccount = new Account(6, "beau", "123", "beau@lioncode.nl");
        private Account nonExistengAccount = new Account(0, "FakeAccount", "fakePassword", "fake@fake.com");

        public AccountContainerTest()
        {
            
            _accountContainerLogic = new AccountContainerLogic(AccountContainerFactory.MySqlAccountContainerRepo());
        }

        [Fact]
        public void LoginCorrectly()
        {
            Account result = _accountContainerLogic.Login(existingAccount);

            Assert.Equal(existingAccount.idAccount, result.idAccount);
        }

        [Fact]
        public void LoginIncorrectly()
        {
            Account result = _accountContainerLogic.Login(nonExistengAccount);

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

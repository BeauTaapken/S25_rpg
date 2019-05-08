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
    public class AccountTest
    {
        AccountLogic _accountLogic;
        IAccount existingAccount = new Account(1, "beau", "test", "beau@lioncode.nl");
        IAccount nonExistengAccount = new Account(0, "FakeAccount", "fakePassword", "fake@fake.com");

        public AccountTest()
        {
            _accountLogic = new AccountLogic(AccountFactory.MemoryAccountRepo());
        }

        [Fact]
        public void AccountHasCharacter()
        {
            ICharacter result = _accountLogic.AccountHasCharacter(existingAccount);
            
            Assert.Equal(existingAccount.idAccount, result.idCharacter);
        }

        [Fact]
        public void AccountHasNoCharacter()
        {
            ICharacter result = _accountLogic.AccountHasCharacter(nonExistengAccount);

            Assert.Null(result);
        }
    }
}

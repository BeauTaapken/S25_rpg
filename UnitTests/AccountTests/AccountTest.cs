using S25_rpg.Logic;
using System;
using System.Reflection;
using S25_rpg.DAL;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.AccountTests
{
    public class AccountTest
    {
        private AccountLogic _accountLogic;
        private Account existingAccount = new Account(1, "beau", "test", "beau@lioncode.nl");
        private Account nonExistengAccount = new Account(0, "FakeAccount", "fakePassword", "fake@fake.com");

        public AccountTest()
        {
            _accountLogic = new AccountLogic(AccountFactory.MemoryAccountRepo());
        }

        [Fact]
        public void AccountHasCharacter()
        {
            Character result = _accountLogic.AccountHasCharacter(existingAccount);
            
            Assert.Equal(existingAccount.idAccount, result.idCharacter);
        }

        [Fact]
        public void AccountHasNoCharacter()
        {
            Character result = _accountLogic.AccountHasCharacter(nonExistengAccount);

            Assert.Null(result);
        }
    }
}

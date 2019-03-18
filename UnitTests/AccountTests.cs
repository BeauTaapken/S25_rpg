using S25_rpg.Logic;
using System;
using S25_rpg.DAL;
using S25_rpg.Logic.Logic;
using UnitTests.MockContent;
using Xunit;

namespace UnitTests
{
    public class AccountTests
    {
        AccountLogic _accountLogic;

        public AccountTests()
        {
            _accountLogic = new AccountLogic(new AccountContextMock());
        }

        [Fact]
        public void LoginCorrectly()
        {
            var result = _accountLogic.Login("unitTest", "unitTest");
            
            Assert.True(result);
        }

        [Fact]
        public void LoginIncorrectly()
        {
            var result = _accountLogic.Login("wrongName", "wrongPassword");

            Assert.False(result);
        }

        [Fact]
        public void AccountWithUsernameExists()
        {
            var result = _accountLogic.CheckIfAccountExist("unitTest", "wrong@email.com");

            Assert.True(result);
        }

        [Fact]
        public void AccountWithEmailExists()
        {
            var result = _accountLogic.CheckIfAccountExist("wrongname", "unittest@test.com");

            Assert.True(result);
        }

        [Fact]
        public void AccountNotExists()
        {
            var result = _accountLogic.CheckIfAccountExist("wrongname", "wrong@email.com");
            
            Assert.False(result);
        }

        [Fact]
        public void FirstAccountId()
        {
            var result = _accountLogic.GetUserId("firstUsername", "firstPassword");

            Assert.Equal(1, result);
        }

        [Fact]
        public void SecondAccountId()
        {
            var result = _accountLogic.GetUserId("secondUsername", "secondPassword");

            Assert.Equal(2, result);
        }

        [Fact]
        public void NoAccountId()
        {
            var result = _accountLogic.GetUserId("fakeUsername", "fakePassword");
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddAccount()
        {
            _accountLogic.InsertAccount("unittestUsername", "unittestPassword", "unittestEmail");
        }
    }
}

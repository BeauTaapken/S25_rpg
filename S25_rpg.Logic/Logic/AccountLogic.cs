using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Repository;
using S25_rpg.Logic.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountLogic
    {
        private AccountRepository Repository { get; }

        public AccountLogic(IAccountContext accountContext)
        {
            Repository = new AccountRepository(accountContext);
        }

        public bool Login(string username, string password)
        {
            var account = new Account{Username = username, Password = password};
            return Repository.Login(account);
        }

        public int GetUserId(string username, string password)
        {
            var account = new Account{Username = username, Password = password};
            return Repository.GetAccountId(account);
        }

        public void InsertAccount(string username, string password, string email)
        {
            var account = new Account {Username = username, Password = password, Email = email};
            Repository.AddAccount(account);
        }

        public bool CheckIfAccountExist(string username, string email)
        {
            var account = new Account {Username = username, Email = email};
            return Repository.CheckIfAccountExist(account);
        }
    }
}

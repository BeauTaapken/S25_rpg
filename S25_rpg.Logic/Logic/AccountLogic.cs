using S25_rpg.DAL.Context;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountLogic
    {
        private IAccountRepo Repository = new AccountRepository(new AccountContextSql());

        //public AccountLogic(IAccountContext accountContext)
        //{
        //    Repository = new AccountRepository(accountContext);
        //}

        public void Logout()
        {
            Repository.Logout();
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            return Repository.AccountHasCharacter(account);
        }

        //public bool Login(IAccount account)
        //{
        //    return Repository.Login(account);
        //}

        //public int GetUserId(IAccount account)
        //{
        //    return Repository.GetAccountId(account);
        //}

        //public void InsertAccount(IAccount account)
        //{
        //    Repository.AddAccount(account);
        //}

        //public bool CheckIfAccountExist(IAccount account)
        //{
        //    return Repository.CheckIfAccountExist(account);
        //}
    }
}

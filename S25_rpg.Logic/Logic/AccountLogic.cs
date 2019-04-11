using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountLogic
    {
        private IAccountRepo Repository = new AccountRepository(new AccountContextSql());

        public void Logout()
        {
            Repository.Logout();
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            return Repository.AccountHasCharacter(account);
        }
    }
}

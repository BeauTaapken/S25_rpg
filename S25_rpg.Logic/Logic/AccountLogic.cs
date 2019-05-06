using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountLogic
    {
        private IAccountRepo repo = AccountFactory.AccountRepo();
        public void Logout()
        {
            repo.Logout();
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            return repo.AccountHasCharacter(account);
        }
    }
}

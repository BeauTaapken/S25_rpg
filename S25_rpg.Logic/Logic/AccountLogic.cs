using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountLogic
    {
        private IAccountRepo repo;

        public AccountLogic(IAccountRepo r = null)
        {
            repo = r ?? AccountFactory.MySqlAccountRepo();
        }

        public void Logout()
        {
            //Not used yet, may be used in future versions to save the current webpath of the user
            repo.Logout();
        }

        public Character AccountHasCharacter(Account account)
        {
            return repo.AccountHasCharacter(account);
        }
    }
}

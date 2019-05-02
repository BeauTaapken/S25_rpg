using S25_rpg.DAL.Context;
using S25_rpg.DAL.Factory;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountLogic : AccountFactory
    {
        public void Logout()
        {
            AccountRepo.Logout();
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            return AccountRepo.AccountHasCharacter(account);
        }
    }
}

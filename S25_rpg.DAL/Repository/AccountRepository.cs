using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Repository
{
    public class AccountRepository : IAccountContext
    {
        private readonly IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext = null)
        {
            _accountContext = accountContext ?? new AccountContextMemory();
        }

        public Account Login(Account account)
        {
            return _accountContext.Login(account);
        }

        public bool CheckIfAccountExist(Account account)
        {
            return _accountContext.CheckIfAccountExist(account);
        }

        public void CreateAccount(Account account)
        {
            _accountContext.CreateAccount(account);
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public Character AccountHasCharacter(Account account)
        {
            return _accountContext.AccountHasCharacter(account);
        }
    }
}

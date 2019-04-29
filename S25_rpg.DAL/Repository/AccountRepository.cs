using S25_rpg.DAL.Interface.Account;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class AccountRepository : IAccountContext
    {
        private readonly IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext = null)
        {
            _accountContext = accountContext ?? new AccountContextMemory();
        }

        public IAccount Login(IAccount account)
        {
            return _accountContext.Login(account);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return _accountContext.CheckIfAccountExist(account);
        }

        public void CreateAccount(IAccount account)
        {
            _accountContext.CreateAccount(account);
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            return _accountContext.AccountHasCharacter(account);
        }
    }
}

using S25_rpg.DAL.IContext;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class AccountRepository
    {
        private readonly IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public bool Login(IAccount account)
        {
            return _accountContext.Login(account);
        }

        public int GetAccountId(IAccount account)
        {
            return _accountContext.GetAccountId(account);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return _accountContext.CheckIfAccountExist(account);
        }

        public void AddAccount(IAccount account)
        {
            _accountContext.AddAccount(account);
        }
    }
}

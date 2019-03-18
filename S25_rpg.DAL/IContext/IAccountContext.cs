using S25_rpg.Interfaces;

namespace S25_rpg.DAL.IContext
{
    public interface IAccountContext
    {
        void AddAccount(IAccount account);

        bool Login(IAccount account);

        int GetAccountId(IAccount account);

        bool CheckIfAccountExist(IAccount account);
    }
}

using MySql.Data.MySqlClient;
using S25_rpg.DAL.Dto;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Context
{
    public class AccountContext : IAccountContext
    {

        public void CreateAccount(IAccount account)
        {
            throw new System.NotImplementedException();
        }

        public IAccount Login(IAccount account)
        {
            throw new System.NotImplementedException();
        }

        public int GetAccountId(IAccount account)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            throw new System.NotImplementedException();
        }
    }
}

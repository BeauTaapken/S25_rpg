using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface.Account
{
    public interface IAccountCollectionRepo
    {
        IAccount Login(IAccount account);

        int GetAccountId(IAccount account);

        void CreateAccount(IAccount account);

        bool CheckIfAccountExist(IAccount account);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL
{
    public interface IAccountContext
    {
        void AddAccount(IAccount account);

        bool CheckAccount(IAccount account);

        int getAccountId(IAccount account);

        bool checkIfAccountExist(IAccount account);
    }
}

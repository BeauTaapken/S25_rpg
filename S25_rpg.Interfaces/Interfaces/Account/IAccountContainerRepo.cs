using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Account
{
    public interface IAccountContainerRepo
    {
        IAccount Login(IAccount account);

        void CreateAccount(IAccount account);

        bool CheckIfAccountExist(IAccount account);
    }
}

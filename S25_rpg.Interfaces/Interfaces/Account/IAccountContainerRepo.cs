using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Models.Interfaces.Account
{
    public interface IAccountContainerRepo
    {
        Models.Account Login(Models.Account account);

        void CreateAccount(Models.Account account);

        bool CheckIfAccountExist(Models.Account account);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Repository;
using S25_rpg.Logic.Models;

namespace S25_rpg.Logic.Logic
{
    public class AccountCharacterLogic
    {
        private AccountCharacterRepository Repository { get; }

        public AccountCharacterLogic(IAccountCharacterContext accountCharacterContext)
        {
            Repository = new AccountCharacterRepository(accountCharacterContext);
        }

        public bool AccountHasCharacter(int idAccount)
        {
            var accountCharacter = new AccountCharacter {Account_idAccount = idAccount};
            return Repository.AccountHasCharacter(accountCharacter);
        }
    }
}

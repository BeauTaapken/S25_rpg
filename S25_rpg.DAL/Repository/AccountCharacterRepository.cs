using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.IContext;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class AccountCharacterRepository
    {
        private readonly IAccountCharacterContext _accountCharacterContext;

        public AccountCharacterRepository(IAccountCharacterContext accountCharacterContext)
        {
            _accountCharacterContext = accountCharacterContext;
        }

        public bool AccountHasCharacter(IAccountCharacter accountCharacter)
        {
            return _accountCharacterContext.AccountHasCharacter(accountCharacter);
        }
    }
}

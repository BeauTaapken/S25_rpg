using System;
using System.Collections.Generic;
using System.Linq;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Account;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class AccountContextMemory : IAccountContext
    {
        private List<IAccount> accounts;
        private List<ICharacter> characters;
        public AccountContextMemory()
        {
            accounts = new List<IAccount>();
            accounts.Add(new Account(1, "beau", "test", "beau@lioncode.nl"));
            accounts.Add(new Account(2, "testbeau", "test", "test@test.com"));
            characters = new List<ICharacter>();
            characters.Add(new Character(1, 10, 10, 10, 10, 10, Eyecolor.Blue, Haircolor.Black, 10, CharacterClass.Archer, ""));
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            return characters.FirstOrDefault(x => x.idCharacter == account.idAccount);
        }

        public bool CheckIfAccountExist(IAccount account)
        {
            return accounts.Any(x => x.Username == account.Username || x.Email == account.Email);
        }

        public void CreateAccount(IAccount account)
        {
            accounts.Add(account);
        }

        public IAccount Login(IAccount account)
        {
            return accounts.Find(x => x.Username == account.Username && x.Password == account.Password);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}

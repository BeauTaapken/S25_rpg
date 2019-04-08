using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class AccountCharacter : IAccountCharacter
    {
        public int idAccount { get; set; }
        public int idCharacter { get; set; }

        public AccountCharacter(int idaccount, int idcharacter)
        {
            idAccount = idaccount;
            idCharacter = idcharacter;
        }
    }
}

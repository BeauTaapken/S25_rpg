using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Interfaces;

namespace S25_rpg.Logic.Models
{
    public class AccountCharacter : IAccountCharacter
    {
        public int Account_idAccount { get; set; }
        public int Character_idCharacter { get; set; }
    }
}

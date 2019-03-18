using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL.Dto
{
    class AccountCharacterDto : IAccountCharacter
    {
        public int Account_idAccount { get; set; }
        public int Character_idCharacter { get; set; }
    }
}

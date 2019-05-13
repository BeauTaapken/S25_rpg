using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Interfaces.Character
{
    public interface ICharacterContainerRepo
    {
        Models.Character AddCharacter(Models.Character character, Models.Account account);
    }
}

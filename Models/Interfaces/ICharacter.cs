using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces
{
    public interface ICharacter
    {
        int idCharacter { get; set; }
        int Weight { get; set; }
        int Height { get; set; }
        int CurrentExp { get; set; }
        int CurrentLevel { get; set; }
        Eyecolor Eyecolor { get; set; }
        Haircolor Haircolor { get; set; }
        int Unlockpoint { get; set; }
        CharacterClass CharacterClass { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces.Model
{
    public interface ICharacter
    {
        int idCharacter { get; set; }
        int Weight { get; set; }
        int Height { get; set; }
        int CurrentExp { get; set; }
        int CurrentLevel { get; set; }
        int Gold { get; set; }
        Eyecolor Eyecolor { get; set; }
        Haircolor Haircolor { get; set; }
        int QuestLevel { get; set; }
        CharacterClass CharacterClass { get; set; }
        string StartPage { get; set; }
    }
}

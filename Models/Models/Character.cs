using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Character : ICharacter
    {
        public int idCharacter { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int CurrentExp { get; set; }
        public int CurrentLevel { get; set; }
        public Eyecolor Eyecolor { get; set; }
        public Haircolor Haircolor { get; set; }
        public int Unlockpoint { get; set; }
        public CharacterClass CharacterClass { get; set; }

        public Character(int idcharacter, int weight, int height, int currentExp, int currentLevel, Eyecolor eyecolor,
            Haircolor haircolor, int unlockpoint, CharacterClass characterClass)
        {
            idCharacter = idcharacter;
            Weight = weight;
            Height = height;
            CurrentExp = currentExp;
            CurrentLevel = currentLevel;
            Eyecolor = eyecolor;
            Haircolor = haircolor;
            Unlockpoint = unlockpoint;
            CharacterClass = characterClass;
        }
    }
}

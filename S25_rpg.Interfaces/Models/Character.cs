using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Abstract;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Character : AbstractCharacter
    {
        public int idCharacter { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int CurrentExp { get; set; }
        public int CurrentLevel { get; set; }
        public int Gold { get; set; }
        public Eyecolor Eyecolor { get; set; }
        public Haircolor Haircolor { get; set; }
        public int QuestLevel { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public string StartPage { get; set; }
        public override int health { get; set; } = 0;
        public override int damage { get; set; } = 0;
        public override int defence { get; set; } = 0;

        public Character(int idcharacter, int weight, int height, int currentExp, int currentLevel, int gold, Eyecolor eyecolor,
            Haircolor haircolor, int questLevel, CharacterClass characterClass, string startingPage)
        {
            idCharacter = idcharacter;
            Weight = weight;
            Height = height;
            CurrentExp = currentExp;
            CurrentLevel = currentLevel;
            Gold = gold;
            Eyecolor = eyecolor;
            Haircolor = haircolor;
            QuestLevel = questLevel;
            CharacterClass = characterClass;
            StartPage = startingPage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class CharacterContextMemory : ICharacterContext
    {
        private List<ICharacter> characters;
        public CharacterContextMemory()
        {
            characters = new List<ICharacter>();
            characters.Add(new Character(1, 10, 10, 10, 10, Eyecolor.Blue, Haircolor.Black, 0, CharacterClass.Warrior, "http://"));
        }

        public ICharacter AccountHasCharacter(IAccount account)
        {
            throw new NotImplementedException();
        }

        public ICharacter AddCharacter(ICharacter character, int id)
        {
            throw new NotImplementedException();
        }
    }
}

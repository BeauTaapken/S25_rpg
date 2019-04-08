using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Interface;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class CharacterRepository : ICharacterContext
    {
        private ICharacterContext _characterContext;

        public CharacterRepository(ICharacterContext characterContext)
        {
            _characterContext = characterContext;
        }

        public ICharacter AddCharacter(ICharacter character, int id)
        {
            return _characterContext.AddCharacter(character, id);
        }
    }
}

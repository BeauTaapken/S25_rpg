using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Memory;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class CharacterContainerLogic
    {
        private ICharacterContainerRepo repo;

        public CharacterContainerLogic(ICharacterContainerRepo r = null)
        {
            repo = r ?? CharacterContainerFactory.MySqlCharacterContainerRepo();
        }

        public ICharacter AddCharacter(ICharacter iCharacter, IAccount iAccount)
        {
            return repo.AddCharacter(iCharacter, iAccount);
        }
    }
}

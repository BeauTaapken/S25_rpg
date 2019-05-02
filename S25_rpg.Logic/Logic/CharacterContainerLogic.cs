using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Factory;
using S25_rpg.DAL.Interface;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.DAL.Memory;
using S25_rpg.DAL.Repository;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class CharacterContainerLogic : CharacterContainerFactory
    {
        public ICharacter AddCharacter(ICharacter iCharacter, IAccount iAccount)
        {
            return CharacterContainerRepo.AddCharacter(iCharacter, iAccount.idAccount);
        }
    }
}

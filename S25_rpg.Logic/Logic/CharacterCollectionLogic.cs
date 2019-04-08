using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Interface;
using S25_rpg.DAL.Memory;
using S25_rpg.DAL.Repository;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class CharacterCollectionLogic
    {
        private ICharacterCollectionRepo repo = new CharacterRepository(new CharacterContextSql());
        //private ICharacterCollectionRepo repo = new CharacterRepository(new CharacterContextMemory());
        //private CharacterRepository Repository { get; }

        //public CharacterLogic(ICharacterCollectionRepo characterContext)
        //{
        //    Repository = new CharacterRepository(characterContext);
        //}

        public ICharacter AddCharacter(ICharacter iCharacter, IAccount iAccount)
        {
            return repo.AddCharacter(iCharacter, iAccount.idAccount);
        }
    }
}

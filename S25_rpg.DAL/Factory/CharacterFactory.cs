using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class CharacterFactory
    {
        public static ICharacterRepo CharacterRepo = new CharacterRepository(new CharacterContextSql());
    }
}

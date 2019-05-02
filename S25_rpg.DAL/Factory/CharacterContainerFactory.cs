using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class CharacterContainerFactory
    {
        public static ICharacterContainerRepo CharacterContainerRepo = new CharacterRepository(new CharacterContextSql());
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Character;

namespace S25_rpg.Factory
{
    public static class CharacterContainerFactory
    {
        public static ICharacterContainerRepo CharacterContainerRepo()
        {
            return new CharacterRepository(new CharacterContextSql());
        }
    }
}

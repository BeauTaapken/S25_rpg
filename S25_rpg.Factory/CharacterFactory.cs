using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Character;

namespace S25_rpg.Factory
{
    public static class CharacterFactory
    {
        public static ICharacterRepo CharacterRepo()
        {
            return new CharacterRepository(new CharacterContextSql());
        }
    }
}

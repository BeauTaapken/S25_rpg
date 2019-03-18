using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Interfaces;

namespace S25_rpg.DAL.IContext
{
    public interface IAccountCharacterContext
    {
        bool AccountHasCharacter(IAccountCharacter accountCharacter);
    }
}

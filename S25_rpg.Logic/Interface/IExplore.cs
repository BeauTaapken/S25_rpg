using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Interface
{
    public interface IExplore
    {
        AreaContent NextArea();
        IEnumerable<IMonster> Monsters();
        int Gold();
    }
}

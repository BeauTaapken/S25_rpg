using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Interface
{
    public interface IExplore
    {
        AreaContent NextArea();
        IEnumerable<Monster> Monsters();
        int Gold();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces
{
    public interface IMonster
    {
        string Name { get; set; }
        int Hp { get; set; }
        int Damage { get; set; }
        int Exp { get; set; }
    }
}

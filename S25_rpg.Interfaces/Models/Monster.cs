using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Models
{
    public class Monster : IMonster
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Exp { get; set; }

        public Monster(string name, int hp, int damage, int exp)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            Exp = exp;
        }
    }
}

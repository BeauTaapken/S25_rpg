using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Exp { get; set; }
        public int ItemDropId { get; set; }

        public Monster(string name, int hp, int damage, int exp, int itemDropId)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            Exp = exp;
            ItemDropId = itemDropId;
        }
    }
}

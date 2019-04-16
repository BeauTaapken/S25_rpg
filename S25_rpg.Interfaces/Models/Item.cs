using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public int Ammount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SellPrice { get; set; }
        public bool Equipable { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public Equiplocation? Location { get; set; }

        public Item(int id, int ammount, string name, string description, int sellPrice, bool equipable, int damage,
            int defence, Equiplocation? location)
        {
            Id = id;
            Ammount = ammount;
            Name = name;
            Description = description;
            SellPrice = sellPrice;
            Equipable = equipable;
            Damage = damage;
            Defence = defence;
            Location = location;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Ammount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int buyPrice { get; set; }
        public int SellPrice { get; set; }
        public bool Equipable { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public Equiplocation? Location { get; set; }

        public Item(int id, int ammount, string name, string description, int sellprice, bool equipable, int damage,
            int defence, Equiplocation? location)
        {
            Id = id;
            Ammount = ammount;
            Name = name;
            Description = description;
            SellPrice = sellprice;
            Equipable = equipable;
            Damage = damage;
            Defence = defence;
            Location = location;
        }

        public Item(int id, string name, string description, int buyprice, int sellprice)
        {
            Id = id;
            Name = name;
            Description = description;
            buyPrice = buyPrice;
            SellPrice = sellprice;
        }

        public Item(int id, int ammount)
        {
            Id = id;
            Ammount = ammount;
        }
    }
}

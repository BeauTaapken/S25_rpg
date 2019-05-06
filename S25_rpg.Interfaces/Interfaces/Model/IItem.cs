using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces.Model
{
    public interface IItem
    {
        int Id { get; set; }
        int Ammount { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int buyPrice { get; set; }
        int SellPrice { get; set; }
        bool Equipable { get; set; }
        int Damage { get; set; }
        int Defence { get; set; }
        Equiplocation? Location { get; set; }
    }
}

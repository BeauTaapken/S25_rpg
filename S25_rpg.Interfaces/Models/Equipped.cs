using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Equipped : IEquipped
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public Equiplocation ItemLocation { get; set; }

        public Equipped(int itemId, string itemName, Equiplocation itemLocation)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemLocation = itemLocation;
        }
    }
}

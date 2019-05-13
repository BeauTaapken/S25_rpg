using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Shop
    {
        public string shopName { get; set; }
        public IEnumerable<Item> items { get; set; }

        public Shop(string shopname, IEnumerable<Item> item)
        {
            shopName = shopname;
            items = item;
        }
    }
}

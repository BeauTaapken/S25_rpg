using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Shop : IShop
    {
        public string shopName { get; set; }
        public IEnumerable<IItem> items { get; set; }

        public Shop(string shopname, IEnumerable<IItem> item)
        {
            shopName = shopname;
            items = item;
        }
    }
}

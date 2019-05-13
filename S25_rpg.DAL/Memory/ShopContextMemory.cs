using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Shop;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class ShopContextMemory : IShopContext
    {
        private Shop shop;
        public ShopContextMemory()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item(1, 1, "testitem", "this is a testitem", 1, false, 0, 0, null));
            items.Add(new Item(1, 1, "equipabletestitem", "this is a testitem", 1, true, 10, 0, Equiplocation.Right));
            shop = new Shop("Testshop", items);
        }

        public Shop GetAllShopItems()
        {
            return shop;
        }
    }
}

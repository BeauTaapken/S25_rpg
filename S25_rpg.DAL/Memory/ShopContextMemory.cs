using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.Shop;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Memory
{
    public class ShopContextMemory : IShopContext
    {
        public IShop GetAllShopItems()
        {
            throw new NotImplementedException();
        }
    }
}

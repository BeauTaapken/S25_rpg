using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.Shop;

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

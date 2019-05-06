using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.Shop;

namespace S25_rpg.DAL.Repository
{
    public class ShopRepository : IShopContext
    {
        private readonly IShopContext _shopContext;

        public ShopRepository(IShopContext shopContext = null)
        {
            _shopContext = shopContext ?? new ShopContextMemory();
        }

        public IShop GetAllShopItems()
        {
            return _shopContext.GetAllShopItems();
        }
    }
}

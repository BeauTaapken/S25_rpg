using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.Item;
using S25_rpg.DAL.Interface.Shop;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;

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

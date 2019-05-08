using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Shop;

namespace S25_rpg.Factory
{
    public static class ShopFactory
    {
        public static IShopRepo MySqlShopRepo()
        {
            return new ShopRepository(new ShopContextSql());
        }

        public static IShopRepo MemoryShopRepo()
        {
            return new ShopRepository();
        }
    }
}

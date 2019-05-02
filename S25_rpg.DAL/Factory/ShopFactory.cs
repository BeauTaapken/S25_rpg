using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Shop;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class ShopFactory
    {
        public static IShopRepo ShopRepo = new ShopRepository(new ShopContextSql());
    }
}

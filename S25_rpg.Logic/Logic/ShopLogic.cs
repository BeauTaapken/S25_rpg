using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Shop;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class ShopLogic
    {
        IShopRepo repo = new ShopRepository(new ShopContextSql());

        public IShop GetAllShopItems()
        {
            return repo.GetAllShopItems();
        }
    }
}

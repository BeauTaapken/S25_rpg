using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Factory;
using S25_rpg.DAL.Interface.Shop;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class ShopLogic : ShopFactory
    {
        public IShop GetAllShopItems()
        {
            return ShopRepo.GetAllShopItems();
        }
    }
}

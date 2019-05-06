using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.Shop;

namespace S25_rpg.Logic.Logic
{
    public class ShopLogic
    {
        private IShopRepo repo = ShopFactory.ShopRepo();
        public IShop GetAllShopItems()
        {
            return repo.GetAllShopItems();
        }
    }
}

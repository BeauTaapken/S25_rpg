using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Shop;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class ShopLogic
    {
        private IShopRepo repo;

        public ShopLogic(IShopRepo r = null)
        {
            repo = r ?? ShopFactory.MySqlShopRepo();
        }

        public Shop GetAllShopItems()
        {
            return repo.GetAllShopItems();
        }
    }
}

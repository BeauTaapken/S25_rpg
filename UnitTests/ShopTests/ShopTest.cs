using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;
using Xunit;


namespace UnitTests.ShopTests
{
    public class ShopTest
    {
        private ShopLogic _shopLogic;

        public ShopTest()
        {
            _shopLogic = new ShopLogic(ShopFactory.MemoryShopRepo());
        }

        [Fact]
        public void GetShopItems()
        {
            IShop result = _shopLogic.GetAllShopItems();

            Assert.Equal("Testshop", result.shopName);
        }
    }
}

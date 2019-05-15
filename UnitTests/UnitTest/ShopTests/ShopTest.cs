using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Models;
using Xunit;


namespace Tests.UnitTest.ShopTests
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
            Shop result = _shopLogic.GetAllShopItems();

            Assert.Equal("Testshop", result.shopName);
        }
    }
}

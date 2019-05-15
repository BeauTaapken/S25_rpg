using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Models;
using Xunit;


namespace Tests.IntergrationTest.ShopTests
{
    public class ShopTest : SetDatabase
    {
        private ShopLogic _shopLogic;

        public ShopTest()
        {
            _shopLogic = new ShopLogic(ShopFactory.MySqlShopRepo());
        }

        [Fact]
        public void GetShopItems()
        {
            Shop result = _shopLogic.GetAllShopItems();

            Assert.Equal("The Huge World Turtle", result.shopName);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Models;
using Xunit;

namespace Tests.UnitTest.ItemTests
{
    public class ItemContainerTest
    {
        private ItemContainerLogic _itemContainerLogic;
        private Character existingItemCharacter = new Character(1, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");
        private Character nonExistingItemCharacter = new Character(2, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");

        public ItemContainerTest()
        {
            _itemContainerLogic = new ItemContainerLogic(ItemContainerFactory.MemoryItemContainerRepo());
        }

        [Fact]
        public void GetFilledCharacterItems()
        {
            IEnumerable<Item> result = _itemContainerLogic.GetAllCharacterItems(existingItemCharacter);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetEmptyCharacterItems()
        {
            IEnumerable<Item> result = _itemContainerLogic.GetAllCharacterItems(nonExistingItemCharacter);

            Assert.Empty(result);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.Item;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class ItemRepository : IItemContext
    {
        private readonly IItemContext _itemContext;

        public ItemRepository(IItemContext itemContext = null)
        {
            _itemContext = itemContext ?? new ItemContextMemory();
        }

        public IEnumerable<IItem> GetAllCharacterItems(ICharacter character)
        {
            return _itemContext.GetAllCharacterItems(character);
        }

        public void AddItem(IItem item)
        {
            _itemContext.AddItem(item);
        }

        public void RemoveItem(IItem item)
        {
            _itemContext.RemoveItem(item);
        }

        public IEnumerable<IItem> GetAllShopItems(string shopName)
        {
            return _itemContext.GetAllShopItems(shopName);
        }
    }
}
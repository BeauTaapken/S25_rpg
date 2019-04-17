using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.Item;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Memory
{
    public class ItemContextMemory : IItemContext
    {
        public IEnumerable<IItem> GetAllCharacterItems(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void AddItem(IItem item, ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(IItem item, ICharacter character)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IItem> GetAllShopItems(string shopName)
        {
            throw new NotImplementedException();
        }
    }
}

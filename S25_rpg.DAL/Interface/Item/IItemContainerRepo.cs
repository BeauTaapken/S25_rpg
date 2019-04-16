using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface.Item
{
    public interface IItemContainerRepo
    {
        IEnumerable<IItem> GetAllCharacterItems(ICharacter character);
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        IEnumerable<IItem> GetAllShopItems(string shopName);
    }
}

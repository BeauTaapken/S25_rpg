using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Interfaces.Item
{
    public interface IItemContainerRepo
    {
        IEnumerable<Models.Item> GetAllCharacterItems(Models.Character character);
        void AddItem(Models.Item item, Models.Character character);
        void RemoveItem(Models.Item item, Models.Character character);
    }
}

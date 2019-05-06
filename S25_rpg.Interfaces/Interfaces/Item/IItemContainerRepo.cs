using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Item
{
    public interface IItemContainerRepo
    {
        IEnumerable<IItem> GetAllCharacterItems(ICharacter character);
        void AddItem(IItem item, ICharacter character);
        void RemoveItem(IItem item, ICharacter character);
    }
}

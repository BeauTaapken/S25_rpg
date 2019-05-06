using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Item;
using S25_rpg.Models.Interfaces.Model;

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

        public void AddItem(IItem item, ICharacter character)
        {
            _itemContext.AddItem(item, character);
        }

        public void RemoveItem(IItem item, ICharacter character)
        {
            _itemContext.RemoveItem(item, character);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Item;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class ItemContextMemory : IItemContext
    {
        private List<Item> items;
        public ItemContextMemory()
        {
            items = new List<Item>();
            items.Add(new Item(1, 1, "testitem", "this is a testitem", 1, false, 0, 0, null));
            items.Add(new Item(1, 1, "equipabletestitem", "this is a testitem", 1, true, 10, 0, Equiplocation.Right));
        }

        public IEnumerable<Item> GetAllCharacterItems(Character character)
        {
            return items.FindAll(x => x.Id == character.idCharacter);
        }

        public void AddItem(Item item, Character character)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item, Character character)
        {
            items.Remove(item);
        }
    }
}

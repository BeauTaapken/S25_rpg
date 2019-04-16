using System.Collections.Generic;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Item;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class ItemContainerLogic
    {
        IItemContainerRepo repo = new ItemRepository(new ItemContextSql());

        public IEnumerable<IItem> GetAllCharacterItems(ICharacter character)
        {
            return repo.GetAllCharacterItems(character);
        }

        public void AddItem(IItem item)
        {
            repo.AddItem(item);
        }

        public void RemoveItem(IItem item)
        {
            repo.RemoveItem(item);
        }

        public IEnumerable<IItem> GetAllShopItems(string shopName)
        {
            return repo.GetAllShopItems(shopName);
        }
    }
}

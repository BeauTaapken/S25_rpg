using System.Collections;
using System.Collections.Generic;
using System.Linq;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Item;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class ItemContainerLogic
    {
        private IItemContainerRepo repo;

        public ItemContainerLogic(IItemContainerRepo r = null)
        {
            repo = r ?? ItemContainerFactory.MySqlItemContainerRepo();
        }

        public IEnumerable<Item> GetAllCharacterItems(Character character)
        {
            return repo.GetAllCharacterItems(character).ToList().Where(x => x.Ammount > 0);
        }

        public void AddItem(Item item, Character character)
        {
            repo.AddItem(item, character);
        }

        public void RemoveItem(Item item, Character character)
        {
            repo.RemoveItem(item, character);
        }
    }
}

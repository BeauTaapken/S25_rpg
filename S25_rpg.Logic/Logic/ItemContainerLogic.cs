using System.Collections;
using System.Collections.Generic;
using System.Linq;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Item;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Logic.Logic
{
    public class ItemContainerLogic
    {
        private IItemContainerRepo repo;

        public ItemContainerLogic(IItemContainerRepo r = null)
        {
            repo = r ?? ItemContainerFactory.MySqlItemContainerRepo();
        }

        public IEnumerable<IItem> GetAllCharacterItems(ICharacter character)
        {
            return repo.GetAllCharacterItems(character).ToList().Where(x => x.Ammount > 0);
        }

        public void AddItem(IItem item, ICharacter character)
        {
            repo.AddItem(item, character);
        }

        public void RemoveItem(IItem item, ICharacter character)
        {
            repo.RemoveItem(item, character);
        }
    }
}

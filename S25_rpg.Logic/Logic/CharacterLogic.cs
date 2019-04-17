using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class CharacterLogic
    {
        private ICharacterRepo repo = new CharacterRepository(new CharacterContextSql());

        public void EquipItem(IItem item, ICharacter character)
        {
            repo.EquipItem(item, character);
        }

        public IEnumerable<IEquipped> GetEquippedItems(ICharacter character)
        {
            return repo.GetEquippedItems(character);
        }
    }
}

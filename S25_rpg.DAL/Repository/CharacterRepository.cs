using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.DAL.Repository
{
    public class CharacterRepository : ICharacterContext
    {
        private ICharacterContext _characterContext;

        public CharacterRepository(ICharacterContext characterContext = null)
        {
            _characterContext = characterContext ?? new CharacterContextMemory();
        }

        public ICharacter AddCharacter(ICharacter character, IAccount account)
        {
            return _characterContext.AddCharacter(character, account);
        }

        public void EditStartLink(string link, ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void EquipItem(IItem item, ICharacter character)
        {
            _characterContext.EquipItem(item, character);
        }

        public void DequipItem(IItem item, ICharacter character)
        {
            _characterContext.DequipItem(item, character);
        }

        public IEnumerable<IEquipped> GetEquippedItems(ICharacter character)
        {
            return _characterContext.GetEquippedItems(character);
        }

        public void EditGold(int gold, ICharacter character)
        {
            _characterContext.EditGold(gold, character);
        }

        public void EditExpAndLevel(ICharacter character, int gottenExp)
        {
            _characterContext.EditExpAndLevel(character, gottenExp);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class CharacterRepository : ICharacterContext
    {
        private ICharacterContext _characterContext;

        public CharacterRepository(ICharacterContext characterContext = null)
        {
            _characterContext = characterContext ?? new CharacterContextMemory();
        }

        public ICharacter AddCharacter(ICharacter character, int id)
        {
            return _characterContext.AddCharacter(character, id);
        }

        public void EditUnlockPoint(string link, ICharacter character)
        {
            _characterContext.EditUnlockPoint(link, character);
        }

        public void EditStartLink(string link, ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void EquipItem(IItem item, ICharacter character)
        {
            _characterContext.EquipItem(item, character);
        }

        public IEnumerable<IEquipped> GetEquippedItems(ICharacter character)
        {
            return _characterContext.GetEquippedItems(character);
        }

        public void EditGold(int gold, ICharacter character)
        {
            _characterContext.EditGold(gold, character);
        }

        public void EditLevel(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public void EditExp(ICharacter character)
        {
            throw new NotImplementedException();
        }
    }
}

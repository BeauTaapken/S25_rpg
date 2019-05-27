using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Repository
{
    public class CharacterRepository : ICharacterContext
    {
        private ICharacterContext _characterContext;

        public CharacterRepository(ICharacterContext characterContext = null)
        {
            _characterContext = characterContext ?? new CharacterContextMemory();
        }

        public Character AddCharacter(Character character, Account account)
        {
            return _characterContext.AddCharacter(character, account);
        }

        public void EditStartLink(string link, Character character)
        {
            throw new NotImplementedException();
        }

        public void EquipItem(Item item, Character character)
        {
            _characterContext.EquipItem(item, character);
        }

        public void DequipItem(Item item, Character character)
        {
            _characterContext.DequipItem(item, character);
        }

        public IEnumerable<Equipped> GetEquippedItems(Character character)
        {
            return _characterContext.GetEquippedItems(character);
        }

        public void EditGold(int gold, Character character)
        {
            _characterContext.EditGold(gold, character);
        }

        public int? GetCharacterExp(Character character)
        {
            return _characterContext.GetCharacterExp(character);
        }

        public int? GetCharacterLevel(Character character)
        {
            return _characterContext.GetCharacterLevel(character);
        }

        public void EditExpAndLevel(Character character, int gottenExp, bool LevelUp)
        {
            _characterContext.EditExpAndLevel(character, gottenExp, LevelUp);
        }
    }
}

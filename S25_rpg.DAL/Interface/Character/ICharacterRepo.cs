using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface.Character
{
    public interface ICharacterRepo
    {
        void EditUnlockPoint(string link, ICharacter character);
        void EditStartLink(string link, ICharacter character);
        void EquipItem(IItem item, ICharacter character);
        IEnumerable<IEquipped> GetEquippedItems(ICharacter character);
        void EditGold(int gold, ICharacter character);
        void EditLevel(ICharacter character);
        void EditExp(ICharacter character, int gottenExp);
    }
}

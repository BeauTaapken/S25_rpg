using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Character
{
    public interface ICharacterRepo
    {
        void EditUnlockPoint(string link, ICharacter character);
        void EditStartLink(string link, ICharacter character);
        void EquipItem(IItem item, ICharacter character);
        IEnumerable<IEquipped> GetEquippedItems(ICharacter character);
        void EditGold(int gold, ICharacter character);
        void EditExpAndLevel(ICharacter character, int gottenExp);
    }
}

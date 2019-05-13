using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Models.Interfaces.Character
{
    public interface ICharacterRepo
    {
        void EditStartLink(string link, Models.Character character);
        void EquipItem(Models.Item item, Models.Character character);
        void DequipItem(Models.Item item, Models.Character character);
        IEnumerable<Equipped> GetEquippedItems(Models.Character character);
        void EditGold(int gold, Models.Character character);
        void EditExpAndLevel(Models.Character character, int gottenExp);
    }
}

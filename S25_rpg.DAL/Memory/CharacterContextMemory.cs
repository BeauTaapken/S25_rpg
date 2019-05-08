using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class CharacterContextMemory : ICharacterContext
    {
        private List<ICharacter> characters;
        private List<IEquipped> equipped;
        public CharacterContextMemory()
        {
            characters = new List<ICharacter>();
            characters.Add(new Character(1, 10, 10, 10, 10, 10, Eyecolor.Blue, Haircolor.Black, 0, CharacterClass.Warrior, "http://"));
            equipped =  new List<IEquipped>();
            equipped.Add(new Equipped(1, "Helmet", Equiplocation.Head));
            equipped.Add(new Equipped(1, "Sword", Equiplocation.Right));
        }

        public ICharacter AddCharacter(ICharacter character, IAccount account)
        {
            character.idCharacter = account.idAccount;
            characters.Add(character);
            return characters.FirstOrDefault(x => x.idCharacter == character.idCharacter);
        }

        public void EditStartLink(string link, ICharacter character)
        {
            characters.FirstOrDefault(x => x.idCharacter == character.idCharacter).StartPage = link;
        }

        public void EquipItem(IItem item, ICharacter character)
        {
            IEquipped equip = new Equipped(character.idCharacter, item.Name, (Equiplocation)System.Enum.Parse(typeof(Equiplocation), item.Location.ToString()));
            if (equipped.Contains(equip))
            {
                equipped.Remove(equip);
                equipped.Add(equip);
            }
            else
            {
                equipped.Add(equip);
            }
        }

        public IEnumerable<IEquipped> GetEquippedItems(ICharacter character)
        {

            IEnumerable<IEquipped> equip = equipped.FindAll(x => x.ItemId == character.idCharacter);
            return equip;
        }

        public void EditGold(int gold, ICharacter character)
        {
            characters.FirstOrDefault(x => x.idCharacter == character.idCharacter).Gold += gold;
        }

        public void EditExpAndLevel(ICharacter character, int gottenExp)
        {
            ICharacter c = characters.FirstOrDefault(x => x.idCharacter == character.idCharacter);
            c.CurrentExp += gottenExp;
            int leftExp = c.CurrentExp - c.CurrentLevel * 100;
            if (!(leftExp < -1))
            {
                characters.FirstOrDefault(x => x.idCharacter == character.idCharacter).CurrentExp = leftExp;
                characters.FirstOrDefault(x => x.idCharacter == character.idCharacter).CurrentLevel++;
            }
        }
    }
}

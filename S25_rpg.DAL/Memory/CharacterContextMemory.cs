using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class CharacterContextMemory : ICharacterContext
    {
        private List<Character> characters;
        private List<Equipped> equipped;
        public CharacterContextMemory()
        {
            characters = new List<Character>();
            characters.Add(new Character(1, 10, 10, 10, 10, 10, Eyecolor.Blue, Haircolor.Black, 0, CharacterClass.Warrior, "http://"));
            equipped =  new List<Equipped>();
            equipped.Add(new Equipped(1, "Helmet", Equiplocation.Head));
            equipped.Add(new Equipped(1, "Sword", Equiplocation.Right));
        }

        public Character AddCharacter(Character character, Account account)
        {
            character.idCharacter = account.idAccount;
            characters.Add(character);
            return characters.FirstOrDefault(x => x.idCharacter == character.idCharacter);
        }

        public void EditStartLink(string link, Character character)
        {
            characters.FirstOrDefault(x => x.idCharacter == character.idCharacter).StartPage = link;
        }

        public void EquipItem(Item item, Character character)
        {
            Equipped equip = new Equipped(character.idCharacter, item.Name, (Equiplocation)System.Enum.Parse(typeof(Equiplocation), item.Location.ToString()));
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

        public void DequipItem(Item item, Character character)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipped> GetEquippedItems(Character character)
        {

            IEnumerable<Equipped> equip = equipped.FindAll(x => x.ItemId == character.idCharacter);
            return equip;
        }

        public void EditGold(int gold, Character character)
        {
            characters.FirstOrDefault(x => x.idCharacter == character.idCharacter).Gold += gold;
        }

        public void EditExpAndLevel(Character character, int gottenExp)
        {
            Character c = characters.FirstOrDefault(x => x.idCharacter == character.idCharacter);
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

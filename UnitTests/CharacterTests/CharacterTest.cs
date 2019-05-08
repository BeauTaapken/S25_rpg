using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.CharacterTests
{
    public class CharacterTest
    {
        CharacterLogic _characterLogic;
        ICharacter equippedCharacter = new Character(1, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");
        ICharacter noEquippedCharacter = new Character(2, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");

        ICharacter warriorCharacter = new Character(3, 10,10,10,5,10,Eyecolor.Blue, Haircolor.Black, 1, CharacterClass.Warrior,"");
        ICharacter WizardCharacter = new Character(3, 10, 10, 10, 5, 10, Eyecolor.Blue, Haircolor.Black, 1, CharacterClass.Wizard, "");
        ICharacter ArcherCharacter = new Character(3, 10, 10, 10, 5, 10, Eyecolor.Blue, Haircolor.Black, 1, CharacterClass.Archer, "");
        List<IMonster> m = new List<IMonster>();
        IEnumerable<IMonster> monsters;

        public CharacterTest()
        {
            _characterLogic = new CharacterLogic(CharacterFactory.MemoryCharacterRepo());
            m.Add(new Monster("Orc", 10, 4, 10));
            m.Add(new Monster("slime", 10,10,10));
            monsters = m;
        }

        [Fact]
        public void GetEquippedItemsEquippedAccount()
        {
            IEnumerable<IEquipped> result = _characterLogic.GetEquippedItems(equippedCharacter);
            
            Assert.All(result, item => Assert.Contains(equippedCharacter.idCharacter.ToString(),  item.ItemId.ToString()));
        }

        [Fact]
        public void GetEquippedItemsNoEquippedAccount()
        {
            IEnumerable<IEquipped> result = _characterLogic.GetEquippedItems(noEquippedCharacter);

            Assert.All(result, item => Assert.Contains(equippedCharacter.idCharacter.ToString(), item.ItemId.ToString()));
        }

        [Fact]
        public void CalculateDamageWarrior()
        {
            int result = _characterLogic.CalculateDamage(warriorCharacter);

            Assert.Equal(9, result);
        }

        [Fact]
        public void CalculateDamageArcher()
        {
            int result = _characterLogic.CalculateDamage(ArcherCharacter);

            Assert.Equal(9, result);
        }

        [Fact]
        public void CalculateDamageWizard()
        {
            int result = _characterLogic.CalculateDamage(WizardCharacter);

            Assert.Equal(11, result);
        }

        [Fact]
        public void GiveDamageToMonster1()
        {
            IEnumerable<IMonster> result = _characterLogic.GiveDamage(10, 0, monsters);

            //TODO check if ienumerable are the same
        }

        [Fact]
        public void GiveDamageToMonster2()
        {
            IEnumerable<IMonster> result = _characterLogic.GiveDamage(10, 1, monsters);

            //TODO check if ienumerable are the same
        }

        [Fact]
        public void CalculateDefenceWarrior()
        {
            int result = _characterLogic.CalculateDefence(warriorCharacter);

            Assert.Equal(8, result);
        }

        [Fact]
        public void CalculateDefenceWizard()
        {
            int result = _characterLogic.CalculateDefence(WizardCharacter);

            Assert.Equal(6, result);
        }

        [Fact]
        public void CalculateDefenceArcher()
        {
            int result = _characterLogic.CalculateDefence(ArcherCharacter);

            Assert.Equal(6, result);
        }

        [Fact]
        public void CalculateHealthWarrior()
        {
            int result = _characterLogic.CalculateHealth(warriorCharacter);

            Assert.Equal(15, result);
        }

        [Fact]
        public void CalculateHealthWizard()
        {
            int result = _characterLogic.CalculateHealth(WizardCharacter);

            Assert.Equal(15, result);
        }

        [Fact]
        public void CalculateHealthArcher()
        {
            int result = _characterLogic.CalculateHealth(ArcherCharacter);

            Assert.Equal(17, result);
        }

        [Fact]
        public void TakeDamage()
        {
            int result = _characterLogic.TakeDamage(monsters, 50, 3);

            Assert.Equal(39, result);
        }
    }
}

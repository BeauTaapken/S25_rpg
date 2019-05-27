using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Models;
using Xunit;

namespace Tests.UnitTest.CharacterTests
{
    public class CharacterTest
    {
        private CharacterLogic _characterLogic;
        private Character equippedCharacter = new Character(1, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");
        private Character noEquippedCharacter = new Character(2, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");

        private Character warriorCharacter = new Character(3, 10,10,10,5,10,Eyecolor.Blue, Haircolor.Black, 1, CharacterClass.Warrior,"");
        private Character WizardCharacter = new Character(3, 10, 10, 10, 5, 10, Eyecolor.Blue, Haircolor.Black, 1, CharacterClass.Wizard, "");
        private Character ArcherCharacter = new Character(3, 10, 10, 10, 5, 10, Eyecolor.Blue, Haircolor.Black, 1, CharacterClass.Archer, "");
        private List<Monster> m = new List<Monster>();
        private IEnumerable<Monster> monsters;

        public CharacterTest()
        {
            _characterLogic = new CharacterLogic(CharacterFactory.MemoryCharacterRepo());
            m.Add(new Monster("Orc", 10, 4, 10, 2));
            m.Add(new Monster("slime", 10,10,10, 3));
            monsters = m;
        }

        [Fact]
        public void GetEquippedItemsEquippedAccount()
        {
            IEnumerable<Equipped> result = _characterLogic.GetEquippedItems(equippedCharacter);
            
            Assert.All(result, item => Assert.Contains(equippedCharacter.idCharacter.ToString(),  item.ItemId.ToString()));
        }

        [Fact]
        public void GetEquippedItemsNoEquippedAccount()
        {
            IEnumerable<Equipped> result = _characterLogic.GetEquippedItems(noEquippedCharacter);

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
        public void GiveDamageToMonster()
        {
            Monster result = _characterLogic.GiveDamage(10, monsters.ToList()[0]);

            Assert.Equal(0, result.Hp);
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

            Assert.Equal(55, result);
        }

        [Fact]
        public void CalculateHealthWizard()
        {
            int result = _characterLogic.CalculateHealth(WizardCharacter);

            Assert.Equal(55, result);
        }

        [Fact]
        public void CalculateHealthArcher()
        {
            int result = _characterLogic.CalculateHealth(ArcherCharacter);

            Assert.Equal(57, result);
        }

        [Fact]
        public void TakeDamage()
        {
            int result = _characterLogic.TakeDamage(monsters, 50, 3);

            Assert.Equal(34, result);
        }
    }
}

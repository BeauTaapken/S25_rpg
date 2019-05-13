using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.CharacterTests
{
    public class CharacterContainerTest
    {
        private CharacterContainerLogic _characterContainerLogic;
        private Account Account = new Account(10, "beau", "test", "beau@lioncode.nl");
        private Character character = new Character(0, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");

        public CharacterContainerTest()
        {
            _characterContainerLogic = new CharacterContainerLogic(CharacterContainerFactory.MemoryCharacterContainerRepo());
        }

        [Fact]
        public void AddCharacter()
        {
            Character result = _characterContainerLogic.AddCharacter(character, Account);

            Assert.Equal(Account.idAccount, result.idCharacter);
        }
    }
}

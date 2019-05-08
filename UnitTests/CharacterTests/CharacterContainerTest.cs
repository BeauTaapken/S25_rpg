using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.CharacterTests
{
    public class CharacterContainerTest
    {
        CharacterContainerLogic _characterContainerLogic;
        IAccount Account = new Account(10, "beau", "test", "beau@lioncode.nl");
        ICharacter character = new Character(0, 10, 10, 10, 10, 1, Eyecolor.Red, Haircolor.Black, 1, CharacterClass.Wizard, "");

        public CharacterContainerTest()
        {
            _characterContainerLogic = new CharacterContainerLogic(CharacterContainerFactory.MemoryCharacterContainerRepo());
        }

        [Fact]
        public void AddCharacter()
        {
            ICharacter result = _characterContainerLogic.AddCharacter(character, Account);

            Assert.Equal(Account.idAccount, result.idCharacter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.QuestTests
{
    public class QuestContainerTest
    {
        private QuestContainerLogic _questContainerLogic;
        private ICharacter charLvlTwo = new Character(1, 1, 1, 1, 1, 1, Eyecolor.Blue, Haircolor.Black, 2, CharacterClass.Warrior, "");
        private ICharacter charLvlFour = new Character(1, 1, 1, 1, 1, 1, Eyecolor.Blue, Haircolor.Black, 4, CharacterClass.Warrior, "");
        private List<IItem> items;

        public QuestContainerTest()
        {
            _questContainerLogic = new QuestContainerLogic(QuestContainerFactory.MemoryQuestContainerRepo());
            items = new List<IItem>();
            items.Add(new Item(1, "testclear", "testquest for testing", 10, 10));
        }

        [Fact]
        public void GetAcceptableQuestsLevelTwo()
        {
            IEnumerable<IQuest> result = _questContainerLogic.GetAllAcceptableQuests(charLvlTwo);
            
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAcceptableQuestsLevelFour()
        {
            IEnumerable<IQuest> result = _questContainerLogic.GetAllAcceptableQuests(charLvlFour);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetAcceptedQuests()
        {
            IEnumerable<IQuest> result = _questContainerLogic.GetAllAcceptedQuests(charLvlTwo, items);

            Assert.Single(result);
        }

        [Fact]
        public void removeAcceptedQuests()
        {
            IEnumerable<IQuest> acceptableQuests = _questContainerLogic.GetAllAcceptableQuests(charLvlFour);
            IEnumerable<IQuest> acceptedQuests = _questContainerLogic.GetAllAcceptedQuests(charLvlFour, items);
            IEnumerable<IQuest> result = _questContainerLogic.RemoveAcceptedQuests(acceptableQuests, acceptedQuests);

            Assert.Equal(2, result.Count());
        }
    }
}

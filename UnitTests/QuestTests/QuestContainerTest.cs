using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Models;
using Xunit;

namespace UnitTests.QuestTests
{
    public class QuestContainerTest
    {
        private QuestContainerLogic _questContainerLogic;
        private Character charLvlTwo = new Character(1, 1, 1, 1, 1, 1, Eyecolor.Blue, Haircolor.Black, 2, CharacterClass.Warrior, "");
        private Character charLvlFour = new Character(1, 1, 1, 1, 1, 1, Eyecolor.Blue, Haircolor.Black, 4, CharacterClass.Warrior, "");
        private List<Item> items;

        public QuestContainerTest()
        {
            _questContainerLogic = new QuestContainerLogic(QuestContainerFactory.MemoryQuestContainerRepo());
            items = new List<Item>();
            items.Add(new Item(1, "testclear", "testquest for testing", 10, 10));
        }

        [Fact]
        public void GetAcceptableQuestsLevelTwo()
        {
            IEnumerable<Quest> result = _questContainerLogic.GetAllAcceptableQuests(charLvlTwo);
            
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAcceptableQuestsLevelFour()
        {
            IEnumerable<Quest> result = _questContainerLogic.GetAllAcceptableQuests(charLvlFour);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetAcceptedQuests()
        {
            IEnumerable<Quest> result = _questContainerLogic.GetAllAcceptedQuests(charLvlTwo, items);

            Assert.Single(result);
        }

        [Fact]
        public void removeAcceptedQuests()
        {
            IEnumerable<Quest> acceptableQuests = _questContainerLogic.GetAllAcceptableQuests(charLvlFour);
            IEnumerable<Quest> acceptedQuests = _questContainerLogic.GetAllAcceptedQuests(charLvlFour, items);
            IEnumerable<Quest> result = _questContainerLogic.RemoveAcceptedQuests(acceptableQuests, acceptedQuests);

            Assert.Equal(2, result.Count());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.Quest;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class QuestContextMemory : IQuestContext
    {
        private List<IQuest> quests;
        private List<IQuest> acceptedQuests;

        public QuestContextMemory()
        {
            quests = new List<IQuest>();
            quests.Add(new Quest(1, "testquest repeatable", 1, 1, "testreward", "testquest for testing", 0, 1, "testclear", true, 1));
            quests.Add(new Quest(2, "testquest not repeatable", 1, 1, "testreward", "testquest for testing", 0, 1, "testclear", false, 1));
            quests.Add(new Quest(3, "testquest high questlvl", 1, 1, "testreward", "testquest for testing", 0, 1, "testclear", true, 4));
            acceptedQuests = new List<IQuest>();
            acceptedQuests.Add(new Quest(1, "testquest repeatable", 1, 1, "testreward", "testquest for testing", 0, 1, "testclear", true, 1));
        }

        public IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character)
        {
            IEnumerable<IQuest> quest = acceptedQuests;
            return quest;
        }

        public IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character)
        {
            IEnumerable<IQuest> q = quests.Where(x => x.QuestLevel <= character.QuestLevel);
            return q;
        }

        public void CompleteQuest(ICharacter character, IQuest quest)
        {
            throw new NotImplementedException();
        }

        public void StartQuest(ICharacter character, IQuest quest)
        {
            throw new NotImplementedException();
        }
    }
}

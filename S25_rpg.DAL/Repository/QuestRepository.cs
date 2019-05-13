using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Quest;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Repository
{
    public class QuestRepository : IQuestContext
    {
        private readonly IQuestContext _questContext;

        public QuestRepository(IQuestContext questContext = null)
        {
            _questContext = questContext ?? new QuestContextMemory();
        }

        public IEnumerable<Quest> GetAllAcceptedQuests(Character character)
        {
            return _questContext.GetAllAcceptedQuests(character);
        }

        public IEnumerable<Quest> GetAllAccapteableQuests(Character character)
        {
            return _questContext.GetAllAccapteableQuests(character);
        }

        public void CompleteQuest(Character character, Quest quest)
        {
            _questContext.CompleteQuest(character, quest);
        }

        public void StartQuest(Character character, Quest quest)
        {
            _questContext.StartQuest(character, quest);
        }
    }
}

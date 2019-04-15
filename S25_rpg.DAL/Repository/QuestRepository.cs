using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.News;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Repository
{
    public class QuestRepository : IQuestContext
    {
        private readonly IQuestContext _questContext;

        public QuestRepository(IQuestContext questContext = null)
        {
            _questContext = questContext ?? new QuestContextMemory();
        }

        public IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character)
        {
            return _questContext.GetAllAcceptedQuests(character);
        }

        public IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character)
        {
            return _questContext.GetAllAccapteableQuests(character);
        }

        public void CompleteQuest(ICharacter character, IQuest quest)
        {
            _questContext.CompleteQuest(character, quest);
        }

        public void StartQuest(ICharacter character, IQuest quest)
        {
            _questContext.StartQuest(character, quest);
        }
    }
}

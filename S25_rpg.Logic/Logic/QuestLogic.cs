using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class QuestLogic
    {
        private IQuestRepo repo = new QuestRepository(new QuestContextSql());

        public void StartQuest(ICharacter character, IQuest quest)
        {
            repo.StartQuest(character, quest);
        }

        public void CompleteQuest(ICharacter character, IQuest quest)
        {
            repo.CompleteQuest(character, quest);
        }
    }
}

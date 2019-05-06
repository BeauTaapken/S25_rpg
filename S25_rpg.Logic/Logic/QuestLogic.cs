using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.Quest;

namespace S25_rpg.Logic.Logic
{
    public class QuestLogic
    {
        private IQuestRepo repo = QuestFactory.QuestRepo();
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

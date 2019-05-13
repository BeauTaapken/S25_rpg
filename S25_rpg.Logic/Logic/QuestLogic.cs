using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Quest;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class QuestLogic
    {
        private IQuestRepo repo;

        public QuestLogic(IQuestRepo r = null)
        {
            repo = r ?? QuestFactory.MySqlQuestRepo();
        }

        public void StartQuest(Character character, Quest quest)
        {
            repo.StartQuest(character, quest);
        }

        public void CompleteQuest(Character character, Quest quest)
        {
            repo.CompleteQuest(character, quest);
        }
    }
}

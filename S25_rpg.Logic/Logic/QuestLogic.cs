using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Factory;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class QuestLogic : QuestFactory
    {
        public void StartQuest(ICharacter character, IQuest quest)
        {
            QuestRepo.StartQuest(character, quest);
        }

        public void CompleteQuest(ICharacter character, IQuest quest)
        {
            QuestRepo.CompleteQuest(character, quest);
        }
    }
}

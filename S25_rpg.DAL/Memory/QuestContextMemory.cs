﻿using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.Quest;

namespace S25_rpg.DAL.Memory
{
    public class QuestContextMemory : IQuestContext
    {
        public IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character)
        {
            throw new NotImplementedException();
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Logic
{
    public class QuestContainerLogic
    {
        private IQuestContainerRepo repo = new QuestRepository(new QuestContextSql());

        public IEnumerable<IQuest> GetAllAcceptableQuests(ICharacter character)
        {
            IEnumerable<IQuest> quests = repo.GetAllAccapteableQuests(character);
            List<IQuest> copyQuests = quests.ToList();
            foreach (IQuest quest in quests)
            {
                if (quest.QuestLevel > character.QuestLevel)
                {
                    copyQuests.Remove(quest);
                }
            }
            quests = copyQuests;
            return quests;
        }

        public IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character)
        {
            return repo.GetAllAcceptedQuests(character);
        }

        public IEnumerable<IQuest> RemoveAcceptedQuests(IEnumerable<IQuest> acceptableQuests, IEnumerable<IQuest> acceptedQuests)
        {
            acceptableQuests = acceptableQuests.ToList().Where(x => acceptedQuests.ToList().All(y => x.Id != y.Id));
            return acceptableQuests;
        }
    }
}
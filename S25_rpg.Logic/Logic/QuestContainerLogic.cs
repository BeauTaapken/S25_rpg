using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Quest;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class QuestContainerLogic
    {
        private IQuestContainerRepo repo;

        public QuestContainerLogic(IQuestContainerRepo r = null)
        {
            repo = r ?? QuestContainerFactory.MySqlQuestContainerRepo();
        }

        public IEnumerable<Quest> GetAllAcceptableQuests(Character character)
        {
            IEnumerable<Quest> quests = repo.GetAllAccapteableQuests(character);
            List<Quest> copyQuests = quests.ToList();
            foreach (Quest quest in quests)
            {
                if (quest.QuestLevel > character.QuestLevel)
                {
                    copyQuests.Remove(quest);
                }
            }
            quests = copyQuests;
            return quests;
        }

        public IEnumerable<Quest> GetAllAcceptedQuests(Character character, IEnumerable<Item> items)
        {
            IEnumerable<Quest> quests = repo.GetAllAcceptedQuests(character);
            List<Quest> copyQuests = quests.ToList();
            foreach (Quest quest in quests)
            {
                if (items.ToList().Any(x => (x.Name == quest.ClearItem) && (x.Ammount >= quest.ClearAmmount)))
                {
                    quest.Completable = true;
                }
                else
                {
                    quest.Completable = false;
                }
            }

            return quests;
        }

        public IEnumerable<Quest> RemoveAcceptedQuests(IEnumerable<Quest> acceptableQuests, IEnumerable<Quest> acceptedQuests)
        {
            acceptableQuests = acceptableQuests.ToList().Where(x => acceptedQuests.ToList().All(y => x.Id != y.Id));
            return acceptableQuests.ToList().Where(x => acceptedQuests.ToList().All(y => x.Id != y.Id));
        }
    }
}

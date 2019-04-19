using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Quest : IQuest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RewardItemId { get; set; }
        public int RewardAmmount { get; set; }
        public string RewardItem { get; set; }
        public string Description { get; set; }
        public int ClearItemId { get; set; }
        public int ClearAmmount { get; set; }
        public string ClearItem { get; set; }
        public bool Repeatable { get; set; }
        public int QuestLevel { get; set; }
        public bool Completed { get; set; }
        public bool Completable { get; set; }

        public Quest(int id, string name, int rewardAmmount, int rewardItemId, string rewardItem, string description, int clearAmmount, int clearItemId, string clearItem, bool repeatable,
            int questLevel)
        {
            Id = id;
            Name = name;
            RewardItemId = rewardItemId;
            RewardAmmount = rewardAmmount;
            RewardItem = rewardItem;
            Description = description;
            ClearItemId = clearItemId;
            ClearAmmount = clearAmmount;
            ClearItem = clearItem;
            Repeatable = repeatable;
            QuestLevel = questLevel;
        }

        public Quest(int id, string name, int rewardAmmount, int rewardItemId, string rewardItem, string description, int clearAmmount, int clearItemId, string clearItem, bool repeatable,
            int questLevel, bool completed)
        {
            Id = id;
            Name = name;
            RewardItemId = rewardItemId;
            RewardAmmount = rewardAmmount;
            RewardItem = rewardItem;
            Description = description;
            ClearItemId = clearItemId;
            ClearAmmount = clearAmmount;
            ClearItem = clearItem;
            Repeatable = repeatable;
            QuestLevel = questLevel;
            Completed = completed;
        }
    }
}

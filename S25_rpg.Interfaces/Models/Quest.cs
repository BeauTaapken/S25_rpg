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
        public string Reward { get; set; }
        public string Description { get; set; }
        public string ClearRequirement { get; set; }
        public bool Repeatable { get; set; }
        public int QuestLevel { get; set; }
        public bool Completed { get; set; }

        public Quest(int id, string name, string reward, string description, string clearRequirement, bool repeatable,
            int questLevel)
        {
            Id = id;
            Name = name;
            Reward = reward;
            Description = description;
            ClearRequirement = clearRequirement;
            Repeatable = repeatable;
            QuestLevel = questLevel;
        }

        public Quest(int id, string name, string reward, string description, string clearRequirement, bool repeatable,
            int questLevel, bool completed)
        {
            Id = id;
            Name = name;
            Reward = reward;
            Description = description;
            ClearRequirement = clearRequirement;
            Repeatable = repeatable;
            QuestLevel = questLevel;
            Completed = completed;
        }
    }
}

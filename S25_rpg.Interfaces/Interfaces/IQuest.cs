using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces
{
    public interface IQuest
    {
        int Id { get; set; }
        string Name { get; set; }
        string Reward { get; set; }
        string Description { get; set; }
        string ClearRequirement { get; set; }
        bool Repeatable { get; set; }
        int QuestLevel { get; set; }
        bool Completed { get; set; }
    }
}

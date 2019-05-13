using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Interfaces.Quest
{
    public interface IQuestRepo
    {
        void CompleteQuest(Models.Character character, Models.Quest quest);
        void StartQuest(Models.Character character, Models.Quest quest);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Quest
{
    public interface IQuestRepo
    {
        void CompleteQuest(ICharacter character, IQuest quest);
        void StartQuest(ICharacter character, IQuest quest);
    }
}

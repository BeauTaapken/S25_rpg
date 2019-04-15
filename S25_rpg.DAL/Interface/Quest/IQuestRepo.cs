using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface.Quest
{
    public interface IQuestRepo
    {
        void CompleteQuest(ICharacter character, IQuest quest);
        void StartQuest(ICharacter character, IQuest quest);
    }
}

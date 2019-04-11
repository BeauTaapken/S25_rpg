using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Interface.Quest
{
    public interface IQuestContainerRepo
    {
        IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character);

        IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character);
    }
}

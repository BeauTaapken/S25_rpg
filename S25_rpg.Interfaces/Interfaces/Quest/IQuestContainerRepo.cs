using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Quest
{
    public interface IQuestContainerRepo
    {
        IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character);

        IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character);
    }
}

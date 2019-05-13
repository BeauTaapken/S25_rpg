using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Interfaces.Quest
{
    public interface IQuestContainerRepo
    {
        IEnumerable<Models.Quest> GetAllAcceptedQuests(Models.Character character);

        IEnumerable<Models.Quest> GetAllAccapteableQuests(Models.Character character);
    }
}

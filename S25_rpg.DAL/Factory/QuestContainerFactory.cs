using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class QuestContainerFactory
    {
        public static IQuestContainerRepo QuestContainerRepo = new QuestRepository(new QuestContextSql());
    }
}

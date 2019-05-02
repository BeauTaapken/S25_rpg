using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class QuestFactory
    {
        public static IQuestRepo QuestRepo = new QuestRepository(new QuestContextSql());
    }
}

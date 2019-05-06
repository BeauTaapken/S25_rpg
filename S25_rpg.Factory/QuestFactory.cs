using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Quest;

namespace S25_rpg.Factory
{
    public static class QuestFactory
    {
        public static IQuestRepo QuestRepo()
        {
            return new QuestRepository(new QuestContextSql());
        } 
    }
}

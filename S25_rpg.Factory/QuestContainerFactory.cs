﻿using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.Quest;

namespace S25_rpg.Factory
{
    public static class QuestContainerFactory
    {
        public static IQuestContainerRepo QuestContainerRepo()
        {
            return new QuestRepository(new QuestContextSql());
        } 
    }
}

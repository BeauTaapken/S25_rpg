using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.News;
using S25_rpg.DAL.Repository;

namespace S25_rpg.DAL.Factory
{
    public class NewsContainerFactory
    {
        public static INewsContainerRepo NewsContainerRepo = new NewsRepository(new NewsContextSql());
    }
}

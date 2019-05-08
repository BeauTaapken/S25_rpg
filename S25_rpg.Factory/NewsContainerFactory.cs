using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Models.Interfaces.News;

namespace S25_rpg.Factory
{
    public class NewsContainerFactory
    {
        public static INewsContainerRepo MySqlNewsContainerRepo()
        {
            return new NewsRepository(new NewsContextSql());
        }

        public static INewsContainerRepo MemoryNewsContainerRepo()
        {
            return new NewsRepository();
        }
    }
}

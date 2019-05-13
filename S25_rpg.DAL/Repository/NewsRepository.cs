using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.News;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Repository
{
    public class NewsRepository : INewsContext
    {
        private readonly INewsContext _newsContext;

        public NewsRepository(INewsContext newsContext = null)
        {
            _newsContext = newsContext ?? new NewsContextMemory();
        }

        public List<News> GetAllNews()
        {
            return _newsContext.GetAllNews();
        }
    }
}

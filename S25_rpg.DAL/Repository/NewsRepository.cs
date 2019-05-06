﻿using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Memory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.News;

namespace S25_rpg.DAL.Repository
{
    public class NewsRepository : INewsContext
    {
        private readonly INewsContext _newsContext;

        public NewsRepository(INewsContext newsContext = null)
        {
            _newsContext = newsContext ?? new NewsContextMemory();
        }

        public List<INews> GetAllNews()
        {
            return _newsContext.GetAllNews();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.News;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Memory
{
    public class NewsContextMemory : INewsContext
    {
        private List<INews> news;
        public NewsContextMemory()
        {
            news = new List<INews>();
            news.Add(new News(1, "Testing", "This is a testing information stuff thingy"));
        }
        public List<INews> GetAllNews()
        {
            return news;
        }
    }
}

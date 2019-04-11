using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Interface.News;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.DAL.Memory
{
    public class NewsContextMemory : INewsContext
    {
        public List<INews> GetAllNews()
        {
            throw new NotImplementedException();
        }
    }
}

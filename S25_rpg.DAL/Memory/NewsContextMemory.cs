using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.News;

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

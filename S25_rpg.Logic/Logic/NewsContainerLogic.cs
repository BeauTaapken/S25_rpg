using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.News;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class NewsContainerLogic
    {
        private INewsContainerRepo repo;

        public NewsContainerLogic(INewsContainerRepo r = null)
        {
            repo = r ?? NewsContainerFactory.MySqlNewsContainerRepo();
        }

        public List<News> getAllNews()
        {
            return repo.GetAllNews();
        }
    }
}

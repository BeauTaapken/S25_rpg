using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Interfaces.News;

namespace S25_rpg.Logic.Logic
{
    public class NewsContainerLogic
    {
        private INewsContainerRepo repo;

        public NewsContainerLogic(INewsContainerRepo r = null)
        {
            repo = r ?? NewsContainerFactory.MySqlNewsContainerRepo();
        }

        public List<INews> getAllNews()
        {
            return repo.GetAllNews();
        }
    }
}

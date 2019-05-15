using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S25_rpg.Factory;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces.News;
using S25_rpg.Models.Models;
using Xunit;

namespace Tests.IntergrationTest.NewsTests
{
    public class NewsContainerTest : SetDatabase
    {
        private NewsContainerLogic _newsContainerLogic;

        public NewsContainerTest()
        {
            _newsContainerLogic = new NewsContainerLogic(NewsContainerFactory.MySqlNewsContainerRepo());
        }

        [Fact]
        public void GetAllNews()
        {
            IEnumerable<News> result = _newsContainerLogic.getAllNews();

            Assert.Single(result);
        }
    }
}

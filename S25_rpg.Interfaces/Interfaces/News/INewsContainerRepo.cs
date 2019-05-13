using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Interfaces.News
{
    public interface INewsContainerRepo
    {
        List<Models.News> GetAllNews();
    }
}

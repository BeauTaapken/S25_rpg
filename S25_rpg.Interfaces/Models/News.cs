using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Models
{
    public class News : INews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }

        public News(int id, string title, string information)
        {
            Id = id;
            Title = title;
            Information = information;
        }
    }
}

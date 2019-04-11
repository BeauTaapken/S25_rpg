using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces
{
    public interface INews
    {
        int Id { get; set; }
        string Title { get; set; }
        string Information { get; set; }
    }
}

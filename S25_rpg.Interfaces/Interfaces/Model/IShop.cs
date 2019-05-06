using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces.Model
{
    public interface IShop
    {
        string shopName { get; set; }
        IEnumerable<IItem> items { get; set; }
    }
}

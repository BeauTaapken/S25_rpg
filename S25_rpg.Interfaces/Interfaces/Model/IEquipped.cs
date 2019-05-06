using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces.Model
{
    public interface IEquipped
    {
        int ItemId { get; set; }
        string ItemName { get; set; }
        Equiplocation ItemLocation { get; set; }
    }
}

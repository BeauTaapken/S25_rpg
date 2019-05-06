using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models.Interfaces.Shop
{
    public interface IShopRepo
    {
        IShop GetAllShopItems();
    }
}

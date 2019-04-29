using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S25_rpg.Logic.Logic;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Controllers
{
    public class ShopController : Controller
    {
        private ShopLogic shopLogic = new ShopLogic();
        private ItemContainerLogic itemContainerLogic = new ItemContainerLogic();

        public IActionResult Index()
        {
            IShop shop = shopLogic.GetAllShopItems();
            ViewBag.ShopName = shop.shopName;
            ViewBag.ShopItems = shop.items;
            ICharacter character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            ViewBag.CharacterGold = character.Gold;
            ViewBag.CharacterItems = itemContainerLogic.GetAllCharacterItems(character);
            return View();
        }
    }
}
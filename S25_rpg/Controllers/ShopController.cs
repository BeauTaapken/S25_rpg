using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Controllers
{
    public class ShopController : Controller
    {
        private ShopLogic shopLogic = new ShopLogic();
        private ItemContainerLogic itemContainerLogic = new ItemContainerLogic();
        private CharacterLogic characterLogic = new CharacterLogic();

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

        [HttpPost]
        public IActionResult Index(ItemBuyModel model)
        {
            ModelState.Clear();
            IShop shop = shopLogic.GetAllShopItems();
            ViewBag.ShopName = shop.shopName;
            ViewBag.ShopItems = shop.items;
            ICharacter character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            ViewBag.CharacterGold = character.Gold;
            ViewBag.CharacterItems = itemContainerLogic.GetAllCharacterItems(character);
            if (ModelState.IsValid)
            {
                int TotalPrice = model.Ammount * model.SellPrice;
                if (TotalPrice <= character.Gold)
                {
                    characterLogic.EditGold(TotalPrice *-1, character);
                    character.Gold -= TotalPrice;
                    Response.Cookies.Append("character", JsonConvert.SerializeObject(character));
                    itemContainerLogic.AddItem(model, character);
                    ViewBag.CharacterGold = character.Gold;
                    ViewBag.Message = "Your payed " + TotalPrice + ".";
                    return View();
                }
                ViewBag.Message = "You don't have enough gold";
                return View();
            }
            ViewBag.Message = "You need to enter an ammount to buy";
            return View();
        }
    }
}
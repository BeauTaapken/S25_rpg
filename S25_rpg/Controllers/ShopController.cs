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
        private AccountLogic accountLogic = new AccountLogic();

        public IActionResult Index()
        {
            Shop shop = shopLogic.GetAllShopItems();
            ViewBag.ShopName = shop.shopName;
            ViewBag.ShopItems = shop.items;
            Character character = accountLogic.AccountHasCharacter(JsonConvert.DeserializeObject<Account>(Request.Cookies["account"]));
            Response.Cookies.Append("character", JsonConvert.SerializeObject(character));
            ViewBag.CharacterGold = character.Gold;
            ViewBag.CharacterItems = itemContainerLogic.GetAllCharacterItems(character);
            return View();
        }

        [HttpPost]
        public IActionResult Index(ItemBuyModel model)
        {
            ModelState.Clear();
            Shop shop = shopLogic.GetAllShopItems();
            ViewBag.ShopName = shop.shopName;
            ViewBag.ShopItems = shop.items;
            Character character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            ViewBag.CharacterGold = character.Gold;
            ViewBag.CharacterItems = itemContainerLogic.GetAllCharacterItems(character);
            if (ModelState.IsValid)
            {
                int totalPrice = model.Ammount * model.SellPrice;
                if (totalPrice <= character.Gold)
                {
                    characterLogic.EditGold(totalPrice * -1, character);
                    character.Gold -= totalPrice;
                    Response.Cookies.Append("character", JsonConvert.SerializeObject(character));
                    Item i = new Item(model.Id, model.Ammount, model.Name, model.Description, model.SellPrice, model.Equipable, model.Damage, model.Defence, model.Location);
                    itemContainerLogic.AddItem(i, character);
                    ViewBag.CharacterGold = character.Gold;
                    ViewBag.Message = "Your payed " + totalPrice + ".";
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
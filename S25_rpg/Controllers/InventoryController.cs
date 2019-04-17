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
    public class InventoryController : Controller
    {
        private CharacterLogic characterLogic = new CharacterLogic();

        public IActionResult Index()
        {
            ViewBag.Items = JsonConvert.DeserializeObject<IEnumerable<Item>>(Request.Cookies["items"]);
            ViewBag.Equipped = JsonConvert.DeserializeObject<IEnumerable<Equipped>>(Request.Cookies["equipped"]);
            return View();
        }

        public IActionResult EquipItem(ItemEquipViewModel itemModel)
        {
            characterLogic.EquipItem(itemModel, JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            IEnumerable<IEquipped> equippedItems = characterLogic.GetEquippedItems(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equippedItems));
            return RedirectToAction("Index", "Inventory");
        }
    }
}
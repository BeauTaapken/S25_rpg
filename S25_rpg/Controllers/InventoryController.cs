using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;
using S25_rpg.Models.Models;

namespace S25_rpg.Controllers
{
    public class InventoryController : Controller
    {
        private CharacterLogic characterLogic = new CharacterLogic();
        private ItemContainerLogic _itemContainerLogic = new ItemContainerLogic();

        public IActionResult Index()
        {
            ViewBag.Items = _itemContainerLogic.GetAllCharacterItems(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            ViewBag.Equipped = JsonConvert.DeserializeObject<IEnumerable<Equipped>>(Request.Cookies["equipped"]);
            return View();
        }

        public IActionResult EquipItem(ItemEquipViewModel itemModel)
        {
            ICharacter character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            characterLogic.EquipItem(itemModel, character);
            IEnumerable<IEquipped> equippedItems = characterLogic.GetEquippedItems(character);
            Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equippedItems));
            return RedirectToAction("Index", "Inventory");
        }

        public IActionResult DequipItem(ItemDequipViewModel model)
        {
            ICharacter character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            characterLogic.DequipItem(model, character);
            IEnumerable<IEquipped> equippedItems = characterLogic.GetEquippedItems(character);
            Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equippedItems));
            return RedirectToAction("Index", "Inventory");
        }
    }
}
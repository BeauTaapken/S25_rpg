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
        private ItemContainerLogic _itemContainerLogic = new ItemContainerLogic();

        public IActionResult Index()
        {
            ViewBag.Items = _itemContainerLogic.GetAllCharacterItems(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            ViewBag.Equipped = JsonConvert.DeserializeObject<IEnumerable<Equipped>>(Request.Cookies["equipped"]);
            return View();
        }

        public IActionResult EquipItem(ItemEquipViewModel itemModel)
        {
            Character character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            Item i = new Item(itemModel.Id, itemModel.Ammount, itemModel.Name, itemModel.Description, itemModel.SellPrice, itemModel.Equipable, itemModel.Damage, itemModel.Defence, itemModel.Location);
            characterLogic.EquipItem(i, character);
            IEnumerable<Equipped> equippedItems = characterLogic.GetEquippedItems(character);
            Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equippedItems));
            return RedirectToAction("Index", "Inventory");
        }

        public IActionResult DequipItem(ItemDequipViewModel model)
        {
            Character character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            Item i = new Item(model.Id, model.Ammount, model.Name, model.Description, model.SellPrice, model.Equipable, model.Damage, model.Defence, model.Location);
            characterLogic.DequipItem(i, character);
            IEnumerable<Equipped> equippedItems = characterLogic.GetEquippedItems(character);
            Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equippedItems));
            return RedirectToAction("Index", "Inventory");
        }
    }
}
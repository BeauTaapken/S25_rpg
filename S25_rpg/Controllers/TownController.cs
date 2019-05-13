using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Newtonsoft.Json;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Controllers
{
    public class TownController : Controller
    {
        private NewsContainerLogic _newsContainerLogic = new NewsContainerLogic();
        private QuestContainerLogic _questContainerLogic = new QuestContainerLogic();
        private QuestLogic _questLogic = new QuestLogic();
        private ItemContainerLogic _itemContainerLogic = new ItemContainerLogic();

        public IActionResult Index()
        {
            ViewBag.TownName = "First city";
            return View();
        }

        public IActionResult News()
        {
            ViewBag.News = _newsContainerLogic.getAllNews();
            return View();
        }

        public IActionResult Tavern()
        {
            return View();
        }

        public IActionResult Quest()
        {
            IEnumerable<Item> items = _itemContainerLogic.GetAllCharacterItems(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            IEnumerable<Quest> acceptedQuests = _questContainerLogic.GetAllAcceptedQuests(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]), items);
            IEnumerable<Quest> acceptableQuests = _questContainerLogic.GetAllAcceptableQuests(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            acceptableQuests = _questContainerLogic.RemoveAcceptedQuests(acceptableQuests, acceptedQuests);

            ViewBag.AcceptedQuests = acceptedQuests;
            ViewBag.Quests = acceptableQuests;
            return View();
        }
        
        public IActionResult AcceptQuest(QuestStartViewModel model)
        {
            Quest q = new Quest(model.Id, model.Name, model.RewardAmmount, model.RewardItemId, model.RewardItem, model.Description, model.ClearAmmount, model.ClearItemId, model.ClearItem, model.Repeatable, model.QuestLevel);
            _questLogic.StartQuest(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]), q);
            return RedirectToAction("Quest");
        }

        public IActionResult CompleteQuest(QuestCompleteViewModel model)
        {
            Character character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
            Quest q = new Quest(model.Id, model.Name, model.RewardAmmount, model.RewardItemId, model.RewardItem, model.Description, model.ClearAmmount, model.ClearItemId, model.ClearItem, model.Repeatable, model.QuestLevel);
            _questLogic.CompleteQuest(character, q);
            _itemContainerLogic.RemoveItem(new Item(model.ClearItemId, model.ClearAmmount), character);
            _itemContainerLogic.AddItem(new Item(model.RewardItemId, model.RewardAmmount), character);
            IEnumerable<Item> item = _itemContainerLogic.GetAllCharacterItems(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            Response.Cookies.Append("items", JsonConvert.SerializeObject(item));
            return RedirectToAction("Quest");
        }
    }
}
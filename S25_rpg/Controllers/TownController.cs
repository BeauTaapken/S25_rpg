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
            IEnumerable<IQuest> acceptedQuests = _questContainerLogic.GetAllAcceptedQuests(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]), JsonConvert.DeserializeObject<List<Item>>(Request.Cookies["items"]));
            IEnumerable<IQuest> acceptableQuests = _questContainerLogic.GetAllAcceptableQuests(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            acceptableQuests = _questContainerLogic.RemoveAcceptedQuests(acceptableQuests, acceptedQuests);

            ViewBag.AcceptedQuests = acceptedQuests;
            ViewBag.Quests = acceptableQuests;
            return View();
        }
        
        public IActionResult AcceptQuest(QuestStartViewModel model)
        {
            _questLogic.StartQuest(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]), model);
            return RedirectToAction("Quest");
        }

        public IActionResult CompleteQuest(QuestCompleteViewModel model)
        {
            _questLogic.CompleteQuest(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]), model);
            IEnumerable<IItem> item = _itemContainerLogic.GetAllCharacterItems(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            Response.Cookies.Append("items", JsonConvert.SerializeObject(item));
            return RedirectToAction("Quest");
        }
    }
}
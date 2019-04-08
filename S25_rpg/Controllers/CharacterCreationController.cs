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
    public class CharacterCreationController : Controller
    {
        CharacterCollectionLogic characterCollectionLogic = new CharacterCollectionLogic();

        public IActionResult CharacterCreation()
        {
            ViewBag.Haircolor = Enum.GetValues(typeof(Haircolor));
            ViewBag.Eyecolor = Enum.GetValues(typeof(Eyecolor));
            ViewBag.CharacterClass = Enum.GetValues(typeof(CharacterClass));
            return View();
        }

        [HttpPost]
        public IActionResult CharacterCreation(CharacterViewModel character)
        {
            if (ModelState.IsValid)
            {
                ICharacter c = characterCollectionLogic.AddCharacter(character, JsonConvert.DeserializeObject<Account>(Request.Cookies["account"]));
                Response.Cookies.Append("character", JsonConvert.SerializeObject(c));
            }

            ViewBag.Haircolor = Enum.GetValues(typeof(Haircolor));
            ViewBag.Eyecolor = Enum.GetValues(typeof(Eyecolor));
            ViewBag.CharacterClass = Enum.GetValues(typeof(CharacterClass));
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;

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

            }

            return null;
        }
    }
}
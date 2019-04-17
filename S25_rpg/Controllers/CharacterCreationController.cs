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
        CharacterContainerLogic _characterContainerLogic = new CharacterContainerLogic();
        CharacterLogic characterLogic = new CharacterLogic();

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
                ICharacter c = _characterContainerLogic.AddCharacter(character, JsonConvert.DeserializeObject<Account>(Request.Cookies["account"]));
                if (c != null)
                {
                    Response.Cookies.Append("character", JsonConvert.SerializeObject(c));
                    IEnumerable<IEquipped> equipped = characterLogic.GetEquippedItems(character);
                    Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equipped));
                    return RedirectToAction("Index", "Town");
                }
                
            }

            ViewBag.Haircolor = Enum.GetValues(typeof(Haircolor));
            ViewBag.Eyecolor = Enum.GetValues(typeof(Eyecolor));
            ViewBag.CharacterClass = Enum.GetValues(typeof(CharacterClass));
            return View();
        }
    }
}
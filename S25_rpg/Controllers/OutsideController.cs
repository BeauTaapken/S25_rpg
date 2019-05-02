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
    public class OutsideController : Controller
    {
        private CharacterLogic _characterLogic = new CharacterLogic();

        public IActionResult Index()
        {
            AreaContent content = _characterLogic.NextArea();
            ViewBag.ExploreType = content.ToString();
            if (content == AreaContent.Gold)
            {
                int goldAmmount = _characterLogic.Gold();
                ViewBag.GoldAmmount = goldAmmount;
                _characterLogic.EditGold(goldAmmount, JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
            }
            else if (content == AreaContent.Monster)
            {
                ViewBag.health = _characterLogic.CalculateHealth(JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]));
                ViewBag.monsters = _characterLogic.Monsters();
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(AttackMonsterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ExploreType = AreaContent.Monster.ToString();
                ICharacter character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
                IEnumerable<IMonster> monsters = JsonConvert.DeserializeObject<IEnumerable<Monster>>(model.monsters);
                if (model.flee)
                {
                    bool escaped = _characterLogic.Flee();
                    if (escaped)
                    {
                        return RedirectToAction("Index", "Outside");
                    }

                    ViewBag.Message = "Fleeing failed";
                }

                else
                {
                    
                    int damage = _characterLogic.CalculateDamage(character);
                    monsters = _characterLogic.GiveDamage(damage, model.monsterLocation, monsters);

                    if (monsters.All(x => x.Hp < 1))
                    {
                        _characterLogic.EarnExpAndLevelUp(character, monsters);
                        return RedirectToAction("Index", "Outside");
                    }

                    int defence = _characterLogic.CalculateDefence(character);
                    model.characterHp = _characterLogic.TakeDamage(monsters, model.monsterLocation, model.characterHp, defence);
                }
                

                ModelState.Clear();
                ViewBag.monsters = monsters;
                ViewBag.health = model.characterHp;
            }
            
            return View();
        }
    }
}
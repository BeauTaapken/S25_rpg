﻿using System;
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
        private ItemContainerLogic _itemContainerLogic = new ItemContainerLogic();

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
                Character character = JsonConvert.DeserializeObject<Character>(Request.Cookies["character"]);
                IEnumerable<Monster> monsters = JsonConvert.DeserializeObject<IEnumerable<Monster>>(model.monsters);
                if (model.flee)
                {
                    bool escaped = _characterLogic.Flee();
                    if (escaped)
                    {
                        return RedirectToAction("Index", "Outside");
                    }

                    ViewBag.Message = "Fleeing failed";
                }
                
                if (!(model.flee))
                {
                    int damage = _characterLogic.CalculateDamage(character);
                    List<Monster> monsterList = monsters.ToList();
                    monsterList[model.monsterLocation] = _characterLogic.GiveDamage(damage, monsters.ToList()[model.monsterLocation]);
                    monsters = monsterList;

                    if (monsters.All(x => x.Hp < 1))
                    {
                        int totalExp = 0;
                        foreach (Monster monster in monsters)
                        {
                            if (monster.ItemDropId != 0)
                            {
                                _itemContainerLogic.AddItem(new Item(monster.ItemDropId, 1), character);
                            }

                            totalExp += monster.Exp;
                        }

                        _characterLogic.EarnExpAndLevelUp(character, totalExp);
                        return RedirectToAction("Index", "Outside");
                    }
                }
                

                int defence = _characterLogic.CalculateDefence(character);
                model.characterHp = _characterLogic.TakeDamage(monsters, model.characterHp, defence);
                if (model.characterHp <= 0)
                {
                    model.characterHp = 0;
                    ViewBag.Message = "You died";
                }
                

                ModelState.Clear();
                ViewBag.monsters = monsters;
                ViewBag.health = model.characterHp;
            }
            
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S25_rpg.DAL;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.Logic;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Controllers
{
    public class AccountController : Controller
    {
        AccountLogic accountLogic = new AccountLogic();
        AccountContainerLogic _accountContainerLogic = new AccountContainerLogic();
        ItemContainerLogic _itemContainerLogic = new ItemContainerLogic();
        CharacterLogic characterLogic = new CharacterLogic();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel accountModel)
        {
            if (ModelState.IsValid)
            {
                IAccount account = _accountContainerLogic.Login(accountModel);

                if (account != null)
                {
                    if (account.idAccount != 0)
                    {
                        Response.Cookies.Append("account", JsonConvert.SerializeObject(account));
                        ICharacter character = accountLogic.AccountHasCharacter(account);
                        if (character == null)
                        {
                            return RedirectToAction("CharacterCreation", "CharacterCreation");
                        }
                        Response.Cookies.Append("character", JsonConvert.SerializeObject(character));
                        IEnumerable<IEquipped> equipped = characterLogic.GetEquippedItems(character);
                        Response.Cookies.Append("equipped", JsonConvert.SerializeObject(equipped));
                        return RedirectToAction("Index", "Town");
                    }
                }

                ViewBag.Message = "Username and/or password are not correct";
                return View();
            }

            ViewBag.Message = "Username and/or password have not been entered";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.RepeatPassword)
                {
                    if (!(_accountContainerLogic.CheckIfAccountExist(model)))
                    {
                        _accountContainerLogic.InsertAccount(model);
                        return RedirectToAction("Login", "Account");
                    }
                    ViewBag.Message = "An account with the username and/or email address already exists";
                    return View();
                }
                ViewBag.Message = "Passwords are not the same";
                return View();
            }
            ViewBag.Message = "Not all information is entered";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            foreach (string cookieKey in Request.Cookies.Keys)
            {
                if (cookieKey != ".AspNet.Consent")
                {
                    Response.Cookies.Delete(cookieKey);
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}

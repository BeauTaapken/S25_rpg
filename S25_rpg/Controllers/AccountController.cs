using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S25_rpg.DAL;
using S25_rpg.DAL.IContext;
using S25_rpg.DAL.Interface.Account;
using S25_rpg.Logic;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Controllers
{
    public class AccountController : Controller
    {
        AccountLogic accountLogic = new AccountLogic();
        AccountCollectionLogic accountCollectionLogic = new AccountCollectionLogic();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel accountModel)
        {
            if (ModelState.IsValid)
            {
                IAccount account = accountCollectionLogic.Login(accountModel);

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
                        //TODO change to main screen when logged in
                        Response.Cookies.Append("character", JsonConvert.SerializeObject(character));
                        return RedirectToAction("Login", "Account");
                    }
                }
                return RedirectToAction("Register", "Account");
            }
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
                if (model.Password == model.RepeatPassword && !(accountCollectionLogic.CheckIfAccountExist(model)))
                {
                    accountCollectionLogic.InsertAccount(model);
                    return RedirectToAction("Login", "Account");
                }

                return RedirectToAction("Register", "Account");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S25_rpg.DAL;
using S25_rpg.Logic;
using S25_rpg.Models;

namespace S25_rpg.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountContext _accountContext;

        public AccountController(IAccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckLogin(AccountViewModel model)
        {
            var accountLogic = new AccountLogic(_accountContext);
            if (accountLogic.Login(model.Username, model.Password))
            {
                int accountId = accountLogic.GetUserId(model.Username, model.Password);
                if (accountId != 0)
                {
                    return RedirectToAction("Login", "Account", accountId);
                }
            }
            return RedirectToAction("Register", "Account");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAccount(AccountViewModel model, string repeatPassword)
        {
            var accountLogic = new AccountLogic(_accountContext);
            if (model.Password == repeatPassword && !(accountLogic.CheckIfAccountExist(model.Username, model.Email)))
            {
                //TODO add insert of account
                accountLogic.InsertAccount(model.Username, model.Password, model.Email);
            }

            return RedirectToAction("Register", "Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S25_rpg.DAL;
using S25_rpg.DAL.IContext;
using S25_rpg.Logic;
using S25_rpg.Logic.Logic;
using S25_rpg.Models;

namespace S25_rpg.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountContext _accountContext;
        private readonly IAccountCharacterContext _accountCharacterContext;

        public AccountController(IAccountContext accountContext, IAccountCharacterContext accountCharacterContext)
        {
            _accountContext = accountContext;
            _accountCharacterContext = accountCharacterContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckLogin(AccountViewModel accountModel, AccountCharacterViewModel accountCharacterModel)
        {
            var accountLogic = new AccountLogic(_accountContext);
            var accountCharacterLogic = new AccountCharacterLogic(_accountCharacterContext);
            if (accountLogic.Login(accountModel.Username, accountModel.Password))
            {
                accountModel.idAccount = accountLogic.GetUserId(accountModel.Username, accountModel.Password);
                if (accountModel.idAccount != 0)
                {
                    accountCharacterModel.Account_idAccount = accountModel.idAccount;
                    if (!accountCharacterLogic.AccountHasCharacter(accountCharacterModel.Account_idAccount))
                    {
                        return RedirectToAction("CharacterCreation", "CharacterCreation");
                    }
                    //TODO change to main screen when logged in
                    return RedirectToAction("Login", "Account");
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

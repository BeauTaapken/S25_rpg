using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace S25_rpg.Controllers
{
    public class CharacterCreationController : Controller
    {
        public IActionResult CharacterCreation()
        {
            return View();
        }
    }
}
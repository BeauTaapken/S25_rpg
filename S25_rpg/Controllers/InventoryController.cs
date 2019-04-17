using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S25_rpg.Models.Models;

namespace S25_rpg.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Items = JsonConvert.DeserializeObject<List<Item>>(Request.Cookies["items"]);
            return View();
        }
    }
}
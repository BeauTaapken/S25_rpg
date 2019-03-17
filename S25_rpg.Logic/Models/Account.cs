using S25_rpg.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Logic.Models
{
    internal class Account : IAccount
    {
        public int idAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

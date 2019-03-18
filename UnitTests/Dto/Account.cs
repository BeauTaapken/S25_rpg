using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Interfaces;

namespace UnitTests.Dto
{
    class Account:IAccount
    {
        public int idAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

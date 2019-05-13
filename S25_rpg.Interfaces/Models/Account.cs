using S25_rpg.Models;
using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models.Models
{
    public class Account
    {
        public int idAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Account(int id, string username, string password, string email)
        {
            idAccount = id;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}

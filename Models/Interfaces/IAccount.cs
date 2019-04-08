using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Interfaces
{
    public interface IAccount
    {
        int idAccount { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}

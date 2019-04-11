using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models
{
    public class AccountViewModel : IAccount
    {
        public int idAccount { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

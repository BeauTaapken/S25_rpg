using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models
{
    public class AttackMonsterViewModel
    {
        public int monsterLocation { get; set; }
        [Required]
        public string monsters { get; set; }
        [Required]
        public int characterHp { get; set; }
        public bool flee { get; set; }
    }
}

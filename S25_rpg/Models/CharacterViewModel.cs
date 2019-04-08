using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models
{
    public class CharacterViewModel : ICharacter
    {
        public int idCharacter { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int CurrentExp { get; set; }
        [Required]
        public int CurrentLevel { get; set; }
        [Required]
        public Eyecolor Eyecolor { get; set; }
        [Required]
        public Haircolor Haircolor { get; set; }
        public int Unlockpoint { get; set; }
        [Required]
        public CharacterClass CharacterClass { get; set; }
        public string StartPage { get; set; }
    }
}

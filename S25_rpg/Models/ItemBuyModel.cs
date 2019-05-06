using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models
{
    public class ItemBuyModel : IItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Ammount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int buyPrice { get; set; }
        [Required]
        public int SellPrice { get; set; }
        public bool Equipable { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public Equiplocation? Location { get; set; }
    }
}

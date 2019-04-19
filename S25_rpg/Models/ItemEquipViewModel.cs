﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models
{
    public class ItemEquipViewModel : IItem
    {
        [Required]
        public int Id { get; set; }
        public int Ammount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SellPrice { get; set; }
        public bool Equipable { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        [Required]
        public Equiplocation? Location { get; set; }
    }
}
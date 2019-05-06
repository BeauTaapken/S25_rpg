using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Models
{
    public class QuestCompleteViewModel : IQuest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int RewardItemId { get; set; }
        [Required]
        public int RewardAmmount { get; set; }
        [Required]
        public string RewardItem { get; set; }
        public string Description { get; set; }
        [Required]
        public int ClearItemId { get; set; }
        [Required]
        public int ClearAmmount { get; set; }
        [Required]
        public string ClearItem { get; set; }
        public bool Repeatable { get; set; }
        public int QuestLevel { get; set; }
        public bool Completed { get; set; }
        public bool Completable { get; set; }
    }
}

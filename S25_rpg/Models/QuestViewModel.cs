using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Models
{
    public class QuestViewModel : IQuest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RewardAmmount { get; set; }
        public string RewardItem { get; set; }
        public string Description { get; set; }
        public int ClearAmmount { get; set; }
        public string ClearItem { get; set; }
        public bool Repeatable { get; set; }
        public int QuestLevel { get; set; }
        public bool Completed { get; set; }
    }
}

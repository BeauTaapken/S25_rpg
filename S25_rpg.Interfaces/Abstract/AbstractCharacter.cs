using System;
using System.Collections.Generic;
using System.Text;

namespace S25_rpg.Models.Abstract
{
    public abstract class AbstractCharacter
    {
        public abstract int health { get; set; }
        public abstract int damage { get; set; }
        public abstract int defence { get; set; }
    }
}

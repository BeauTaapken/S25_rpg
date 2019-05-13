using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Interface
{
    public interface IFight
    {
        int CalculateDamage(Character character);
        IEnumerable<Monster> GiveDamage(int damage, int monsterLocation, IEnumerable<Monster> monsters);
        int CalculateDefence(Character character);
        int CalculateHealth(Character character);
        int TakeDamage(IEnumerable<Monster>monsters, int health, int defense);
        bool Flee();
        void EarnExpAndLevelUp(Character character, IEnumerable<Monster> monsters);
    }
}

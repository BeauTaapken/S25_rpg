using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Model;

namespace S25_rpg.Logic.Interface
{
    public interface IFight
    {
        int CalculateDamage(ICharacter character);
        IEnumerable<IMonster> GiveDamage(int damage, int monsterLocation, IEnumerable<IMonster> monsters);
        int CalculateDefence(ICharacter character);
        int CalculateHealth(ICharacter character);
        int TakeDamage(IEnumerable<IMonster>monsters, int health, int defense);
        bool Flee();
        void EarnExpAndLevelUp(ICharacter character, IEnumerable<IMonster> monsters);
    }
}

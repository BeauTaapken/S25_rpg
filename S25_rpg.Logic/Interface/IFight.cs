﻿using System;
using System.Collections.Generic;
using System.Text;
using S25_rpg.Models.Interfaces;

namespace S25_rpg.Logic.Interface
{
    public interface IFight
    {
        int CalculateDamage(ICharacter character);
        IEnumerable<IMonster> GiveDamage(int damage, int monsterLocation, IEnumerable<IMonster> monsters);
        int CalculateDefence(ICharacter character);
        int CalculateHealth(ICharacter character);
        int TakeDamage(IEnumerable<IMonster>monsters, int monsterLocation, int health, int defense);
        bool Flee();
        void EarnExpAndLevelUp(ICharacter character, IEnumerable<IMonster> monsters);
    }
}
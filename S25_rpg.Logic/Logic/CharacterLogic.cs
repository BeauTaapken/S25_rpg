using System;
using System.Collections.Generic;
using System.Linq;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Interface.Character;
using S25_rpg.DAL.Repository;
using S25_rpg.Logic.Interface;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class CharacterLogic : IExplore, IFight
    {
        private ICharacterRepo repo = new CharacterRepository(new CharacterContextSql());

        public void EquipItem(IItem item, ICharacter character)
        {
            repo.EquipItem(item, character);
        }

        public IEnumerable<IEquipped> GetEquippedItems(ICharacter character)
        {
            return repo.GetEquippedItems(character);
        }

        public AreaContent NextArea()
        {
            Array areaContents = Enum.GetValues(typeof(AreaContent));
            Random random = new Random();
            AreaContent areaContent = (AreaContent)areaContents.GetValue(random.Next(areaContents.Length));
            return areaContent;
        }

        public IEnumerable<IMonster> Monsters()
        {
            List<IMonster> monsterList = new List<IMonster>();
            Random random = new Random();
            int monsterAmmount = random.Next(1, 6);
            for (int i = 0; i < monsterAmmount; i++)
            {
                Array monsters = Enum.GetValues(typeof(MonsterChoice));
                MonsterChoice monster = (MonsterChoice)monsters.GetValue(random.Next(monsters.Length));
                switch (monster)
                {
                    case (MonsterChoice)0:
                        monsterList.Add(new Monster(monster.ToString(), 10, 1, 10));
                        break;
                    case (MonsterChoice)1:
                        monsterList.Add(new Monster(monster.ToString(), 10, 1, 10));
                        break;
                    case (MonsterChoice)2:
                        monsterList.Add(new Monster(monster.ToString(), 10, 1, 10));
                        break;
                    default:
                        break;
                }
            }

            IEnumerable<IMonster> allMonsters = monsterList;

            return allMonsters;
        }

        public int Gold()
        {
            Random random = new Random();
            return random.Next(10, 100);
        }

        public void EditGold(int gold, ICharacter character)
        {
            repo.EditGold(gold, character);
        }

        public int CalculateDamage(ICharacter character)
        {
            //TODO add equipment to equation
            int damage = 4;
            if (character.CharacterClass == CharacterClass.Wizard)
            {
                damage += 2;
            }
            damage += character.CurrentLevel;
            return damage;
        }

        public IEnumerable<IMonster> GiveDamage(int damage, int monsterLocation, IEnumerable<IMonster> monsters)
        {
            List<IMonster> monsterList = monsters.ToList();
            monsterList[monsterLocation].Hp -= damage;
            if (monsterList[monsterLocation].Hp < 0)
            {
                monsterList[monsterLocation].Hp = 0;
            }
            monsters = monsterList;
            return monsters;
        }

        public int CalculateDefence(ICharacter character)
        {
            //TODO add equipment to equation
            int defence = 1;
            if (character.CharacterClass == CharacterClass.Warrior)
            {
                defence += 2;
            }

            defence += character.CurrentLevel;
            return defence;
        }

        public int CalculateHealth(ICharacter character)
        {
            int health = 10;
            if (character.CharacterClass == CharacterClass.Archer)
            {
                health += 2;
            }
            health += character.CurrentLevel;
            return health;
        }

        public int TakeDamage(IEnumerable<IMonster> monsters, int monsterLocation, int health, int defense)
        {
            int damage = 0;
            foreach (IMonster monster in monsters.Where(x => x.Hp > 0))
            {
                damage += monster.Damage;
            }
            damage -= defense;
            if (damage > 0)
            {
                health = health - damage;
            }

            return health;
        }

        public bool Flee()
        {
            Random random = new Random();
            int chance = random.Next(0, 101);
            return chance >= 60;
        }

        public void EarnExpAndLevelUp(ICharacter character, IEnumerable<IMonster> monsters)
        {
            int totalExp = 0;
            foreach (IMonster monster in monsters)
            {
                totalExp += monster.Exp;
            }
            repo.EditExpAndLevel(character, totalExp);
        }
    }
}

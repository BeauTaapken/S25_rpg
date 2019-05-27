using System;
using System.Collections.Generic;
using System.Linq;
using S25_rpg.DAL.Context;
using S25_rpg.DAL.Repository;
using S25_rpg.Factory;
using S25_rpg.Logic.Interface;
using S25_rpg.Models;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Character;
using S25_rpg.Models.Models;

namespace S25_rpg.Logic.Logic
{
    public class CharacterLogic : IExplore, IFight
    {
        private ICharacterRepo repo;
        private Random random = new Random();

        public CharacterLogic(ICharacterRepo r = null)
        {
            repo = r ?? CharacterFactory.MySqlCharacterRepo();
        }

        public void EquipItem(Item item, Character character)
        {
            repo.EquipItem(item, character);
        }

        public IEnumerable<Equipped> GetEquippedItems(Character character)
        {
            return repo.GetEquippedItems(character);
        }

        public void DequipItem(Item item, Character character)
        {
            repo.DequipItem(item, character);
        }

        public AreaContent NextArea()
        {
            Array areaContents = Enum.GetValues(typeof(AreaContent));
            
            AreaContent areaContent = (AreaContent)areaContents.GetValue(random.Next(areaContents.Length));
            return areaContent;
        }

        public IEnumerable<Monster> Monsters()
        {
            List<Monster> monsterList = new List<Monster>();
            int monsterAmmount = random.Next(1, 6);
            for (int i = 0; i < monsterAmmount; i++)
            {
                Array monsters = Enum.GetValues(typeof(MonsterChoice));
                MonsterChoice monster = (MonsterChoice)monsters.GetValue(random.Next(monsters.Length));
                switch (monster)
                {
                    case (MonsterChoice)0:
                        monsterList.Add(new Monster(monster.ToString(), 5, 10, 10, 2));
                        break;
                    case (MonsterChoice)1:
                        monsterList.Add(new Monster(monster.ToString(), 10, 10, 15, 3));
                        break;
                    case (MonsterChoice)2:
                        monsterList.Add(new Monster(monster.ToString(), 15, 15, 20, 4));
                        break;
                    default:
                        break;
                }
            }

            return monsterList;
        }

        public int Gold()
        {
            return random.Next(10, 100);
        }

        public void EditGold(int gold, Character character)
        {
            repo.EditGold(gold, character);
        }

        public int CalculateDamage(Character character)
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

        public Monster GiveDamage(int damage, Monster monster)
        {
            monster.Hp = Math.Max(0, monster.Hp - damage);
            //monster.Hp -= damage; // check math.max
            //if (monster.Hp < 0)
            //{
            //    monster.Hp = 0;
            //}
            return monster;
        }

        public int CalculateDefence(Character character)
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

        public int CalculateHealth(Character character)
        {
            int health = 50;
            if (character.CharacterClass == CharacterClass.Archer)
            {
                health += 2;
            }
            health += character.CurrentLevel;
            return health;
        }

        public int TakeDamage(IEnumerable<Monster> monsters, int health, int defense)
        {
            foreach (Monster monster in monsters.Where(x => x.Hp > 0))
            {
                health -= Math.Max(monster.Damage - defense, 0);
                int damage = monster.Damage - defense;
                if (damage > 0)
                {
                    health -= damage;
                }
            }

            return health;
        }

        public bool Flee()
        {
            int chance = random.Next(0, 101);
            return chance >= 60;
        }

        public void EarnExpAndLevelUp(Character character, int totalExp)
        {
            int? exp = repo.GetCharacterExp(character);
            if (exp != null)
            {
                int? lvl = repo.GetCharacterLevel(character);
                if (lvl != null)
                {
                    int neededExp = (int)lvl * 100;
                    bool LevelUp = false;
                    if (exp + totalExp >= neededExp)
                    {
                        exp = (exp + totalExp) - neededExp;
                        LevelUp = true;
                    }
                    else
                    {
                        exp += totalExp;
                    }
                    repo.EditExpAndLevel(character, (int)exp, LevelUp);
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.DAL.Interface.Quest;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class QuestContextSql : DatabaseConnection, IQuestContext
    {
        public IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character)
        {
            IEnumerable<IQuest> quests = new List<IQuest>();
            try
            {
                mySqlConnection.Open();

                MySqlCommand getAllAcceptableQuests = new MySqlCommand("SELECT Quest.*, characterquest.Completed FROM Quest LEFT JOIN `characterquest` ON quest.Id = characterquest.Quest_id AND characterquest.Character_id = @id", mySqlConnection);
                getAllAcceptableQuests.Parameters.AddWithValue("@id", character.idCharacter);
                MySqlDataReader reader = getAllAcceptableQuests.ExecuteReader();
                List<IQuest> quest = new List<IQuest>();
                while (reader.Read())
                {
                    quest.Add(new Quest((int) reader[0], (string) reader[1], (string) reader[2], (string) reader[3], (string) reader[4], (bool) reader[5], (int) reader[6], reader[7] as bool? ?? false));
                }

                IEnumerable<IQuest> q = quest;
                return quests.Concat(q);
            }
            catch
            {
                return quests;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public IEnumerable<IQuest> GetAllAcceptedQuests(ICharacter character)
        {
            IEnumerable<IQuest> quests = new List<IQuest>();
            try
            {
                mySqlConnection.Open();

                MySqlCommand getAllAcceptedQuests = new MySqlCommand("SELECT * FROM `quest` INNER JOIN `characterquest` ON quest.Id = characterquest.Quest_id WHERE characterquest.Character_id = @characterid", mySqlConnection);
                getAllAcceptedQuests.Parameters.AddWithValue("@characterid", character.idCharacter);
                MySqlDataReader reader = getAllAcceptedQuests.ExecuteReader();
                List<IQuest> quest = new List<IQuest>();
                while (reader.Read())
                {
                    quest.Add(new Quest((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (bool)reader[5], (int)reader[6]));
                }

                IEnumerable<IQuest> q = quest;
                return quests.Concat(q);
            }
            catch
            {
                return quests;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
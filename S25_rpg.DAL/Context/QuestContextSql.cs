using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using S25_rpg.Models.Interfaces;
using S25_rpg.Models.Interfaces.Quest;
using S25_rpg.Models.Models;

namespace S25_rpg.DAL.Context
{
    public class QuestContextSql : DatabaseConnection, IQuestContext
    {
        /// <summary>
        /// Function for editing information in the database based on a quest that is completed. This means it edits the completion of a quest for the character, removes items that have been used to complete the quest and adds items that have been given for completing the quest.
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <param name="quest"><see cref="IQuest"/></param>
        public void CompleteQuest(Character character, Quest quest)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand updateCharacterQuest = new MySqlCommand("UPDATE characterquest SET Completed=1 WHERE Character_id = @charid AND Quest_id = @questid", mySqlConnection);
                updateCharacterQuest.Parameters.AddWithValue("@charid", character.idCharacter);
                updateCharacterQuest.Parameters.AddWithValue("@questid", quest.Id);
                updateCharacterQuest.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        /// <summary>
        /// Function for getting all quests
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <returns><see cref="IEnumerable{IQuest}"/></returns>
        public IEnumerable<Quest> GetAllAccapteableQuests(Character character)
        {
            IEnumerable<Quest> quests = new List<Quest>();
            try
            {
                mySqlConnection.Open();

                //MySqlCommand getAllAcceptableQuests = new MySqlCommand("SELECT `quest`.*, `characterquest`.Completed, reward.Name, `clear`.Name FROM quest LEFT JOIN `characterquest` ON quest.Id = characterquest.Quest_id AND characterquest.Character_id = @id INNER JOIN `item` reward ON `quest`.RewardItem = reward.Id INNER JOIN `item` `clear` ON `quest`.ClearItem = `clear`.Id", mySqlConnection);
                MySqlCommand getAllAcceptableQuests = new MySqlCommand("GetAllAcceptableQuests", mySqlConnection);

                getAllAcceptableQuests.CommandType = CommandType.StoredProcedure;
                getAllAcceptableQuests.Parameters.AddWithValue("cID", character.idCharacter);

                MySqlDataReader reader = getAllAcceptableQuests.ExecuteReader();
                List<Quest> quest = new List<Quest>();
                while (reader.Read())
                {
                    quest.Add(new Quest((int) reader[0], (string) reader[1], (int) reader[2], (int)reader[3], (string) reader[10], (string) reader[4], (int) reader[5], (int) reader[6], (string) reader[11], (bool) reader[7], (int) reader[8], reader[9] as bool? ?? false));
                }

                IEnumerable<Quest> q = quest;
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

        /// <summary>
        /// Function for getting all quests that have been accepted by a character.
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <returns><see cref="IEnumerable{IQuest}"/></returns>
        public IEnumerable<Quest> GetAllAcceptedQuests(Character character)
        {
            IEnumerable<Quest> quests = new List<Quest>();
            try
            {
                mySqlConnection.Open();

                //MySqlCommand getAllAcceptedQuests = new MySqlCommand("SELECT quest.*, reward.Name, `clear`.Name FROM `quest` INNER JOIN `item` reward ON `quest`.RewardItem = reward.Id INNER JOIN `item` `clear` ON `quest`.ClearItem = `clear`.Id INNER JOIN `characterquest` ON quest.Id = characterquest.Quest_id WHERE characterquest.Character_id = @id AND characterquest.Completed = 0", mySqlConnection);
                MySqlCommand getAllAcceptedQuests = new MySqlCommand("GetAllAcceptedQuests", mySqlConnection);

                getAllAcceptedQuests.CommandType = CommandType.StoredProcedure;
                getAllAcceptedQuests.Parameters.AddWithValue("cID", character.idCharacter);

                MySqlDataReader reader = getAllAcceptedQuests.ExecuteReader();
                List<Quest> quest = new List<Quest>();
                while (reader.Read())
                {
                    quest.Add(new Quest((int)reader[0], (string)reader[1], (int)reader[2], (int)reader[3], (string)reader[9], (string)reader[4], (int)reader[5], (int)reader[6], (string)reader[10], (bool)reader[7], (int)reader[8]));
                }

                IEnumerable<Quest> q = quest;
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

        /// <summary>
        /// Function for adding a quest to a character or updating the quest to uncompleted.
        /// </summary>
        /// <param name="character"><see cref="ICharacter"/></param>
        /// <param name="quest"><see cref="IQuest"/></param>
        public void StartQuest(Character character, Quest quest)
        {
            try
            {
                mySqlConnection.Open();
                //MySqlCommand insertCharacterQuest = new MySqlCommand("INSERT INTO characterquest (Character_id, Quest_id, Completed) VALUES (@charid, @questid, 0) ON DUPLICATE KEY UPDATE Completed = 0", mySqlConnection);
                MySqlCommand insertCharacterQuest = new MySqlCommand("StartQuest", mySqlConnection);

                insertCharacterQuest.CommandType = CommandType.StoredProcedure;
                insertCharacterQuest.Parameters.AddWithValue("cID", character.idCharacter);
                insertCharacterQuest.Parameters.AddWithValue("qID", quest.Id);

                insertCharacterQuest.ExecuteNonQuery();
            }
            catch
            {
                
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}

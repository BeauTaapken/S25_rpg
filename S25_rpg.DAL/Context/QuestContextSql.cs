using System;
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
        public void CompleteQuest(ICharacter character, IQuest quest)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand updateCharacterQuest = new MySqlCommand("UPDATE characterquest SET Completed=1 WHERE Character_id = @charid AND Quest_id = @questid", mySqlConnection);
                updateCharacterQuest.Parameters.AddWithValue("@charid", character.idCharacter);
                updateCharacterQuest.Parameters.AddWithValue("@questid", quest.Id);
                updateCharacterQuest.ExecuteNonQuery();

                MySqlCommand RemoveQuestItems = new MySqlCommand("UPDATE characteritem SET Ammount = Ammount - @gottenAmmount WHERE Item_id = @itemid && Character_id = @charid", mySqlConnection);
                //TODO change ammount and itemid values in razor
                RemoveQuestItems.Parameters.AddWithValue("@gottenammount", quest.ClearAmmount);
                RemoveQuestItems.Parameters.AddWithValue("@itemid", quest.ClearItemId);
                RemoveQuestItems.Parameters.AddWithValue("@charid", character.idCharacter);
                RemoveQuestItems.ExecuteNonQuery();

                MySqlCommand AddQuestItems = new MySqlCommand("INSERT INTO `characteritem` (Character_id, Item_id, Ammount) VALUES (@charid, @itemid, @gottenItems) ON DUPLICATE KEY UPDATE Ammount = Ammount + @gottenItems", mySqlConnection);
                AddQuestItems.Parameters.AddWithValue("@charid", character.idCharacter);
                AddQuestItems.Parameters.AddWithValue("@itemid", quest.RewardItemId);
                AddQuestItems.Parameters.AddWithValue("@gottenItems", quest.RewardAmmount);
                AddQuestItems.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public IEnumerable<IQuest> GetAllAccapteableQuests(ICharacter character)
        {
            IEnumerable<IQuest> quests = new List<IQuest>();
            try
            {
                mySqlConnection.Open();

                MySqlCommand getAllAcceptableQuests = new MySqlCommand("SELECT `quest`.*, `characterquest`.Completed, reward.Name, `clear`.Name FROM quest LEFT JOIN `characterquest` ON quest.Id = characterquest.Quest_id AND characterquest.Character_id = @id INNER JOIN `item` reward ON `quest`.RewardItem = reward.Id INNER JOIN `item` `clear` ON `quest`.ClearItem = `clear`.Id", mySqlConnection);
                getAllAcceptableQuests.Parameters.AddWithValue("@id", character.idCharacter);
                MySqlDataReader reader = getAllAcceptableQuests.ExecuteReader();
                List<IQuest> quest = new List<IQuest>();
                while (reader.Read())
                {
                    quest.Add(new Quest((int) reader[0], (string) reader[1], (int) reader[2], (int)reader[3], (string) reader[10], (string) reader[4], (int) reader[5], (int) reader[6], (string) reader[11], (bool) reader[7], (int) reader[8], reader[9] as bool? ?? false));
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

                MySqlCommand getAllAcceptedQuests = new MySqlCommand("SELECT quest.*, reward.Name, `clear`.Name FROM `quest` INNER JOIN `item` reward ON `quest`.RewardItem = reward.Id INNER JOIN `item` `clear` ON `quest`.ClearItem = `clear`.Id INNER JOIN `characterquest` ON quest.Id = characterquest.Quest_id WHERE characterquest.Character_id = @characterid AND characterquest.Completed = 0", mySqlConnection);
                getAllAcceptedQuests.Parameters.AddWithValue("@characterid", character.idCharacter);
                MySqlDataReader reader = getAllAcceptedQuests.ExecuteReader();
                List<IQuest> quest = new List<IQuest>();
                while (reader.Read())
                {
                    quest.Add(new Quest((int)reader[0], (string)reader[1], (int)reader[2], (int)reader[3], (string)reader[9], (string)reader[4], (int)reader[5], (int)reader[6], (string)reader[10], (bool)reader[7], (int)reader[8]));
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

        public void StartQuest(ICharacter character, IQuest quest)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand insertCharacterQuest = new MySqlCommand("INSERT INTO characterquest (Character_id, Quest_id, Completed) VALUES (@charid, @questid, 0) ON DUPLICATE KEY UPDATE Completed = 0", mySqlConnection);
                insertCharacterQuest.Parameters.AddWithValue("@charid", character.idCharacter);
                insertCharacterQuest.Parameters.AddWithValue("@questid", quest.Id);
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

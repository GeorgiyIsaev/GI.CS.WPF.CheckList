using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList
{
    public static class QuestsBox
    {		
		public static ObservableCollection<QuestItem> questItems = new ObservableCollection<QuestItem>();

		public static void DeleteOneQuest()
        {
            if (questItems.Count > 0)
                questItems.RemoveAt(0);
        }
        public static void AddOneQuest() //QuestsBox.AddOneQuest() DeleteOneQuest()
        {
            /*Нулевой эл-т для новых вопросов*/
            QuestItem questItem = new QuestItem();
            questItem.quest = "<Добавить новый вопрос>";
            questItems.Add(questItem);         
        }

        /*Метод для вычитвания вопросов из базы в главный список*/
        public static void ReadQuestDB(DataBase.Tables.Test testItemDB)
        {

            foreach (var questItemDB in testItemDB.Quests)
            {
                QuestItem questItem = new QuestItem();
                questItem.SetQuestDB(questItemDB);
                questItems.Add(questItem);
            }
        }
        /*Добавляет новый вопрос в коробку и базу одновременно*/
        public static void AddQuestToDBAndQuestBox(DataBase.Tables.Quest questItemDB)
        {
            /*Если есть контакт с базой*/
            if (ProfBox.testCurrent != null)
                questItemDB = ProfBox.AddQuestToDB(questItemDB);

            QuestItem questItem = new QuestItem();
            questItem.SetQuestDB(questItemDB);
            questItems.Add(questItem);
        }


    }
}

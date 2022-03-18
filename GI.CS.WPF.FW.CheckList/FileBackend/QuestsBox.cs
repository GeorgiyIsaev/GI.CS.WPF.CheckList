using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;


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
    }
}

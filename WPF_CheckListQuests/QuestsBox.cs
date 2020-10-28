﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace WPF_CheckListQuests
{
    public static class QuestsBox
    {

		//ObservableCollection;
		//public static ObservableCollection
		public static ObservableCollection<QuestItem> questItems = new ObservableCollection<QuestItem>();
        public static bool if_ThereQuest(string str)
        {
           foreach (QuestItem tmp in questItems)
           {
                if (tmp.quest == str) return true;
           }
            return false;
        }
		public static void file_saveTXT(string nameFile)
		{
			/*Запись вопросов в блокнот*/
			using (var file = new StreamWriter(nameFile))
			{				
				foreach(QuestItem tmp in questItems)
                {					
					file.WriteLine($"ВОПРОС: {tmp.quest}");
					foreach (Answer tmpAnswer in tmp.answerItem)
					{
						if(tmpAnswer.if_true)
							file.WriteLine($"ВЕРНО: {tmpAnswer.answerSTR}");
						else
							file.WriteLine($"НЕ ВЕРНО: {tmpAnswer.answerSTR}");
					}
					file.WriteLine($"ВОПРОС: {tmp.comment}");
				}	
			}	
		}
		public static void file_readTXT(string nameFile)
		{			
			string fullLine;
			/*Чтение вопросов из блокнота*/
			using (var file = new StreamReader(nameFile, Encoding.Unicode))
			{
				fullLine = file.ReadToEnd();				
			}
			parsing_quest(fullLine);
		}
		private static void parsing_quest(string str)
        {
			string[] lineItem = str.Split("\n");			
			QuestItem questItem = null;

			foreach(string line in lineItem)
            {
				try
				{
					if (line.IndexOf("ВОПРОС:") >= 0)
					{
						if (questItem != null) { questItem.EndlForSpase(); questItems.Add(questItem); }
						questItem = new QuestItem();
						questItem.quest = line.Substring(line.LastIndexOf("ВОПРОС: "));
					}
					else if (line.IndexOf("ВЕРНО:") == 0)
					{
						Answer temp = new Answer(line.Substring(7), true);
						questItem.answerItem.Add(temp);
					}
					else if (line.IndexOf("НЕ ВЕРНО:") == 0)
					{
						Answer temp = new Answer(line.Substring(10), false);
						questItem.answerItem.Add(temp);
					}
					else if (line.IndexOf("КОММЕНТАРИЙ:") == 0)
					{
						questItem.comment = line.Substring(13);
					}
				}
				catch (Exception e)
				{
					System.Windows.MessageBox.Show(e.ToString());
					/*Просто игнорируем*/
				}
            }
			
		}
	}
}

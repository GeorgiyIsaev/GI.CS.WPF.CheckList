using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Xps.Serialization;


namespace WPF_CheckListQuests
{
    public static class QuestsBox
    {
		/*Для тулбокса*/
		//private static ObservableCollection<QuestItem> _models = new ObservableCollection<QuestItem>();
		//public static ObservableCollection<QuestItem> Models
		//{
		//	get { return _models; }
		//	set { _models = value; }
		//}


		//ObservableCollection;
		//public static ObservableCollection
		public static ObservableCollection<QuestItem> questItems = new ObservableCollection<QuestItem>();
		public static bool if_ThereQuest(string str)
		{
			while (true)
			{
				str = str.Replace("\r", " ");
				str = str.Replace("\n", " ");
				if (!str.Contains("\n")) break;
			}
			foreach (QuestItem tmp in questItems)
			{
				if (tmp.quest == str) return true;
			}
			return false;
		}
		public static void file_saveTXT(string nameFile)
		{
			/*Запись вопросов в блакнот*/
			using (var file = new StreamWriter(nameFile, false, Encoding.UTF8))
			{
				int count = 0;
				foreach(QuestItem tmp in questItems)
                {
					if (count == 0) { count++; continue; }// Пропуск вопроса настройки
					file.WriteLine($"ВОПРОС: {tmp.quest}");
					foreach (Answer tmpAnswer in tmp.answerItem)
					{
						if(tmpAnswer.if_true)
							file.WriteLine($"ВЕРНО: {tmpAnswer.answerSTR}");
						else
							file.WriteLine($"НЕ ВЕРНО: {tmpAnswer.answerSTR}");
					}
					file.WriteLine($"КОММЕНТАРИЙ: {tmp.comment}");
					//count++;
				}	
			}	
		}
		public static int file_readTXT(string nameFile)
		{			
			string fullLine;
			/*Чтение вопросов из блокнота*/

			if (!System.IO.File.Exists(nameFile))
            {
				return 0;
            }

			using (var file = new StreamReader(nameFile, Encoding.Unicode))
			{
				fullLine = file.ReadToEnd();				
			}
			return parsing_quest(fullLine);
		}
		private static int parsing_quest(string str)
        {
			string[] separator = { "\n", "\r" };
			string[] lineItem = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			QuestItem questItem = null;
			int count = 0;

			foreach(string line in lineItem)
            {
				try
				{
					//	string line = _line.Replace("\n", "");
					//line = line.Replace("\r", "");

					if (line.IndexOf("ВОПРОС:") >= 0)
					{
						if (questItem != null) { 
							questItem.EndlForSpase();
							if (!if_ThereQuest(questItem.quest)) { 
								questItem.Description = questItem.ToolTypeListBox();
								questItems.Add(questItem);							
								count++;	
							}												
						}
						questItem = new QuestItem();					
						questItem.quest = line.Substring(line.LastIndexOf("ВОПРОС: ")+8);
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
			if (questItem != null) { 
				questItem.EndlForSpase();
				if (!if_ThereQuest(questItem.quest))
				{
					questItem.Description = questItem.ToolTypeListBox();
					questItems.Add(questItem);
					count++;
				}
			}
			return count;			
		}
	}
}

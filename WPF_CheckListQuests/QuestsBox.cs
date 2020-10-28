using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPF_CheckListQuests
{
    public static class QuestsBox
    {
        public static List<QuestItem> questItems = new List<QuestItem>();
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
			QuestItem questItem = null;
			string line;
			/*Чтение вопросов из блокнота*/
			using (var file = new StreamReader(nameFile, Encoding.Unicode))
			{
				while ((line = file.ReadLine()) != null)
				{
					try
					{
						line = file.ReadLine();
						if (line.IndexOf("ВОПРОС:") == 0)
						{
							if (questItem != null) questItems.Add(questItem);
							questItem = new QuestItem();
							questItem.quest = line.Substring(8);
						}
						if (line.IndexOf("ВЕРНО:") == 0)
						{
							Answer temp = new Answer(line.Substring(7), true);
							questItem.answerItem.Add(temp);
						}
						if (line.IndexOf("НЕ ВЕРНО:") == 0)
						{
							Answer temp = new Answer(line.Substring(10), false);
							questItem.answerItem.Add(temp);
						}
						if (line.IndexOf("КОММЕНТАРИЙ:") == 0)
						{
							questItem.comment = line.Substring(13);
						}
					}
                    catch { /*Просто игнорируем*/ }
				}		
			}


		}

	}
}

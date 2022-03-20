using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList
{
	public static class EditionTXT
    {
		public static bool if_ThereQuest(string str)
		{
			while (true)
			{
				str = str.Replace("\r", " ");
				str = str.Replace("\n", " ");
				if (!str.Contains("\n")) break;
			}
			foreach (QuestItem tmp in QuestsBox.questItems)
			{
				if (tmp.quest == str) return true;
			}
			return false;
		}
		public static void WriteInTXT(string nameFile)
		{
			/*Запись вопросов в блакнот*/
			using (var file = new StreamWriter(nameFile, false, Encoding.Unicode))
			{
				int count = 0;
				foreach (QuestItem tmp in QuestsBox.questItems)
				{
					if (count == 0) { count++; continue; }// Пропуск вопроса настройки
					file.WriteLine($"ВОПРОС: {tmp.quest}");
					foreach (Answer tmpAnswer in tmp.answerItem)
					{
						tmpAnswer.answerSTR.ToString();
						if (tmpAnswer.isTrue)
							file.WriteLine($"ВЕРНО: {tmpAnswer.answerSTR}");
						else
							file.WriteLine($"НЕ ВЕРНО: {tmpAnswer.answerSTR}");
					}
					if(tmp.comment != "")
						file.WriteLine($"КОММЕНТАРИЙ: {tmp.comment}");
					file.WriteLine("");
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



            DataBase.Tables.Quest questItemDB = null; //объект для хранения
			int cursorLine = -1; //курсор строки -1 нет, 1 вопрос, 2 коментарий
			int countAddQuest = 0; //колличество добавленных вопросов

			try
			{
				foreach (string line in lineItem)
				{
					/*Если это вопрос но у нас уже есть объект то сохраняем*/
					if (line.IndexOf("ВОПРОС:") >= 0 && questItemDB != null)
					{
						countAddQuest++;
						QuestsBox.AddQuestToDBAndQuestBox(questItemDB);
						questItemDB = null;
						cursorLine = -1;
					}

					/*Если это вопрос но объекта нет*/
					if (line.IndexOf("ВЕРНО:") == 0)
					{
						questItemDB.Answers.Add(new DataBase.Tables.Answer() { TextAnswer = line, isTrue = true });
						cursorLine = -1;
					}
					else if (line.IndexOf("НЕ ВЕРНО:") == 0)
					{
						questItemDB.Answers.Add(new DataBase.Tables.Answer() { TextAnswer = line, isTrue = false });
						cursorLine = -1;
					}
					else if (cursorLine == 2 || line.IndexOf("КОММЕНТАРИЙ:") == 0)
					{
                        if (cursorLine == 2)
                            questItemDB.TextComment += "\n" + line;
                        else
                        {
                            cursorLine = 2;
                            questItemDB.TextComment = line.Substring(13);
                        }
                    }
					else if (cursorLine == 1 || line.IndexOf("ВОПРОС:") >= 0)
					{						
                        if (cursorLine == 1)
                            questItemDB.TextQuest += "\n" + line;
						else
						{
							questItemDB = new DataBase.Tables.Quest();
							cursorLine = 1;
                            questItemDB.TextQuest = line.Substring(line.LastIndexOf("ВОПРОС: ") + 8);
                        }

                    }
				
				}

				/*Заглушка для добавления последнего вопроса*/
				if (questItemDB != null)
				{
					countAddQuest++;
					QuestsBox.AddQuestToDBAndQuestBox(questItemDB);
				}
			}
			catch (Exception e){System.Windows.MessageBox.Show(e.ToString());}	
			return countAddQuest;
		}





	}
}

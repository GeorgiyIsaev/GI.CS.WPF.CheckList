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
		private static int parsing_quest2222(string str)
		{
			string[] separator = { "\n", "\r" };
			string[] lineItem = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			QuestItem questItem = null;
			int count = 0;


			int cursorLine = -1; //курсор строки -1 нет, 1 вопрос, 2 коментарий

			foreach (string line in lineItem)
			{
				try
				{
					if (cursorLine == 1 || line.IndexOf("ВОПРОС:") >= 0)
					{
						if (questItem != null && line.IndexOf("ВОПРОС:") >= 0) 
						{
							//questItem.EndlForSpase();
							if (!if_ThereQuest(questItem.quest))
							{
								questItem.Description = questItem.ToolTypeListBox();
								QuestsBox.questItems.Add(questItem);
								count++;
							}
						}
						questItem = new QuestItem();
						questItem.quest += line.Substring(line.LastIndexOf("ВОПРОС: ") + 8);
						cursorLine = 1;
					}
					else if (line.IndexOf("ВЕРНО:") == 0)
					{
						Answer temp = new Answer(line.Substring(7), true);
						questItem.answerItem.Add(temp);
						cursorLine = -1;
					}
					else if (line.IndexOf("НЕ ВЕРНО:") == 0)
					{
						Answer temp = new Answer(line.Substring(10), false);
						questItem.answerItem.Add(temp);
						cursorLine = -1;
					}
					else if (cursorLine == 2 || line.IndexOf("КОММЕНТАРИЙ:") == 0)
					{
						questItem.comment += line.Substring(13);
						cursorLine = 2;
					}
				}
				catch (Exception e)
				{
					System.Windows.MessageBox.Show(e.ToString());
					/*Просто игнорируем*/
				}
			}
			if (questItem != null)
			{
				questItem.EndlForSpase();
				if (!if_ThereQuest(questItem.quest))
				{
					questItem.Description = questItem.ToolTypeListBox();
					QuestsBox.questItems.Add(questItem);
					count++;
				}
			}
			return count;
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
						//метод для сохранения вопроса
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
					else if (cursorLine == 1 || line.IndexOf("ВОПРОС:") >= 0)
					{
						questItemDB = new DataBase.Tables.Quest();
						if (cursorLine != 1)
						{
							cursorLine = 1;
							questItemDB.TextQuest = line.Substring(line.LastIndexOf("ВОПРОС: ") + 8);
						}
						else
							questItemDB.TextQuest += line;

					}
					else if (cursorLine == 2 || line.IndexOf("КОММЕНТАРИЙ:") == 0)
					{
						if (cursorLine != 2)
						{
							cursorLine = 2;
							questItemDB.TextQuest = line.Substring(13);
						}
						else
							questItemDB.TextQuest += line;
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

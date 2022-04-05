using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GI.CS.WPF.FW.CheckList
{
	public static class EditionHTML
	{
		/*Основные теги контейнеров*/
		public static string headerHTML { get; set; }
		public static string describeHTML { get; set; }
		public static string signFooterHTML { get; set; }
		//public static int FrontSiseBody { get; set; }
		public static bool deleteAnAnswerIf { get; set; }
		public static bool spoilerIf { get; set; }

		/*СSS - Выставить настройки по умолчанию*/
		public static StructCCS structCCS;
		public static void DefaultCSS()
		{
			structCCS.baseBackend.color = "#c4d0c7";
			structCCS.mainBackend.color = "#ffffff";
			structCCS.futterBackend.color = "#a9a9a9";

			structCCS.title.CreateCSS(26, false, false, false, "#520000");
			structCCS.description.CreateCSS(16, true, false, false, "#520000");
			structCCS.question.CreateCSS(16, false, false, false, "#520000");
			structCCS.trueAanswer.CreateCSS(16, false, false, false, "#520000");
			structCCS.falseAnswer.CreateCSS(16, false, false, false, "#520000");
			structCCS.trueAanswerIcon.CreateCSS(18, false, true, false, "#1eaf1e");
			structCCS.falseAanswerIcon.CreateCSS(18, false, true, false, "#ff0000");
			structCCS.comment.CreateCSS(16, false, false, false, "#520000");
			structCCS.signature.CreateCSS(10, true, true, false, "#520000");
		}

		public static void ChangeFullFontSize(int sizeFont)
        {
			structCCS.title.ChangeSizeFont(sizeFont+10);
			structCCS.description.ChangeSizeFont(sizeFont);
			structCCS.question.ChangeSizeFont(sizeFont);
			structCCS.trueAanswer.ChangeSizeFont(sizeFont);
			structCCS.falseAnswer.ChangeSizeFont(sizeFont);
			structCCS.trueAanswerIcon.ChangeSizeFont(sizeFont+2);
			structCCS.falseAanswerIcon.ChangeSizeFont(sizeFont+2);
			structCCS.comment.ChangeSizeFont(sizeFont);
			structCCS.signature.ChangeSizeFont(sizeFont-6);
		}






		/*Построение HTML кода из списка вопросов*/
		public static string bilderHTMLCode()
		{
			StringBuilder htmlCodeStr = new StringBuilder();

			htmlCodeStr.Append(headBilder() + "\n");
			htmlCodeStr.Append("<body><main>" + "\n");
			htmlCodeStr.Append(h1Bilder() + "\n");
			int count = 0;
			foreach (QuestItem tmp in QuestsBox.questItems)
			{
				/*Пропеуск первого эл-та*/
				if (count == 0)
				{
					count++; continue;
				}
				htmlCodeStr.Append("<div class=\"questBox\">");
				htmlCodeStr.Append($"<div class=\"questBox__quest\">{count++}) {AddTegBR(tmp.quest)}\n</div>");

				foreach (Answer tmpAnswer in tmp.answerItem)
				{
					if (tmpAnswer.isTrue)
						htmlCodeStr.Append($"<div class=\"questBox__answer\"><div> &#10004;</div>{tmpAnswer.answerSTR}\n</div>\n");
					else
						htmlCodeStr.Append($"<div class=\"questBox__unanwser\"><div> &#10008;</div>{tmpAnswer.answerSTR}\n</div>\n");
				}
				if (tmp.comment!=null && tmp.comment.Length > 0)
				{
					htmlCodeStr.Append($"<div class=\"questBox__coment\"><details {spoilerOpen()}>\n<summary>ПОЯСНЕНИЕ:</summary><div>{AddTegBR(tmp.comment)}\n</div></details></div>");
				}
				htmlCodeStr.Append($"</div>");
			}
			htmlCodeStr.Append("<div class=\"questBox\"><p></p></div>");
			htmlCodeStr.Append(footerBilder());
			htmlCodeStr.Append("</body>\n</html>");
			return htmlCodeStr.ToString();
		}
		/*Добавление и Удаление BR*/
		private static string AddTegBR(string textFormat)
		{
			while (textFormat.Contains("\n"))
				textFormat = textFormat.Replace("\n", "<br>");
			return textFormat;
		}
		private static string DeleteTegBR(string textFormat)
		{
			while (textFormat.Contains("<br>"))
				textFormat = textFormat.Replace("<br>", "\n");
			return textFormat;
		}


		/*Проверка на наличе спойлера у коментария*/
		private static string spoilerOpen()
		{
			if (!spoilerIf) return "open";
			return "";
		}

		/*Формирование тегов*/
		private static string headBilder()
		{
			string head = @"<!DOCTYPE html>" + "\n" +
			$"<html><head><title> {headerHTML} </title>" + "\n" +
			"<meta charset = \"utf-8\">" + "\n" +
			"<style>html, body{margin: 0;padding: 0;font-family: Arial;	background-color: " + structCCS.baseBackend.color + "; text-align: justify;font-size: " + structCCS.comment.SizeFront + "px;}" + "\n" +
			"h1{" + structCCS.title.FullStringCss + " ; margin: 0px 0 15px; text-align: center;}" + "\n" +
			"#opisanie{" + structCCS.description.FullStringCss + ";padding: 0 110px 10px;}" + "\n" +
			".questBox{max-width: 1000px; min-width: 320px; padding: 20px 20px 12px;margin: 0 auto;	position: relative;background-color: " + structCCS.mainBackend.color + ";}	" + "\n" +
			".questBox__coment details div{" + structCCS.comment.FullStringCss + " padding: 5px 15px 0px; }" + "\n" +
			".questBox__coment{padding: 5px 25px 0px;}" + "\n" +

			".questBox__quest{padding: 0px 25px 5px;" + structCCS.question.FullStringCss + "} \n" +
			".questBox__answer {" + structCCS.trueAanswer.FullStringCss + "padding: 0px 60px 0px; }" + "\n" +
			".questBox__unanwser{" + structCCS.falseAnswer.FullStringCss + "padding: 0px 60px 0px; }" + "\n" +
			".questBox__answer div{" + structCCS.trueAanswerIcon.FullStringCss + "  display: inline; }" + "\n" +
			".questBox__unanwser div{" + structCCS.falseAanswerIcon.FullStringCss + "display: inline; }" + "\n" +
			"html {height: 100%}" + "\n" +
			"body {min-height: 100%; display: grid; grid-template-rows:1fr auto;}" + "\n" +
			"main {min-width: 1000px;  background-color: " + structCCS.mainBackend.color + "; margin: 0 auto;}" + "\n" +
			"#text-footer {padding-top: 25px}" + "\n" +
			"#footer {" + structCCS.signature.FullStringCss + " padding: 0 0 0 12px; text-align: center; height: 65px; background-color: " + structCCS.futterBackend.color + ";}" + "\n" +
			"@media screen and (max-width: 820px) {main {min-width: 820px;}} " + "\n" +
			"@media screen and (max-width: 660px) {main {min-width: 660px;}} " + "\n" +
			"@media screen and (max-width: 500px) {main {min-width: 500px;}} " + "\n" +
			"</style></head>";
			return head;
		}
		private static string h1Bilder()
		{
			return $"<div><div class=\"questBox\"><h1>{headerHTML}</h1>" + "\n" +
			$"<div id= \"opisanie\" > {describeHTML} </div></div></div> ";
		}
		private static string footerBilder()
		{
			string newCSS = "";
			if(signFooterHTML.Length > 0)
            {
				newCSS = "style=\"height: 80px;\"";
			}	
			return $"</main><div id=\"footer\" {newCSS}><div id=\"text-footer\"><div>Чек-лист собран в приложении \"Верстальщик чек-листов v.1.0\" by Georgiyelbaf</div>" + "\n" + sign() +
			$"<div> Дата и время сборки: {DateTime.Now}</div></div></div> ";
		}
		private static string sign()
		{
			if (signFooterHTML != "")
			{
				return $"<div>Оператор-сборщик: {signFooterHTML}</div>" + "\n";
			}
			return "";
		}





		/*Запись HTML coda в файл */
		public static void WriteHTmlCodeToFile(string nameFile)
		{
			using (var file = new StreamWriter(nameFile, false, Encoding.UTF8))
			{
				file.WriteLine(bilderHTMLCode());
			}
		}

		/*Чтение HTML файла - возвращает кол-вопросов*/
		public static int readHTML(string nameFile)
		{
			string fullLine;
			/*Чтение всего текста со страницы*/
			using (var file = new StreamReader(nameFile, Encoding.Unicode))
			{
				fullLine = file.ReadToEnd();
			}
			return HTMLParsingQuest(fullLine);
		}




		/*Парсинг результируеющей страницы - возвращает кол-во вопросов*/
		private static int HTMLParsingQuest(string str)
		{
			/*Сператоры тегов*/
			string questBegin = $"<div class=\"questBox__quest\">";
			string AnswerBegin = $"<div class=\"questBox__answer\"><div> &#10004;</div>";
			string UnAnswerBegin = $"<div class=\"questBox__unanwser\"><div> &#10008;</div>";
			string comentBegin = "<summary>ПОЯСНЕНИЕ:</summary><div>";


			/*Разделение файла на строки*/
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
                    if (line.IndexOf(questBegin) >= 0 && questItemDB != null)
                    {
                        countAddQuest++;

						questItemDB.TextQuest = DeleteTegBR(questItemDB.TextQuest);
						questItemDB.TextComment = DeleteTegBR(questItemDB.TextComment);

						QuestsBox.AddQuestToDBAndQuestBox(questItemDB);
                        questItemDB = null;
                        cursorLine = -1;
                    }

					/*Если это вопрос но объекта нет*/
			
					if (line.IndexOf(AnswerBegin) >= 0)
					{				
						questItemDB.Answers.Add(new DataBase.Tables.Answer() { TextAnswer = line.Remove(0, line.IndexOf(AnswerBegin) + AnswerBegin.Length), isTrue = true });
						cursorLine = -1;
					}
					else if (line.IndexOf(UnAnswerBegin) == 0)
					{
						questItemDB.Answers.Add(new DataBase.Tables.Answer() { TextAnswer = line.Replace(UnAnswerBegin, ""), isTrue = false });
						cursorLine = -1;
					}
					else if (cursorLine == 2 || line.IndexOf(comentBegin) == 0)
                    {
						if (cursorLine == 2)
							questItemDB.TextComment += DeleteTegBR(line);
						else
						{
							cursorLine = 2;
							questItemDB.TextComment = line.Replace(comentBegin, "");
						}		
                    }
					else if (cursorLine == 1 || line.IndexOf(questBegin) >= 0)
					{
						if (cursorLine == 1)
							questItemDB.TextQuest += DeleteTegBR(line);
						else
						{
							questItemDB = new DataBase.Tables.Quest();
							cursorLine = 1;

							questItemDB.TextQuest = line.Replace(questBegin, ""); //Удаление открывающего тега
						    questItemDB.TextQuest = questItemDB.TextQuest.Remove(0, questItemDB.TextQuest.IndexOf(')') + 2); // удаление номера вопроса							
						}
					}		
				}

				/*Заглушка для сохранения последнего вопроса*/
				if (questItemDB != null)
				{
					countAddQuest++;
					QuestsBox.AddQuestToDBAndQuestBox(questItemDB);				
					cursorLine = -1;
				}
			}
			catch (Exception e)
			{
				System.Windows.MessageBox.Show(e.ToString());
			}
			return countAddQuest;
		}
	}
}

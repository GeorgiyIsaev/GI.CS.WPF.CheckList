using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GI.CS.WPF.FW.CheckList
{
	public static class EditionHTML
	{
		/*Значение для установки СSS*/
		public static StructCCS structCCS;

		/*Основные настройки*/
		public static string headerHTML { get; set; }
		public static string describeHTML { get; set; }
		public static string signFooterHTML { get; set; }
		public static int FrontSiseBody { get; set; }
		public static bool deleteAnAnswerIf { get; set; }
		public static bool spoilerIf { get; set; }

		/*Настройки цветов*/


		/*Логика*/
		public static void bilderHTML(string nameFile)
		{			
			
			using (var file = new StreamWriter(nameFile, false, Encoding.UTF8))
			{
				file.WriteLine(headBilder());
				file.WriteLine("<body>");
				file.WriteLine(h1Bilder());	
				int count =0;
				foreach (QuestItem tmp in QuestsBox.questItems)
				{
					if (count == 0) {
						count++; continue; } // Пропуск вопроса настройки
					file.WriteLine("<div class=\"questBox\">");
					file.WriteLine($"<div class=\"questBox__quest\">{count++}) {tmp.quest}\n</div>");
										
					foreach (Answer tmpAnswer in tmp.answerItem)
					{
						if (tmpAnswer.if_true)
							file.WriteLine($"   <div class=\"questBox__answer\"><div> &#10004;</div>{tmpAnswer.answerSTR}\n</div>\n");
						else
							file.WriteLine($"   <div class=\"questBox__unanwser\"><div> &#10008;</div>{tmpAnswer.answerSTR}\n</div>\n");
					}
					if (tmp.comment.Length > 0)
					{
						file.WriteLine($"	<div class=\"questBox__coment\"><details {spoilerOpen()}>\n<summary>ПОЯСНЕНИЕ:</summary><div>{tmp.comment}\n</div></details>\n		</div>\n");
					} 
					file.WriteLine($"</div>\n");
				}
				file.WriteLine("<div class=\"questBox\"><p></p></div>");
				file.WriteLine(footerBilder());
				file.WriteLine("</body>\n</html>");
			}
		}
		private static string spoilerOpen()
        {
			if (!spoilerIf) return "open";
			return "";
		}


		
		
		public static void DefaultCSS()
		{
			structCCS.baseBackend.color = "#c4d0c7";
			structCCS.mainBackend.color = "#ffffff";
			structCCS.futterBackend.color = "#a9a9a9";

			structCCS.title.CreateCSS(26, false,false,false, "#520000");
			structCCS.description.CreateCSS(16, true, false, false, "#520000");
			structCCS.question.CreateCSS(16, false, false, false, "#520000");
			structCCS.trueAanswer.CreateCSS(16, false, true, false, "#520000");
			structCCS.falseAnswer.CreateCSS(16, false, false, true, "#520000");
			structCCS.trueAanswerIcon.CreateCSS(18, false, true, false, "#1eaf1e");
			structCCS.falseAanswerIcon.CreateCSS(18, false, true, false, "#ff0000");
			structCCS.comment.CreateCSS(16, false, false, false, "#520000");
			structCCS.signature.CreateCSS(10, true, true, false, "#520000");
		}
		private static string headBilder()
		{
			string head = @"<!DOCTYPE html>" + "\n" +
				$"<html><head><title> {headerHTML} </title>" + "\n" +
				"<meta charset = \"utf-8\">" + "\n" +
				"<style>html, body{margin: 0;padding: 0;font-family: Arial;	background-color: " + structCCS.baseBackend.color + "; text-align: justify;font-size: "+ FrontSiseBody + "px;}" + "\n" +
				"h1{" + structCCS.title.FullStringCss + " ;padding: 20px 0 27px 0px; margin: 0px 0 15px; text-align: center;}" + "\n" +
				"#opisanie{" + structCCS.description.FullStringCss + ";padding: 0 110px 10px;}" + "\n" +
				".questBox{max-width: 1000px; min-width: 320px; padding: 40px 20px 12px;margin: 0 auto;	position: relative;background-color: "+ structCCS.mainBackend.color + ";}	" + "\n" +
				".questBox__coment details div{" + structCCS.comment.FullStringCss + " padding: 5px 15px 0px; }" + "\n" +
				".questBox__coment{padding: 5px 25px 0px;}" + "\n" +

				".questBox__quest{padding: 0px 25px 5px;" + structCCS.question.FullStringCss + "} \n" +
				".questBox__answer {" + structCCS.trueAanswer.FullStringCss + "padding: 0px 60px 0px; }" + "\n" +
				".questBox__unanwser{" + structCCS.falseAnswer.FullStringCss + "padding: 0px 60px 0px; }" + "\n"+
				".questBox__answer div{" + structCCS.trueAanswerIcon.FullStringCss + "  display: inline; }" + "\n" +
				".questBox__unanwser div{" + structCCS.falseAanswerIcon.FullStringCss + "display: inline; }" + "\n" +
				"#footer {" + structCCS.signature.FullStringCss + " padding: 20px 0 27px 12px; text-align: center; background-color: " + structCCS.futterBackend.color + ";}" + "\n" +
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
			return $"<div id=footer><div><div>Чек-лист собран в приложении \"Верстальщик чек-листов v.0.8\" by Georgiyelbaf</div>" + "\n" + sign() +			
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

		public static int HTMLParsingQuest(string str)
		{
			/*Строковые метки*/
			string questBegin = $"<div class=\"questBox__quest\">";
			string questEnd = "</div>";
			string AnswerBegin = $"   <div class=\"questBox__answer\"><div> &#10004;</div>";
			string UnAnswerBegin = $"   <div class=\"questBox__unanwser\"><div> &#10008;</div>";
			string AnswerEnd= "</div>" + "\n";
			string comentBegin = "<summary>ПОЯСНЕНИЕ:</summary><div>";
			string comentEnd = "</div></details>";

			/*Старт*/
			string[] separator = { "\n", "\r" };
			string[] lineItem = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			QuestItem questItem = null;
			int count = 0;

			foreach (string line in lineItem)
			{
				string temp;
				try
				{
									
					if (line.IndexOf(questBegin) >= 0)
					{
						if (questItem != null && !EditionTXT.if_ThereQuest(questItem.quest))
						{
							questItem.Description = questItem.ToolTypeListBox(); QuestsBox.questItems.Add(questItem); count++;
						}
						questItem = new QuestItem();
						temp = line.Replace(questBegin, "");
						temp = temp.Replace(questEnd, "");					
						temp = temp.Remove(0, temp.IndexOf(')') + 2);
						questItem.quest =temp;
					}
					else if (line.IndexOf(AnswerBegin) == 0)
					{
						temp = line.Replace(AnswerBegin, "");
						temp = temp.Replace(AnswerEnd, "");
						Answer tempAns = new Answer(temp, true);
						questItem.answerItem.Add(tempAns);
					}
					else if (line.IndexOf(UnAnswerBegin) == 0)
					{
						temp = line.Replace(UnAnswerBegin, "");
						temp = temp.Replace(AnswerEnd, "");
						Answer tempAns = new Answer(temp, false);
						questItem.answerItem.Add(tempAns);
					}
					else if (line.IndexOf("КОММЕНТАРИЙ:") == 0)
					{
						temp = line.Replace(comentBegin, "");
						temp = temp.Replace(comentEnd, "");
						questItem.comment = temp;
					}
				}
				catch (Exception e)
				{
					System.Windows.MessageBox.Show(e.ToString());
					/*Просто игнорируем*/
				}
			}
			if (questItem != null && !EditionTXT.if_ThereQuest(questItem.quest))
			{			
				questItem.Description = questItem.ToolTypeListBox(); QuestsBox.questItems.Add(questItem); count++;				
			}
			return count;
		}		
	}
}

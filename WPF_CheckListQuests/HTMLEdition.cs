using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WPF_CheckListQuests
{
	public class HTMLEdition
	{
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
			
			nameFile += ".html";
			using (var file = new StreamWriter(nameFile))
			{
				file.WriteLine(headBilder());
				file.WriteLine("<body>");
				file.WriteLine(h1Bilder());	
				int count =0;
				foreach (QuestItem tmp in QuestsBox.questItems)
				{
					if (count == 0) { count++; continue; } // Пропуск вопроса настройки
					file.WriteLine("<div class=\"questBox\">");
					file.WriteLine($"<div class=\"questBox__quest\">{count++}) {tmp.quest}</div>");
										
					foreach (Answer tmpAnswer in tmp.answerItem)
					{
						if (tmpAnswer.if_true)
							file.WriteLine($"   <div class=\"questBox__answer\"><div> &#10004;</div> {tmpAnswer.answerSTR} </div>" + "\n");
						else
							file.WriteLine($"   <div class=\"questBox__unanwser\"><div> &#10008;</div> {tmpAnswer.answerSTR} </div>" + "\n");
					}
					if (tmp.comment != "")
					{
						file.WriteLine($"	<div class=\"questBox__coment\"><details {spoilerOpen()}><summary>ПОЯСНЕНИЕ:</summary><div>{tmp.comment}</div></details>\n		</div>\n");
					}
					file.WriteLine($"</div>");
				}
				file.WriteLine(footerBilder());
				file.WriteLine("</body>\n</html>");
			}
		}
		private static string spoilerOpen()
        {
			if (spoilerIf) return "open";
			return "";
		}


		private static string headBilder()
		{
			string head = @"<!DOCTYPE html>" + "\n" +
				$"<html><head><title> {headerHTML} </title>" + "\n" +
				"<meta charset = \"utf-8\">" + "\n" +
				"<style>html, body{margin: 0;padding: 0;font-family: Arial;	background-color: #c4d0c7;text-align: justify;font-size: "+ FrontSiseBody + "px;}" + "\n" +
				"h1{font-size: " + (FrontSiseBody + 8) + "px;padding: 20px 0 27px 0px;margin: 0px 0 15px;text-align: center;}" + "\n" +
				"#opisanie{font-size: " + (FrontSiseBody -1) + "px;padding: 0 110px 10px; font-style:italic;}		" + "\n" +
				".questBox{max-width: 1000px; min-width:  320px;padding: 40px 20px 12px;margin: 0 auto;	position: relative;background-color: #ffffff;}	" + "\n" +
				".questBox__coment details div{ padding: 5px 15px 0px;}" + "\n" +
				".questBox__coment{padding: 5px 25px 0px;}" + "\n" +

				".questBox__quest{padding: 0px 25px 5px;}" + "\n" + 
				".questBox__answer, .questBox__unanwser{padding: 0px 60px 0px;}" + "\n" + deleteUnAnswer() +
				".questBox__answer div{color: green;font-weight: bold;display: inline; }" + "\n" +
				".questBox__unanwser div{ color: red;font-weight: bold;display: inline; }" + "\n" +
				"#footer {	font-size: " + (FrontSiseBody - 1) + "px;	font-weight: bold;	font-style:italic; padding: 20px 0 27px 12px; text-align: center ;background-color: #a9a9a9;}" + "\n" +
				"</style></head>";
			return head;
		}

		private static string deleteUnAnswer()
        {
			if (deleteAnAnswerIf) return " .questBox__unanwser{ text-decoration: line-through; }" + "\n";
			return "";
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
	}
}

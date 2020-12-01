using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_CheckListQuests
{
	public class QuestItem
	{
		/*Части вопроса*/
		public string quest { get; set; } = "";
		public string comment { get; set; } = "";
		public List<Answer> answerItem = new List<Answer>();
		public int intRandomQuest { get; set; } = 0;
		public int countTrueAnswer{ get; set; } = 0;

		/*Логика работы вопроса*/
		/*Добавление верные и не верных ответов в лист*/
		public void InputAnswerList(string answer, string anAnswer)
        {		
			String[] answerMas = answer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
			String[] anAnswerMas = anAnswer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string tmp in answerMas)
            {
				Answer temp = new Answer(tmp, true);
				answerItem.Add(temp);
				countTrueAnswer++;
			}	
			foreach (string tmp in anAnswerMas)
			{
				Answer temp = new Answer(tmp, false);
				answerItem.Add(temp);
			}
			EndlForSpase();
		}
		public override string ToString()
		{
			string temp = quest;
			if (answerItem.Count != 0) temp += $" -- > ОТВЕТЫ: {answerItem.Count} шт.";
			//return quest;
			return temp;
		}
		public void EndlForSpase()
        {	
			while (true){
				quest = quest.Replace("\r", " ");
				quest = quest.Replace("\n", " "); 			
				if (!quest.Contains("\n")) break;
			}
			while (true){
				comment = comment.Replace("\r", " ");
				comment = comment.Replace("\n", " ");
				if (!comment.Contains("\n")) break;
			}
		}
		public string StrFullAnswer(bool if_answer = true)
        {
			StringBuilder tempSTR = new StringBuilder();
			foreach(Answer answer in answerItem)
            {
				if (answer.if_true == if_answer)
                {
					if(tempSTR.Length>1) tempSTR.Append("\n");
					tempSTR.Append(answer.answerSTR);		
				}
			}
			return tempSTR.ToString();
        }

		public void RandomGeneratorIt()
        {
			Random rnd = new Random();
			intRandomQuest = rnd.Next(0, 100);
			foreach (Answer tmpAnswer in answerItem)
			{
				tmpAnswer.RandomAnswerIt();
			}
			/*Перетасовать ответы*/
			answerItem.Sort((a,b)=> a.random_nomer.CompareTo(b.random_nomer));		
		}

	}    
}


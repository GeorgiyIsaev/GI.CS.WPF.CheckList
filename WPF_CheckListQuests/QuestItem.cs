using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_CheckListQuests
{
	public class QuestItem
	{
		/*Части вопроса*/
		public string quest { get; set; }
		public string comment { get; set; }
		public List<Answer> answerItem;

		/*Логика работы вопроса*/
		/*Добавление верные и не верных ответов в лист*/
		public void InputAnswerList(string answer, string anAnswer)
        {
			answerItem = new List<Answer>();
			String[] answerMas = answer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
			String[] anAnswerMas = anAnswer.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string tmp in answerMas)
            {
				Answer temp = new Answer(tmp, true);
				answerItem.Add(temp);
			}
			if(answerItem.Count < 1)
            {
				Answer temp = new Answer("Нет верного ответа", true);
				answerItem.Add(temp);
			}
			foreach (string tmp in anAnswerMas)
			{
				Answer temp = new Answer(tmp, false);
				answerItem.Add(temp);
			}
		}
        public override string ToString()
        {
			return $"{quest} --> {answerItem.Count} ответа.";
		}


    }    
}


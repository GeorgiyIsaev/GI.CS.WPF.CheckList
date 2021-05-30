using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_CheckListQuests
{
	public class Answer
	{
		public bool if_true { get; set; } // 1-Верный ответ, 0-Не верный ответ.
		public string answerSTR { get; set; }
		public int random_nomer { get; set; } = 0;	
		public Answer(string str, bool if_answer)
		{
			if_true = if_answer;
			answerSTR = str;			
		}
		public void RandomAnswerIt()
        {
			Random rnd = new Random();
			random_nomer = rnd.Next(0, 100);
		}
        public override string ToString()
        {
			answerSTR = answerSTR.Replace("\n", "");
			answerSTR = answerSTR.Replace("\r", "");
			return answerSTR;
        }

    };
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GI.CS.WPF.FW.CheckList
{
	public class Answer
	{
		public bool isTrue { get; set; } // 1-Верный ответ, 0-Не верный ответ.
		public string answerSTR { get; set; }
		[JsonIgnore]
		public int random_nomer { get; set; } = 0;
		public Answer(){}
		public Answer(string str, bool if_answer)
		{
			isTrue = if_answer;
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

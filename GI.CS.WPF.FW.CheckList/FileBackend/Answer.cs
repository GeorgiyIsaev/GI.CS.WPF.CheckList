using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GI.CS.WPF.FW.CheckList
{
	public static class RND{
		static Random rnd = new Random();
		public static int GetRandomInt()
		{
			return rnd.Next(0, 100);
		}
	}

	
	
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
			random_nomer = RND.GetRandomInt();
		}
        public override string ToString()
        {
			answerSTR = answerSTR.Replace("\n", "");
			answerSTR = answerSTR.Replace("\r", "");
			return answerSTR;
        }
    };




	/*Компараторы для сортивки ответов*/
	class AnswerComparerRND : IComparer<Answer>
	{
		public int Compare(Answer a1, Answer a2)
		{
			return a1.random_nomer - a2.random_nomer;
		}
	}

	class AnswerComparerTrue : IComparer<Answer>
	{
		public int Compare(Answer a1, Answer a2)
		{		
			if(a1.isTrue == a2.isTrue)
            {
				return a1.answerSTR.CompareTo(a2.answerSTR);
			}
			else if (a1.isTrue)
            {
				return 999999999;
            }
			else if (a1.isTrue)
			{
				return -999999999;
			}
			return 0;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_CheckListQuests
{
	public class Answer
	{
		public bool if_true { get; set; } // 1-Верный ответ, 0-Не верный ответ.
		public string answerSTR { get; set; }
		public int random_nomer { get; set; } //генерация номера для рандомного порядка ответов
		public Answer()
		{
		    ///TODO При создании ответа должно генерироватся случайный номер
			random_nomer = 100;
		}
		public Answer(string str, bool if_answer)
		{
			if_true = if_answer;
			answerSTR = str;
			///TODO При создании ответа должно генерироватся случайный номер
			random_nomer = 100;
		}

	};
}

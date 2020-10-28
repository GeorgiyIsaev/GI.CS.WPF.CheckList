using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPF_CheckListQuests
{
    public static class QuestsBox
    {
        public static List<QuestItem> questItem = new List<QuestItem>();
        public static bool if_ThereQuest(string str)
        {
           foreach (QuestItem tmp in questItem)
           {
                if (tmp.quest == str) return true;
           }
            return false;
        }
		public static void file_saveTXT(string nameFile)
		{
			/*Запись вопроса в блокнот*/
			using (var file = new StreamWriter(nameFile))
			{
				foreach(QuestItem tmp in questItem)
                {
					file.WriteLine($"ВОПРОС: {tmp.quest}");
					foreach (Answer tmpAnswer in tmp.answerItem)
					{
						if(tmpAnswer.if_true)
							file.WriteLine($"ВЕРНО: {tmpAnswer.answerSTR}");
						else
							file.WriteLine($"НЕ ВЕРНО: {tmpAnswer.answerSTR}");
					}
					file.WriteLine($"ВОПРОС: {tmp.comment}");
				}	
			}	




			
		}


	}
}

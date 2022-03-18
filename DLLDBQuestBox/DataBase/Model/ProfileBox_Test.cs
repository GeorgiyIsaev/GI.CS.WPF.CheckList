using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public static partial class ProfileBox
    {
        public static DataBase.Tables.Test testCurrent;
        public static void EndTest() { testCurrent = null; }
        public static void TestRefresh(long id)
        {
            if (profile == null) return;
            profile.Refresh();
            foreach (var testIt in profile.Tests)
            {
                if(testIt.Id == id)
                {
                    testCurrent = testIt;
                    break;
                }
            }

        }

        private static DataBase.Tables.Quest newQuestCreate (string questText,
            string commentText, string answerListText, string anAnswerListText)
        {
            DataBase.Tables.Quest questDB = new Tables.Quest();
            questDB.TextQuest = questText;
            questDB.TextComment = commentText;

            String[] answerMas = answerListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            String[] anAnswerMas = anAnswerListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string text in answerMas)
            {
                questDB.Answers.Add(new Tables.Answer() { TextAnswer = text, isTrue = true, Quest= questDB });
            }
            foreach (string text in anAnswerMas)
            {
                questDB.Answers.Add(new Tables.Answer() { TextAnswer = text, isTrue = false, Quest = questDB });
            }
            return questDB;
        }

    }
}

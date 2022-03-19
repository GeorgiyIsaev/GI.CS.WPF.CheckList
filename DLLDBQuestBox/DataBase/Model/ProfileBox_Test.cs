using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /*Создает объект с вопросом но не записывает его в базу*/
        public static DataBase.Tables.Quest CreateNewTest (string questText,
            string commentText, string answerListText, string anAnswerListText)
        {
            DataBase.Tables.Quest questDB = new Tables.Quest();
            questDB.TextQuest = questText;
            questDB.TextComment = commentText;

            String[] answerMas = answerListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            String[] anAnswerMas = anAnswerListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string text in answerMas)
            {
                questDB.Answers.Add(new Tables.Answer() { TextAnswer = text, isTrue = true, /*Quest= questDB*/ });
            }
            foreach (string text in anAnswerMas)
            {
                questDB.Answers.Add(new Tables.Answer() { TextAnswer = text, isTrue = false, /*Quest = questDB*/ });
            }                 
            return questDB;
        }

        /*Записывает объект с вопросом в базу и возвращает объект уже из базы*/
        public static DataBase.Tables.Quest AddQuestToDB(DataBase.Tables.Quest questDB)
        {
            //DataBase.Tables.Quest quest
            if (testCurrent == null) throw new Exception("Нет соединения с тестом БД");
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                   
                    cont.Tests.Find(testCurrent.Id).Quests.Add(questDB);
                    cont.SaveChanges();

                   // questDB = cont.Quests.Where(x => x.TestId == testCurrent.Id).LastOrDefault(); //вернуть последний эл-т очереди

                    //  var questDB1 = cont.Quests.Last();
                    //   int a = 1;
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
           // return questDB;
            testCurrent.Refresh();
            var q = testCurrent.Quests.Last();
            return q;
        }

        /*Перезапись квеста в базе данныъ*/
        public static DataBase.Tables.Quest ReplacementQuestBD(DataBase.Tables.Quest questDBbefore,
            DataBase.Tables.Quest questDBbecame)
        {
      
            //DataBase.Tables.Quest quest
            if (testCurrent == null) throw new Exception("Нет соединения с тестом БД");
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    cont.Quests.Attach(questDBbefore);
                    cont.Quests.Remove(questDBbefore);
                    cont.SaveChanges();

                    cont.Tests.Find(testCurrent.Id).Quests.Add(questDBbecame);
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            // return questDB;
            testCurrent.Refresh();
            var q = testCurrent.Quests.Last();
            return q;
        }
    }
}

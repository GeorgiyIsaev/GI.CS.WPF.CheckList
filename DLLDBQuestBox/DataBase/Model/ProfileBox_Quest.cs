using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBase.Model
{ 
    /*Взаимодействие с вопросами из БД*/
    public static partial class ProfileBox
    {
        /*Создает объект с вопросом но не записывает его в базу*/
        public static DataBase.Tables.Quest CreateNewQuestDB (string questText,
            string commentText, string answerListText, string anAnswerListText)
        {
            DataBase.Tables.Quest questDB = new Tables.Quest();
            questDB.TextQuest = questText;
            questDB.TextComment = commentText;

            String[] answerMas = answerListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            String[] anAnswerMas = anAnswerListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string text in answerMas)
            {
                if (text == "\r" || text == " \r") continue;
                questDB.Answers.Add(new Tables.Answer() { TextAnswer = text, isTrue = true, /*Quest= questDB*/ });
            }
            foreach (string text in anAnswerMas)
            {
                if (text == "\r" || text == " \r") continue;
                questDB.Answers.Add(new Tables.Answer() { TextAnswer = text, isTrue = false, /*Quest = questDB*/ });
            }                 
            return questDB;
        }

        /*Записывает объект с вопросом в базу и возвращает объект уже из базы*/
        public static DataBase.Tables.Quest AddQuestToDB(DataBase.Tables.Quest questDB)
        {
            if (testCurrent == null) throw new Exception("Нет соединения с тестом БД");
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {                   
                    cont.Tests.Find(testCurrent.Id).Quests.Add(questDB);
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            testCurrent.Refresh();
            var questInDB = testCurrent.Quests.Last();
            return questInDB;
        }

        /*Перезапись вопрос в базе данных*/
        public static DataBase.Tables.Quest ReplacementQuestBD(DataBase.Tables.Quest questDBbefore,
            DataBase.Tables.Quest questDBnew)
        {
      
            //DataBase.Tables.Quest quest
            if (testCurrent == null) throw new Exception("Нет соединения с тестом БД");
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    /*Удаляем страый*/
                    cont.Quests.Attach(questDBbefore);
                    cont.Quests.Remove(questDBbefore);
                    cont.SaveChanges();

                    /*Сохраняем новый*/
                    cont.Tests.Find(testCurrent.Id).Quests.Add(questDBnew);
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


        /*Удалить вопрос по ID*/
        public static void DeleteQuesttAt(long Id)
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    var quest = cont.Quests.Find(Id);

                    //test.Refresh();
                    cont.Quests.Remove(quest);
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        }
    }
}

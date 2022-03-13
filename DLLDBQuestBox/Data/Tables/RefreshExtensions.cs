using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    /*Класс для подтягивания акутальных запией к профилю и обновления объекта*/
    public static class RefreshExtensions
    {
        public static void Refresh(this Profile profile)
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    var sqlWhereProfile = cont.Tests.Where(x => x.ProfileId == profile.Id);
                    foreach (var testProfile in sqlWhereProfile)
                    {
                        //Ни чего добавлять не нужно но для обновления
                        //нужно пройтись по каждому эл-ту
                        //Почему так????
                        var sqlWhereTeest = cont.Quests.Where(x => x.TestId == testProfile.Id);
                        foreach (var questTest in sqlWhereTeest)
                        {
                            var sqlWhereQuest = cont.Answers.Where(x => x.QuestId == questTest.Id);
                            foreach (var answerQuest in sqlWhereQuest)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Data.Model.Notifi.NoConnection(ex);
            }
        }




        public static void Refresh(this Test test)
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {

                    var sqlWhereTeest = cont.Quests.Where(x => x.TestId == test.Id);
                    foreach (var questTest in sqlWhereTeest)
                    {
                        var sqlWhereQuest = cont.Answers.Where(x => x.QuestId == questTest.Id);
                        foreach (var answerQuest in sqlWhereQuest)
                        {                  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Data.Model.Notifi.NoConnection(ex);
            }
        }
        public static void Refresh(this Quest quest)
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {

                    var sqlWhereQuest = cont.Answers.Where(x => x.QuestId == quest.Id);
                    foreach (var answerQuest in sqlWhereQuest)
                    {
                    }

                }
            }
            catch (Exception ex)
            {
                Data.Model.Notifi.NoConnection(ex);
            }
        }
    }
}

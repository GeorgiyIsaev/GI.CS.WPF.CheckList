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
                    var sqlWhere = cont.Tests.Where(x => x.ProfileId == profile.Id);
                    foreach (var temp in sqlWhere)
                    { 
                        //Ни чего добавлять не нужно но для обновления
                        //нужно пройтись по каждому эл-ту
                        //Почему так????
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


                    var sqlWhere = cont.Quests.Where(x => x.TestId == test.Id);
                    foreach (var temp in sqlWhere)
                    {
                        //Ни чего добавлять не нужно но для обновления
                        //нужно пройтись по каждому эл-ту
                        //Почему так????
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

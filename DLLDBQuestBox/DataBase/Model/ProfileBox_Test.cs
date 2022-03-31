using DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    /*Взаимодействие с тестами из БД*/
    public static partial class ProfileBox
    {
        public static DataBase.Tables.Test testCurrent;
        public static void EndTest() { testCurrent = null; }

        /*Подключиться к тесту по ID*/
        public static void ConnectTest(long id)
        {
            if (profile == null) return;
            profile.Refresh();
            foreach (var testIt in profile.Tests)
            {
                if (testIt.Id == id)
                {
                    testCurrent = testIt;
                    break;
                }
            }
        }
        /*Изменить имя теста*/
        public static void ChangeTestName(DataBase.Tables.Test testSelect)
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    cont.Tests.Attach(testSelect);
                    cont.Entry(testSelect).State = EntityState.Modified;
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            profile.Refresh();
        }

        /*Очистить текущий тест от вопросов*/
        public static void ClearTest()
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    cont.Tests.Attach(testCurrent);
                    cont.Entry(testCurrent).State = EntityState.Modified;
                    cont.SaveChanges();
                    testCurrent.Quests.Clear();
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            profile.Refresh();
        }




        /*Создать новый ТЕСТ на основе имяни пароле*/
        public static Test CreateNewTest(String groupName, String testName)
        {
            //Создали профиль
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    cont.Profiles.Find(profile.Id).Tests.Add(new DataBase.Tables.Test { Group = groupName, Name = testName });
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            profile.Refresh();
            return profile.Tests.Last(); //возвращаем последний добавленный тест
        }

        /*Удалить тест по ID*/
        public static void DeleteTestAt(long Id)
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    var test = cont.Tests.Find(Id);

                    //test.Refresh();
                    cont.Tests.Remove(test);
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

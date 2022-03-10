using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public static class TestCRUD
    {

        public static Data.Tables.Test Add(String group, String name, long profileId)
        {
            Data.Tables.Test profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    /*Заполнение таблицы */
                    profile = new Data.Tables.Test { Name = name, Group = group, ProfileId = profileId};
                    cont.Tests.Add(profile);
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile;
        }
        public static Tables.Test GetID(long id)
        {
            Tables.Test profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    var p1 = cont.Tests.Find(id); //поиск по id
                    if (p1 != null)
                    {
                       // Console.WriteLine(p1.Id + " " + p1.Name);
                        profile = p1;
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile; //вернут null если такого эл-та нет
        }
        public static Tables.Test GetName(String name)
        {
            Tables.Test test = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    foreach (var p in cont.Tests)
                    {
                        if (p.Name == "Admin")
                        {
                            test = p;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return test; //вернут null если такого эл-та нет
        }


        public static string DeleteStr(String profileName)
        {
            Tables.Test test = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    foreach (var t in cont.Tests)
                    {
                        if (t.Name == profileName)
                        {
                            test = t;
                            if (t != null)
                            {
                                cont.Tests.Remove(t);
                            }
                        }
                    }
                    cont.SaveChanges(); //сохранять изменение после каждой записи
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            if (test == null) return "Профиль " + profileName + " отсутствует в БД!";
            return "Профиль " + test.Name + " удален!";
        }

        public static Tables.Test ModmodificationID(long id , String group, String name)
        {
            Tables.Test test = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {

                    var t = cont.Tests.Find(id); //поиск по id

                    if (t != null)
                    {
                        t.Name = name;
                        t.Group = group;    
                        cont.SaveChanges(); //сохранить
                        test = t;
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return test;
        }
    }
}
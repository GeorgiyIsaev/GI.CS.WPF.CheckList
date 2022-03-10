using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    /*(англ. create), чтение (read), модификация (update), удаление (delete).*/
    public static class ProfileCRUD
    {
        public static Data.Tables.Profile Add(String name, String password)
        {
            Data.Tables.Profile profile = null;
            try
            {                
                using (var cont = new Data.MyDbContext())
                {                
                    /*Заполнение таблицы */
                    profile = new Data.Tables.Profile { Name = name, Password = password };
                    cont.Profiles.Add(profile);
                    cont.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile;
        }
        public static Tables.Profile GetID(long id)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    var p1 = cont.Profiles.Find(id); //поиск по id
                    if (p1 != null) { 
                        Console.WriteLine(p1.Id + " " + p1.Name);
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
        public static Tables.Profile GetName(String name)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    foreach (var p in cont.Profiles)
                    {
                        if (p.Name == "Admin")
                        {
                            profile = p;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile; //вернут null если такого эл-та нет
        }


        public static string DeleteStr(String profileName)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    foreach (var p in cont.Profiles)
                    {
                        if (p.Name == profileName)
                        {
                            profile = p;
                            if (p != null)
                            {
                                ResetTest(profile.Id);
                                cont.Profiles.Remove(p);
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
            if (profile == null) return "Профиль " + profileName + " отсутствует в БД!";
            return "Профиль " + profile.Name + " удален!";
        } 

        public static Tables.Profile ModmodificationID(long id, String name, String password)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {

                    var p1 = cont.Profiles.Find(id); //поиск по id

                    if (p1 != null)
                    {
                        p1.Name = name;
                        p1.Password = password;

                        cont.SaveChanges(); //сохранить
                        profile = p1;
                    }         
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile;
        }

        public static void GetTests(long id)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {

                    var p1 = cont.Profiles.Find(id); //поиск по id

                    if (p1 != null)
                    {
                        var test = p1.Tests;
                                       
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }         
        }

        public static Tables.Profile AddTest(long id, String group, String name)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    var p1 = cont.Profiles.Find(id); //поиск по id

                    if (p1 != null)
                    {
                        p1.Tests.Add(new Tables.Test { Group = group, Name = name });

                        

                        cont.SaveChanges(); //сохранить
                        //var ttt1 = cont.Tests.Where(x => x.ProfileId == p1.Id);
                        //foreach(var temp in ttt1)
                        //{
                        //    Console.WriteLine(temp.Group + " " + temp.Name);
                        //}
                        profile = p1;
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile;
        }

        public static Tables.Profile ResetTest(long id)
        {
            Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    var p1 = cont.Profiles.Find(id); //поиск по id

                    if (p1 != null)
                    {
                        var ttt1 = cont.Tests.Where(x => x.ProfileId == p1.Id);
                        foreach (var temp in ttt1)
                        {
                            p1.Tests.Add(temp);           
                        }
                        profile = p1;
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile;
        }
    }
}

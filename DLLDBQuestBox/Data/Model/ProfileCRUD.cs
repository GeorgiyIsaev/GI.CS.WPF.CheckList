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

        public static void Modmodification()
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {

                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        } 
    
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Tables;

namespace DataBase.Model
{
    public static partial class ProfileBox
    {
        public static DataBase.Tables.Profile profile;
        static long currentTestID = -1;
        public static long GetCurrentTestID { get { return currentTestID; } }
        public static void SetCurrentTestID(long id) { currentTestID = id; }


        public static void ConnectProfile(String name, String password)
        {
            EndConect();
            //Data.Tables.Profile profile = null;
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    foreach (var p in cont.Profiles)
                    {
                        if (p.Name == name)
                        {
                            // Console.WriteLine(name + " " + p.Password);
                            if (p.Password != password)
                            {
                                throw new Exception("Неверный пароль");
                            }
                            p.Refresh(); // обновляем запись
                            profile = p;                
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }           
        }
        public static void ReConnect()
        {
            //Data.Tables.Profile profile = null;
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    //cont.Profiles.Attach(profile);
                    profile.Refresh();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        }


        public static void SaveToChangeDB()
        {      //Сохранить измения в базу применять только при изменении или удаление существующих записей
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    cont.Entry(profile).State = EntityState.Modified;
                    nameID(cont); //Меняет имя если такое уже есть

                    /*Изменяем связанные списки из кода в Базу*/
                    //cont.Entry(profile).State = EntityState.Modified;
                   // cont.AddOrUpdate(profile);
                    //cont.Profiles.Attach(profile);
                    cont.SaveChanges();  
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            } 
            profile.Refresh();  /*Обновляем списки на те что в базе*/    
        }

        private static void nameID(MyDbContext cont)
        {    
            foreach (var p in cont.Profiles)
            {
                if (p.Name == profile.Name && p.Id != profile.Id)
                {
                    profile.Name += " " + profile.Id;
                    nameID(cont);
                    break;
                }
            }
        
        }

        public static void SaveToDeleteDB()
        {      //Сохранить измения в базу применять только при изменении или удаление существующих записей
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    /*Изменяем связанные списки из кода в Базу*/
                    cont.Profiles.Attach(profile);
                    //profile.Tests = profile.Tests;
                    //Attach();
                    //cont.Entry(profile).State = EntityState.Unchanged;
                    cont.SaveChanges();                 
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            profile.Refresh();
        }


        public static void EndConect()
        { //Очистить профиль
            profile = null;
            currentTestID = -1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Tables;

namespace DataBase.Model
{
    public static class ProfileBox
    {
        public static DataBase.Tables.Profile profile;
        public static void ConnectProfile(String name, String password)
        {
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
        public static void ReConnect(String name, String password)
        {
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


        public static void SaveToDB()
        {      //Сохранить измения в базу
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {

                    var p1 = cont.Profiles.Find(profile.Id); //поиск по id
                    if (p1 != null)
                    {
                        p1.Name = profile.Name;
                        p1.Password = profile.Password;
                        // p1.Refresh();

                        cont.Profiles.Attach(p1);
                       // p1.Tests = profile.Tests;

                        cont.SaveChanges(); //сохранить
                        profile = p1;
                        profile.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }     
        }
        public static void EndConect()
        { //Очистить профиль
            profile = null;
        }


        public static void CreateNewProfile(String name, String password)
        {
            //Создали профиль
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {           
                    cont.Profiles.Add(new DataBase.Tables.Profile { Name = name, Password = password });
                    cont.SaveChanges();                  
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            //Подключились
            ConnectProfile(name, password);
        }

      



    }
}

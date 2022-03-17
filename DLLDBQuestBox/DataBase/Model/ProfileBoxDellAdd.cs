using DataBase.Tables;
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
        
        
        
        public static void DeleteProfileAt()
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
  
                    cont.Profiles.Attach(profile);     
                    cont.Entry(profile).State = EntityState.Modified;       
                    cont.Profiles.Remove(profile);
                    cont.SaveChanges();
                    profile = null;
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        }


        public static void DeleteProfileAt(long Id)
        {       
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    var prof = cont.Profiles.Find(Id);
                    prof.Refresh();
                    cont.Profiles.Remove(prof);
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        }
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
        public static void DeleteAnswertAt(long Id)
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    var answer = cont.Answers.Find(Id);

                    //test.Refresh();
                    cont.Answers.Remove(answer);
                    cont.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        }







        public static void CreateNewProfile(String name, String password)
        {
            //Создали профиль
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    foreach (var p in cont.Profiles)
                    {
                        if (p.Name == name)
                        {
                            throw new Exception("Профиль с таким именем уже существует");
                        }
                    }
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

  
        public static void CreateNewTest(String groupName, String testName)
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
            var newTest = profile.Tests.Last<Test>();
            if (newTest != null) currentTestID = newTest.Id;
        }
    }
}

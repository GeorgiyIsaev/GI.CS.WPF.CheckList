using DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    /*Класс для получения списка профилей формирующих меню профилей*/
    public class ProfilesMenu
    {
        public static List<Profile> profiles;    

        public static void Connect(String name = "")
        {      
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {
                    profiles = new List<Profile>();
                    foreach (var p in cont.Profiles)
                    {
                        profiles.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }          
        }
        public static void EndConnect()
        {
            profiles = null;
        }
    }
}

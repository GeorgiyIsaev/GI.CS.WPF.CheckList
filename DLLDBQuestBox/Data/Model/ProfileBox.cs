using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public static class ProfileBox
    {
        public static Data.Tables.Profile profile;

        public static Data.Tables.Profile ConnectProfile(String name, String password)
        {
            Data.Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    foreach (var p in cont.Profiles)
                    {
                        if (p.Name == "Admin")
                        {
                            if (p.Password != password)
                            {
                                throw new Exception("Неверный пароль");
                            }
                            profile = p;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
            return profile;
        }

        public static void SaveToDB()
        {      
            try
            {
                using (var cont = new Data.MyDbContext())
                {
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

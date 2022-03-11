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


        public static void ConnectProfile(String name, String password)
        {
            //Data.Tables.Profile profile = null;
            try
            {
                using (var cont = new Data.MyDbContext())
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
                            var tetsProfile = cont.Tests.Where(x => x.ProfileId == p.Id);
                            Console.WriteLine("tetsProfile" + tetsProfile);
                            foreach (var temp in tetsProfile)
                            {
                                Console.WriteLine("tetsProfile");
                                p.Tests.Add(temp);
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

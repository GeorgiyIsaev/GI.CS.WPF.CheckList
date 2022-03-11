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
                                Console.WriteLine("    p.Tests.Count " + p.Tests.Count);
                                Console.WriteLine(temp.Name);
                                p.Tests.Add(temp);
                            }
                            Console.WriteLine("    p.Tests.Count " + p.Tests.Count);

                            profile = p;
                            Console.WriteLine("    profile.Tests.Count " + profile.Tests.Count);
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

using DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public static partial class ProfileBox
    {
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


    }


}

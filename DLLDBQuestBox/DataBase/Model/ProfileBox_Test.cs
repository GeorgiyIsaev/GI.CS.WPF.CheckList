using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public static partial class ProfileBox
    {
        public static DataBase.Tables.Test testCurrent;
        public static void EndTest() { testCurrent = null; }
        public static void TestRefresh(long id)
        {
            if (profile == null) return;
            profile.Refresh();
            foreach (var testIt in profile.Tests)
            {
                if(testIt.Id == id)
                {
                    testCurrent = testIt;
                    break;
                }
            }
        }

    }
}

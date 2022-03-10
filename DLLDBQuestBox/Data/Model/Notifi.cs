using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    /*Уведомеления*/
    public static class Notifi
    {
        public static void NoConnection(Exception ex)
        {
            Console.WriteLine("Отсутствует соединение с базой данных!");
            Console.WriteLine(ex.Message);
        }
    }
}

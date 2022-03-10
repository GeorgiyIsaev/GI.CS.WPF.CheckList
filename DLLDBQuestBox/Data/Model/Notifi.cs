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
        public static void printFullTest()
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    Console.WriteLine("\nВСЕ ТЕСТЫ!");
                    /*Посмотрим все тесты*/
                    foreach (var p in cont.Tests)
                    {
                        Console.WriteLine("ID: " + p.Id + " Группа: " + p.Group + " Название: " + p.Name);
                    }
                    Console.WriteLine(" - - - ");
                }
            }
            catch (Exception ex)
            {
                Notifi.NoConnection(ex);
            }
        }
    }
}

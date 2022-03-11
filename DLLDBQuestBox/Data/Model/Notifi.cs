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
            /*Добавить делигат вызвающий событие в главной программе
             Будит вызвать окно с текстом ошибки при невозможности подключения!*/

            Console.WriteLine("Отсутствует соединение с базой данных!");
            Console.WriteLine(ex.Message);
        }



        public static void printFullTest()
        { //метод для отладки
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    Console.WriteLine("\nВСЕ ТЕСТЫ!");
                    /*Посмотрим все тесты*/
                    foreach (var p in cont.Tests)
                    {
                        Console.WriteLine("ID: " + p.Id + " Группа: " + p.Group + " Название: " + p.Name + " ProfileId: " + p.ProfileId);
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

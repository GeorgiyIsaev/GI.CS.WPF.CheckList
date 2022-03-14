using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    delegate void Message(String text);

    /*Уведомеления*/
    public static class Notifi
    {

        static Message mes;

        internal static Message Mes { get => mes; set => mes = value; }

        public static void NoConnection(Exception ex)
        {
            /*Добавить делигат вызвающий событие в главной программе
             Будит вызвать окно с текстом ошибки при невозможности подключения!*/

            String textError = "Ошибка соединения с Базой Дынных.\n";
            textError += ex.Message;


           // Console.WriteLine(textError);
            mes(textError);
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

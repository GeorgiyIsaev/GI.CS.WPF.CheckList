using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public delegate void Message(String text);

    /*Уведомеления*/
    public static class Notifi
    {

        public static Message mes;


        public static void NoConnection(Exception ex)
        {
            /*Добавить делигат вызвающий событие в главной программе
             Будит вызвать окно с текстом ошибки при невозможности подключения!*/

            String textError = "Ошибка Базы Данных.\n";
            textError += ex.Message;


            Console.WriteLine(textError);
            mes?.Invoke(textError); // вызывается метод mes если он есть

        }



        public static void printFullTest()
        { //метод для отладки
            try
            {
                using (var cont = new DataBase.MyDbContext())
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

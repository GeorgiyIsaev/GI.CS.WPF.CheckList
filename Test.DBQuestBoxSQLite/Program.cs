using System;
using DLLDBQuestBox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DBQuestBoxSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var cont = new DLLDBQuestBox.Data.MyDbContext())
                {
                    Console.WriteLine("Есть контакт!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        
    }
    /*Команды в диспетчере пакетов мигарции
     * Enable-Migrations - выполняется 1 раз создает Configration.cs
     * add-migration "text" - выполняет миграцию
     */
}

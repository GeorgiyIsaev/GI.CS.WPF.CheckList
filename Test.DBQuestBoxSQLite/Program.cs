using System;
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
                using (var cont = new Data.MyDbContext())
                {
                    Console.WriteLine("Подключение к базе даных!");
            
                                      
                    if (cont.Profiles.Count() == 0) //Если таблица не пуста добавить профили
                    {
                        cont.Profiles.Add(new Data.Tables.Profile { Name = "User" });
                        cont.Profiles.Add(new Data.Tables.Profile { Name = "Admin" });
                        /*AddProfiles("Guest", "0000");
                         AddProfiles("Admin", "Admin");*/
                    }


                    /*Чтение из таблицы*/
                    foreach (var p in cont.Profiles)
                    {
                        Console.WriteLine("ID: " + p.Id + " Имя: " + p.Name + " Пасс: " + p.Password);
                    }
                    var p1 = cont.Profiles.Find(1); //поиск по id
                    Console.WriteLine(p1.Id + " "+ p1.Name);

              

                    p1 = cont.Profiles.Find(9); //поиск по id
                    //Если вернет null будит выбрашена ошибка
                    if(p1 != null)
                    {
                        Console.WriteLine(p1.Id + " " + p1.Name);
                    }
                    else
                     Console.WriteLine("Такого эл-та нет");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void AddProfiles(string name, string password)
        {
            using (var cont = new Data.MyDbContext())
            {
                /*Заполнение таблицы */
                var profile = new Data.Tables.Profile { Name = name, Password = password };
                cont.Profiles.Add(profile);
                cont.SaveChanges();
            }
        }

    }


}


/* Пакеты которые нужно подключить через нугет
System.Data.SQlite
SQlite.codeFirst
System.Data.SQLite.EF6.Migrations
Удостоверится что EntityFramework v 6.4.0
*/

/*Создать конкты в файле конфигураций App.config
<providers>
<!--подключение к базе-->
<provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
<provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
<provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6, Version=1.0.113.0, Culture=neutral" />
    
<!--подключение к дате-->
<remove invariant="System.Data.SQLite" />

<!--КонекшенСтринг - Расположение и доступ к БД-->
<connectionStrings>
<add name="MyDbContext" connectionString="data source=.\MyDB.sqlite" providerName="System.Data.SQLite" />
</connectionStrings>     
*/

/*Команды в диспетчере пакетов мигарции
* Enable-Migrations - выполняется 1 раз создает Configration.cs
* add-migration "AddTables" - выполняет миграцию
* Update-Database - завершает предудущую миграцию, что бы начать следующую
*/



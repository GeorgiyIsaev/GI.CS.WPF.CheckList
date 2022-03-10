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
                        AddProfile("Guest", "0000");
                        var profile = AddProfile("Admin", "Admin");
                        AddTest("Тема по C#", "Основы С#", 1);


                        if (profile != null)
                        {
                            /*На самом деле кривое добавление так как плодит новые объекты в таблице профиле дублируя передоваемый*/
                            AddTestSuper("Тема по C#", "WPF С#", profile);
                            AddTestSuper("Тема по C#", "WF С#", profile);
                            AddTestSuper("Тема по C#", "Ado", profile);
                        }
                    }


                    /*Чтение из таблицы*/
                    foreach (var p in cont.Profiles)
                    {
                        Console.WriteLine("ID: " + p.Id + " Имя: " + p.Name + " Пасс: " + p.Password);
                    }

                    /*Чтение из таблицы по индексу*/
                    var p1 = cont.Profiles.Find(0); //поиск по id
                    if (p1 != null) { Console.WriteLine(p1.Id + " " + p1.Name); }
                    else Console.WriteLine("Такого эл-та нет 0");

                    p1 = cont.Profiles.Find(9); //поиск по id
                    //Если вернет null будит выбрашена ошибка
                    if (p1 != null) { Console.WriteLine(p1.Id + " " + p1.Name); }
                    else Console.WriteLine("Такого эл-та нет 9");

                    /*Чтение из таблицы по конкретному значению*/
                    long profileID = -1;
                    foreach (var p in cont.Profiles)
                    {
                        Console.WriteLine("ID: " + p.Id + " Имя: " + p.Name + " Пасс: " + p.Password);
                        Console.WriteLine(p.Name + "== Admin " + (p.Name == "Admin"));
                        if (p.Name == "Admin")
                        {
                            profileID = p.Id;
                        }

                    }
                    Console.WriteLine("profileID " + profileID);
                    foreach (var p in cont.Tests)
                    {
                        if (profileID != -1 && profileID == p.ProfileId)
                        {
                            Console.WriteLine("Совпадение");
                            Console.WriteLine("ID: " + p.Id + " Группа: " + p.Group + " Название: " + p.Name);
                            Console.WriteLine("Профиль: " + p.Profile.Name);
                        }
                    }


                    /*Удаление*/

                    foreach (var p in cont.Profiles)
                    {
                        if (p.Name == "Admin")
                        {
                            var profiledelete = p;
                            Console.WriteLine("Удаляем " + p.Name);
                            if (profiledelete != null)
                            {
                                foreach (var t in cont.Tests)
                                {
                                    if (t.ProfileId == p.Id)
                                    {
                                        Console.WriteLine("t.ProfileId " + t.ProfileId);
                                        cont.Tests.Remove(t);
                                    }
                                }
                                cont.Profiles.Remove(profiledelete);
                            }
                               
                        }
                    }
                    cont.SaveChanges();
                    /*Посмотрим все тесты*/
                    foreach (var p in cont.Tests)
                    {

                        Console.WriteLine("ID: " + p.Id + " Группа: " + p.Group + " Название: " + p.Name);
                        /* Console.WriteLine("Профиль: " + p.Profile.Name);*/

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static Data.Tables.Profile AddProfile(string name, string password)
        {
            Data.Tables.Profile profile;
            using (var cont = new Data.MyDbContext())
            {
                /*Заполнение таблицы */
                profile = new Data.Tables.Profile { Name = name, Password = password };
                cont.Profiles.Add(profile);
                cont.SaveChanges();
            }
            return profile;
        }
        static Data.Tables.Test AddTest(string name, string group, long profileId)
        {

            Data.Tables.Test test;
            using (var cont = new Data.MyDbContext())
            {
                /*Заполнение таблицы */
                test = new Data.Tables.Test { Name = name, Group = group, ProfileId = profileId };
                cont.Tests.Add(test);
                cont.SaveChanges();
            }
            return test;
        }

        static void AddTestSuper(string name, string group, Data.Tables.Profile profile)
        {
            using (var cont = new Data.MyDbContext())
            {
                /*Заполнение таблицы */
                var test = new Data.Tables.Test { Name = name, Group = group, ProfileId = profile.Id };
                cont.Tests.Add(test);
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



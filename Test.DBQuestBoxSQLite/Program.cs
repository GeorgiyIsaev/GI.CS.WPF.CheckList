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
            /*Изменение*/
            var profileDel = Data.Model.ProfileCRUD.DeleteStr("Admin");        
            Console.WriteLine(profileDel);

            /*Добавление*/
            Data.Model.ProfileCRUD.Add("Admin", "Admin");

            /*Поиск по имени*/
            var profile = Data.Model.ProfileCRUD.GetName("Admin");
            if (profile != null) Console.WriteLine("profile: " + profile.Name + " password: " + profile.Password + " Id: " + profile.Id);
            else Console.WriteLine("Запись Admin не найдена! Чтение не возможно!");


            /*Изменение*/
            if (profile != null) {
                var profileMod = Data.Model.ProfileCRUD.ModmodificationID(profile.Id, profile.Name, "0000"); //изменяем пароль
                if (profileMod != null) Console.WriteLine("profile: " + profileMod.Name + " password: " + profileMod.Password + " Id: " + profileMod.Id);
                else Console.WriteLine("Запись Admin не найдена! Изменить не возможно!");
            }



            Console.ReadLine();
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


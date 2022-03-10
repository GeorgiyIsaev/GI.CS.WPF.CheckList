using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);


            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            _ = sqlGenerator.Generate(model.StoreModel);

            /*Один ко многим*/
             modelBuilder.Entity<Tables.Profile>()
                 .HasMany(p => p.Tests)
                 .WithRequired(p => p.Profile)
                 .HasForeignKey(s => s.ProfileId)
                 .WillCascadeOnDelete(false);;

           /* modelBuilder.Entity<Tables.Test>()
                 .HasRequired<Tables.Profile>(o => o.Profile)
                 .WithMany(p => p.Tests)
                 .HasForeignKey(o => o.ProfileId); */

            //Персона со списоком оредров
            //Профиль со списком тестов


        }
        public DbSet<Tables.Profile> Profiles { get; set; }
        public DbSet<Tables.Test> Tests { get; set; }
        public DbSet<Tables.Quest> Quests { get; set; }
        public DbSet<Tables.Answer> Answers { get; set; }
    }
}

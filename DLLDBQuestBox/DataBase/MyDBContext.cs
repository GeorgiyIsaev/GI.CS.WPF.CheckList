using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
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
                 .WillCascadeOnDelete(true);

            modelBuilder.Entity<Tables.Test>()
              .HasMany(p => p.Quests)
              .WithRequired(p => p.Test)
              .HasForeignKey(s => s.TestId)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<Tables.Quest>()
              .HasMany(p => p.Answers)
              .WithRequired(p => p.Quest)
              .HasForeignKey(s => s.QuestId)
              .WillCascadeOnDelete(true);



            //modelBuilder.Entity<Tables.Profile>()
            //   .HasMany<Tables.Test>(p => p.Tests)
            //   .WithRequired(p => p.Profile)
            //   .HasForeignKey(C => C.JobId).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Sport>()
            //    .HasMany<JobSportsMapping>(C => C.JobSportsMappings)
            //      .WithRequired(C => C.Sport)
            //      .HasForeignKey(C => C.SportId).WillCascadeOnDelete(true);

            /* modelBuilder.Entity<Tables.Test>()
                  .HasRequired<Tables.Profile>(o => o.Profile)
                  .WithMany(p => p.Tests)
                  .HasForeignKey(o => o.ProfileId); */

        }
        public DbSet<Tables.Profile> Profiles { get; set; }
        public DbSet<Tables.Test> Tests { get; set; }
        public DbSet<Tables.Quest> Quests { get; set; }
        public DbSet<Tables.Answer> Answers { get; set; }
    }
}

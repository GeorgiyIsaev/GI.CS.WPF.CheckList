﻿using DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    /*Класс для подтягивания акутальных запией к профилю и обновления объекта*/
    public static class RefreshExtensions
    {
        public static void Refresh(this Profile profile)
        {
            try
            {
                using (var cont = new DataBase.MyDbContext())
                {

                    //  Console.WriteLine("    EXpProfile " + profile.Name);
                    profile.Tests.Clear(); //очистка перед перезаписью

                      var sqlWhereProfile = cont.Tests.Where(x => x.ProfileId == profile.Id);
                   // Console.WriteLine("    sqlWhereProfile " + sqlWhereProfile.ToString());
            
                    foreach (var myTest in sqlWhereProfile)
                    {
                        profile.Tests.Add(myTest);
                       // Console.WriteLine("    EXp.Tests.Count " + profile.Tests.Count);                  
                        var sqlWhereTeest = cont.Quests.Where(x => x.TestId == myTest.Id);
                        foreach (var myQuest in sqlWhereTeest)
                        {
                           // myTest.Quests.Add(myQuest); //внезапно добавление происходит при чтении, а как это так
                           // Console.WriteLine("    EXtestProfile.Quests.Count " + myTest.Quests.Count);

                            var sqlWhereQuest = cont.Answers.Where(x => x.QuestId == myQuest.Id);
                            foreach (var myAnswer in sqlWhereQuest)
                            {
                            //myQuest.Answers.Add(myAnswer);//внезапно добавление происходит при чтении, а как это так
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataBase.Model.Notifi.NoConnection(ex);
            }
        }

    public static void Refresh(this Test test)
    {
        try
        {
            using (var cont = new DataBase.MyDbContext())
            {
                test.Quests.Clear(); //очистка перед перезаписью
                var sqlWhereTeest = cont.Quests.Where(x => x.TestId == test.Id);
                foreach (var myQuest in sqlWhereTeest)
                {
                    test.Quests.Add(myQuest); //внезапно добавление происходит при чтении, а как это так      
                    var sqlWhereQuest = cont.Answers.Where(x => x.QuestId == myQuest.Id);
                    foreach (var myAnswer in sqlWhereQuest)
                    {
                        //myQuest.Answers.Add(myAnswer);//внезапно добавление происходит при чтении, а как это так
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            DataBase.Model.Notifi.NoConnection(ex);
        }
    }



}


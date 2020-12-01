using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace WPF_CheckListQuests
{
    class QuestsBoxForTest
    {
       public static List<QuestItem> questItemsForTest = new List<QuestItem>();
       
       public void createTest()
       {
            questItemsForTest = new List<QuestItem>(QuestsBox.questItems);

            questItemsForTest.Sort(delegate (QuestItem a, QuestItem b)
            {
                 return a.intRandomQuest.CompareTo(b.intRandomQuest);
            });
       }



    }
}

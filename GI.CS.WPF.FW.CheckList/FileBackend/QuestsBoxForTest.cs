using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace GI.CS.WPF.FW.CheckList
{
    class QuestsBoxForTest
    {
       public static List<QuestItem> questItemsForTest = new List<QuestItem>();
       
       public static void createTest()
       {          
            questItemsForTest = new List<QuestItem>(QuestsBox.questItems);         
            questItemsForTest.RemoveAt(0);

            foreach (var q in questItemsForTest)
                q.RandomGeneratorIt();

            var tempBox = new ObservableCollection<QuestItem>(questItemsForTest.OrderBy(i => i, new QuestItemComparerRND()));
            questItemsForTest.Clear();
            foreach (var q in tempBox)
                questItemsForTest.Add(q);

            //foreach (QuestItem tmp in questItemsForTest)
            //{
            //    tmp.RandomGeneratorIt();     
            //}
       }
    }
}

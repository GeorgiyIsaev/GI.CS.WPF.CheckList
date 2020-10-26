using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_CheckListQuests
{
    public static class QuestsBox
    {
        public static List<QuestItem> answerItem = new List<QuestItem>();
        public static bool if_ThereQuest(string str)
        {
           foreach (QuestItem tmp in answerItem)
           {
                if (tmp.quest == str) return true;
           }
            return false;
        }


    }
}

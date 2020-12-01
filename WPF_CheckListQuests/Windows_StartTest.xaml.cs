using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_CheckListQuests
{
    /// <summary>
    /// Логика взаимодействия для Windows_StartTest.xaml
    /// </summary>
    public partial class Windows_StartTest : Window
    {
        private int currentItem = 0;
        public Windows_StartTest()
        {
            InitializeComponent();            
        }

        void questNext()
        {
            TextBox_Quest.Text = QuestsBoxForTest.questItemsForTest[currentItem].quest;

            foreach (Answer tmpAnswer in QuestsBoxForTest.questItemsForTest[currentItem].answerItem)
            {
                ListBox_AnswerItem.Items.Add(tmpAnswer);
            }
        }



    }
    
}

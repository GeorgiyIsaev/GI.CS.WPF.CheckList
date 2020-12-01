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
        private int finalItem = 20;

        public Windows_StartTest()
        {
            InitializeComponent();
            Loaded += Windows_StartTest_Loaded;
        }

        private void Windows_StartTest_Loaded(object sender, RoutedEventArgs e)
        {
            QuestNext();
        }

        void QuestNext()
        {
            QuestsBoxForTest.createTest();
            if (QuestsBoxForTest.questItemsForTest.Count < 20) finalItem = QuestsBoxForTest.questItemsForTest.Count;
            Title = $"Вопрос {currentItem} из {finalItem}";
            TextBox_Quest.Text = QuestsBoxForTest.questItemsForTest[currentItem].quest;
            foreach (Answer tmpAnswer in QuestsBoxForTest.questItemsForTest[currentItem].answerItem)
            {
                ListBox_AnswerItem.Items.Add(tmpAnswer);
            }
            TextBox_Comment.Text = "";

        }

        private void Buttun_GetAnswer_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
    
}

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
        private bool currentStatus = true;
        private int trueAnswerCount = 0;

        public Windows_StartTest()
        {
            InitializeComponent();
            Loaded += Windows_StartTest_Loaded;
        }

        private void Windows_StartTest_Loaded(object sender, RoutedEventArgs e)
        {
            QuestsBoxForTest.createTest();
            if (QuestsBoxForTest.questItemsForTest.Count < 20) finalItem = QuestsBoxForTest.questItemsForTest.Count;
            QuestNext();
        }

        void QuestNext()
        {
           
           
            Title = $"Вопрос {currentItem+1} из {finalItem}";
            TextBox_Quest.Text = QuestsBoxForTest.questItemsForTest[currentItem].quest;
            ListBox_AnswerItem.Items.Clear();          
            foreach (Answer tmpAnswer in QuestsBoxForTest.questItemsForTest[currentItem].answerItem)
            {
                ListBox_AnswerItem.Items.Add(tmpAnswer);
            }
            TextBox_Comment.Text = "";

        }

        private void Buttun_GetAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (currentStatus)
            {
                if (ListBox_AnswerItem.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Выберите один или несколько ответов!");
                    return;
                }

                if (TruyOrFalse())
                {
                    TextBox_Comment.Text = "ВЕРНО!\n";
                    trueAnswerCount++;
                }
                else
                {
                    TextBox_Comment.Text = "НЕ ВЕРНО!\n";
                }
                TextBox_Comment.Text += QuestsBoxForTest.questItemsForTest[currentItem].comment;
                buttun_GetAnswer.Content = "Следующий вопрос -->";
                currentStatus = false;

            }
            else
            {
                currentStatus = true;
                if (currentItem < finalItem) {
                    currentItem++;
                    QuestNext();
                    buttun_GetAnswer.Content = "Ответить";
                }
                else
                {
                    MessageBox.Show($"Тест Заверешн!\n\n Колличество верных ответов: {currentItem} из {finalItem}");
                }
            }

        }
        private bool TruyOrFalse()
        {
            /*Проверка 1: Несотвествие количества ответов*/
            if (QuestsBoxForTest.questItemsForTest[currentItem].answerItem.Count == ListBox_AnswerItem.SelectedItems.Count)
                return false;
            
            /*Проверка 2: Все выбраные ответы верные*/    
            foreach (Answer temp in ListBox_AnswerItem.SelectedItems)
            {
                if(!temp.if_true) return false;
            }

            /*Ответ дан верный!*/
            return true;
        }


    }


    
}

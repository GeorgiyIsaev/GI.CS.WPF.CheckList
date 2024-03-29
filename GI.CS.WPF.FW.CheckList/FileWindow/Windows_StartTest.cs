﻿using System;
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

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для Windows_StartTest.xaml
    /// </summary>
    public partial class Window_StartTest : Window
    {
        private int currentItem = 0;
        private int finalItem = 20;
        private bool currentStatus = true;
        private int trueAnswerCount = 0;

        public Window_StartTest()
        {
            InitializeComponent();
            Loaded += Windows_StartTest_Loaded;
        }

        private void Windows_StartTest_Loaded(object sender, RoutedEventArgs e)
        {
            QuestsBoxForTest.createTest();
           // QuestsBoxForTest.questItemsForTest.
            if (QuestsBoxForTest.questItemsForTest.Count < 20) finalItem = QuestsBoxForTest.questItemsForTest.Count;
            QuestNext();
        }

        /*Следующий ответ*/
        void QuestNext()
        {
           
           
            Title = $"Вопрос {currentItem+1} из {finalItem}";
            TextBox_Quest.Text = QuestsBoxForTest.questItemsForTest[currentItem].quest;
            ListBox_AnswerItem.Items.Clear();          
            foreach (Answer tmpAnswer in QuestsBoxForTest.questItemsForTest[currentItem].answerItem)
            {
                ListBox_AnswerItem.Items.Add(tmpAnswer);
            }
            TextBox_Result.Text = "";
            TextBox_Comment.Text = "";
            ListBox_AnswerItem.IsEnabled = true;
            ListBox_AnswerItem.Focusable = false;
     
        }

        private void Buttun_GetAnswer_Click(object sender, RoutedEventArgs e)
        {
            /*Кнопка дать ответ*/
            if (currentStatus)
            {
                if (ListBox_AnswerItem.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Выберите один или несколько ответов!");
                    return;
                }
                /*Выполнение нажатия ответа*/
                BtnAnswer_Click();
            }
            //Кнопка перейти к следующему ответу
            else
            {
                currentStatus = true;
                currentItem++;
                if (currentItem < finalItem) {                    
                    QuestNext();
                    buttun_GetAnswer.Content = "Ответить";
                }
                else
                {
                    int procent = trueAnswerCount * 100 / finalItem;
                    string resultTest = $"Колличество верных ответов: {trueAnswerCount} из {finalItem}\n";
                    resultTest += $"Тест сдан на {procent}% ";
                    MessageBox.Show(resultTest, "Тест заверешен");
                    this.Close();
                }
            }

        }

        /*Нажата кнопка дать ответ*/
        private void BtnAnswer_Click()
        {
            if (TruyOrFalse())
            {
                HighLighting();
                TextBox_Result.Text = "ВЕРНО!\n";
                TextBox_Result.Foreground = new SolidColorBrush(Colors.Green);
                trueAnswerCount++;
            }
            else
            {
                HighLighting();
                TextBox_Result.Foreground = new SolidColorBrush(Colors.Red);
                TextBox_Result.Text = "НЕ ВЕРНО!\n";
            }
            TextBox_Comment.Text = "Верные ответы: \n";
            TextBox_Comment.Text += QuestsBoxForTest.questItemsForTest[currentItem].StrFullAnswer();
            if (QuestsBoxForTest.questItemsForTest[currentItem].comment != "")
            {
                TextBox_Comment.Text += "\nПояснение: ";
                TextBox_Comment.Text += QuestsBoxForTest.questItemsForTest[currentItem].comment;
            }
            buttun_GetAnswer.Content = "Следующий вопрос -->";
            if (finalItem - 1 == currentItem) buttun_GetAnswer.Content = "Получить результат!";
            currentStatus = false;
            ListBox_AnswerItem.IsEnabled = false;
        }



        private bool TruyOrFalse()
        {
            /*Проверка 1: Несотвествие количества ответов*/
            if (QuestsBoxForTest.questItemsForTest[currentItem].countTrueAnswer != ListBox_AnswerItem.SelectedItems.Count)
                return false;
            
            /*Проверка 2: Все выбраные ответы верные*/    
            foreach (Answer temp in ListBox_AnswerItem.SelectedItems)
            {
                if(!temp.isTrue) return false;
            }

            /*Ответ дан верный!*/
            return true;
        }

        private void HighLighting()
        {
            /*Проблема с убераеним выделения эл-тов.. поэтому я просто их перезапишу*/         
            int count = 0;
            foreach (Answer temp in ListBox_AnswerItem.Items)
            {
                ListBoxItem lbi = (ListBoxItem)ListBox_AnswerItem.ItemContainerGenerator.ContainerFromIndex(count);
                if (lbi.IsSelected && temp.isTrue)
                {
                    
                    bool a = lbi.IsSelected;
                    lbi.Background = Brushes.Green;
                }
                else if (!lbi.IsSelected && temp.isTrue)
                {                 
                    lbi.Background = Brushes.LightGreen;
                }
                else if (lbi.IsSelected && !temp.isTrue)
                {
                    //lbi.Background = Brushes.HotPink;
                    lbi.Background = Brushes.OrangeRed;
                }
                count++;
            }
            ListBox_AnswerItem.SelectedIndex = -1;
        }
    }    
}

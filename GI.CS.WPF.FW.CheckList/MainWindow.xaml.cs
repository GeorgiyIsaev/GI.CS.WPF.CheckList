﻿using DataBase.Tables;
using GI.CS.WPF.FW.CheckList;
using GI.CS.WPF.FW.CheckList.FileWindow;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Loaded += Window_LoadedKeyPaste;
        }
        private void AddTexQuesttBox(string text)
        {       
            input_Quest.Text = text;
        }
        private void AddTextAnswerBox(string text)
        {
            if (input_Answer.Text != "") input_Answer.Text += "\n";
            input_Answer.Text += text;
        }

        /*Добвление горячих клавишь*/
        public void Window_LoadedKeyPaste(object sender, RoutedEventArgs e)
        {
            Copy.CopyCtrl.AddTextQuestEvent += AddTexQuesttBox;
            Copy.CopyCtrl.Window_LoadedKeyQ(this);

         //   Copy.CopyCtrl.AddTextAnswerEvent += AddTextAnswerBox;
           // Copy.CopyCtrl.Window_LoadedKeyW(this);

            //AddTextAnAnswerEvent
            //AddTextCommentEvent
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*Контейнер с привязкой к листбоксу*/
            ListBox_Quest.ItemsSource = QuestsBox.questItems;
            QuestsBox.AddFirstQuest();
            ListBox_Quest.SelectedIndex = 0;
            NewTitle();

            /*Чтение из временого файла*/
            //EditionTXT.file_readTXT("TEMPTXT.txt");
            NewTitle();   

            DataBase.Model.Notifi.mes += MesageNotConectBD;
            MenuItemRefresh.Refresh(this);          
        }

        /*Метод который отрабатывает при ошибке БАЗЫ*/
        private static void MesageNotConectBD(string text)
        {           
            MessageBox.Show(text);
        }

        public void InputIsEnabled(bool isEnabled)
        {
            GridMain.IsEnabled = isEnabled;
            MenuItemLoad.IsEnabled = isEnabled;
            MenuItemSave.IsEnabled = isEnabled;
        }





        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            int val = ListBox_Quest.SelectedIndex;
            /*if (val == 0 && EditionTXT.if_ThereQuest(input_Quest.Text))
            {
                MessageBox.Show("Такой вопрос уже был добавлен ранее", "Добавление не возможно!");
                return;
            }*/
            if (input_Quest.Text == "")
            {
                MessageBox.Show("Поле с вопросом не заполнено", "Добавление не возможно!");
                return;
            }
            if (input_Answer.Text == "")
            {
                MessageBox.Show("Поле с верным ответом не заполнено", "Добавление не возможно!");
                return;
            }


      
            /*Выполнение события - Изменить*/
            if (ListBox_Quest.SelectedIndex != 0)
            {
                var questItemDB = ProfBox.CreateNewQuestDB(input_Quest.Text, input_Comment.Text, input_Answer.Text, input_AnAnswer.Text);         

                if (ProfBox.testCurrent != null)
                    questItemDB = ProfBox.ReplacementQuestBD(QuestsBox.questItems[val].GetQuestBD(), questItemDB);

                QuestsBox.questItems[val].SetQuestDB(questItemDB);
                ListBox_Quest.SelectedIndex = val; //переход к добавленному эл-ту
                ListBox_Quest.Items.Refresh();
                //ListBox_Quest.SelectedIndex = 0;
                //ListBox_Quest.SelectedIndex = val;
            }
            /*Выполнение события - Добавить*/
            else 
            {
                QuestItem questItem = new QuestItem();
                var questItemDB = ProfBox.CreateNewQuestDB(input_Quest.Text, input_Comment.Text, input_Answer.Text, input_AnAnswer.Text);

                if (ProfBox.testCurrent != null)
                    questItemDB = ProfBox.AddQuestToDB(questItemDB);   

                questItem.SetQuestDB(questItemDB);
                QuestsBox.questItems.Add(questItem);
                ClearInput();
                // ListBox_Quest.SelectedIndex = QuestsBox.questItems.Count() - 1; // переход к добавленному эл-ту
            }
            NewTitle();
        }
     

        private void ListBox_Quest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*Перемещение по лист боксу*/
            if (ListBox_Quest.SelectedIndex > 0)
            {
                int val = ListBox_Quest.SelectedIndex; // индекс выделеного эл-та
                input_AnAnswer.Text = QuestsBox.questItems.ElementAt(val).StrFullAnswer(false);
                input_Answer.Text = QuestsBox.questItems.ElementAt(val).StrFullAnswer();
                input_Comment.Text = QuestsBox.questItems.ElementAt(val).comment;
                input_Quest.Text = QuestsBox.questItems.ElementAt(val).quest;
                Button_Clear.Content = "Удалить";
                Button_Save.Content = "Изменить";
            }
            else
            {
                Button_Clear_Click(sender, e);
                Button_Clear.Content = "Очистить";
                Button_Save.Content = "Добавить";

            }
        }
        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ("Delete" == e.Key.ToString() && ListBox_Quest.SelectedIndex != 0)
                DeleteItem();
        }

        /*Метод выполняемый при удалении Вопроса*/
        private void DeleteItem()
        {
            if (ListBox_Quest.SelectedIndex <= 0)
            {
                ClearInput();
            }
            else
            {
                var result = MessageBox.Show($"Вы действительно хотите удалить этот вопрос?", "Предуприждение!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    int val = ListBox_Quest.SelectedIndex;
                    if(ProfBox.testCurrent != null)
                    {
                        ProfBox.DeleteQuesttAt(QuestsBox.questItems[val].GetQuestBD().Id);
                    }
                    if (val > 0) QuestsBox.questItems.RemoveAt(val);
                    ListBox_Quest.SelectedIndex = 0; 
                    //EditionTXT.WriteInTXT("TEMPTXT.txt");
                    NewTitle();
                }
            }
        }
        public void ClearInput()
        {
            input_AnAnswer.Text = "";
            input_Answer.Text = "";
            input_Comment.Text = "";
            input_Quest.Text = "";
            ListBox_Quest.SelectedIndex = 0;
        }


        /*Очистка формы и презаполнение листа*/
        public void ClearForm()
        {    
            QuestsBox.questItems.Clear();
            QuestItem questItem = new QuestItem();
            questItem.quest = "<Добавить новый вопрос>";
            QuestsBox.questItems.Add(questItem);
            NewTitle();
            ListBox_Quest.SelectedIndex = 0;
            ClearInput();
            //if(ProfBox.testCurrent != null)
            //    ProfBox.ClearTest();
        }


        private void MenuItemSort_Click(object sender, RoutedEventArgs e)
        {
            QuestsBox.Sort(); //сортируем
        }



        /*Меню Файл-> Сохранить в файл*/
        private void MenuItemSaveHTML_Click(object sender, RoutedEventArgs e)
        {
            new Window_SaveCheckList().ShowDialog();          
        }
        /*Меню Файл-> Открыть католок*/
        private void MenuItemOpenDirectoriy_Click(object sender, RoutedEventArgs e)
        {
            string forever_papka = Environment.CurrentDirectory;
            System.Diagnostics.Process.Start("explorer", forever_papka);
        }
        /*Меню Файл-> Добавить из файла*/
        private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
        {
            new Window_Load().ShowDialog();
            NewTitle();
        }
        /*Меню Файл-> Добавить из файла v2 - Правильный*/
        private void MenuItemLoad2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Html documents (*.html)|*.html";
            dialog.Filter += "|Text documents(*.txt)|*.txt";
            dialog.Filter += "|JSON documents (*.json)|*.json";
            dialog.Filter += "|All (*.json, *.txt, *.html)|*.json; *.txt; *.html";
            //dialog.Filter += "|All files (*.*)|*.*";         
            dialog.FilterIndex = 4;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {          
                string fileName = dialog.FileName;         
                FileBackend.ReadFile.Read(fileName);
                NewTitle();
            }        
        }
        /*Меню Запустить тест*/
        private void MenuItemStartTest_Click(object sender, RoutedEventArgs e)
        {
            if (QuestsBox.questItems.Count <= 1)
            {
                MessageBox.Show("Недостаточно вопросов для запуска теста");
                return;
            }
            new Window_StartTest().ShowDialog();
        }
        /*Меню Файл-> Очистить лист*/
        private void MenuItemClear_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Вы действительно хотите очистить чек-лист от всех вопросов?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClearForm();
            }
        }
        /*Меню-Описание приложения*/
        private void MenuItemOpenDescription_Click(object sender, RoutedEventArgs e)
        {
            new Window_DescriptionForApplication().ShowDialog();          
        }


        public void NewTitle()
        {
            Title = $"Чек-Лист [Вопросов: {QuestsBox.questItems.Count - 1}]";
        }       
    } 
}

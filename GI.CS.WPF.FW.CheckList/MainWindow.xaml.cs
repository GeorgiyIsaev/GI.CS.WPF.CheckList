﻿using DataBase.Tables;
using GI.CS.WPF.FW.CheckList;
using GI.CS.WPF.FW.CheckList.FileWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Loaded += Window_LoadedKey;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        //необходимые константы
        public const int MOD_CONTROL = 0x2;
        public const int WM_HOTKEY = 0x312;
        public const uint MOD_NOREPEAT = 0;

        //несколько примеров виртуальных кодов
        public const uint KEY_1 = 0x31;
        public const uint KEY_2 = 0x32;
        public const uint KEY_3 = 0x33;
        public const uint KEY_5 = 0x34;

        public const uint KEY_Q = 0x51;
        public const uint KEY_W = 0x57;
        public const uint KEY_E = 0x45;
        public const uint KEY_R = 0x52;

        //обработчик сообщений для окна
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            if (msg == WM_HOTKEY)
            {
                input_Quest.Text += DateTime.Now.ToString() + " WM_HOTKEY message, ID: 0x" + wParam.ToString("X");
                input_Quest.Text += Environment.NewLine;
                handled = true;
            }

            return IntPtr.Zero;
        } 

        private void Window_LoadedKey(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper h = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(h.Handle);
            source.AddHook(new HwndSourceHook(WndProc));//регистрируем обработчик сообщений

            bool re3s = RegisterHotKey(h.Handle, 1, MOD_CONTROL | MOD_NOREPEAT, 0x42);  //0x42 is 'b'
            if (re3s == false) MessageBox.Show("RegisterHotKey failed re2s");

            bool re4s = RegisterHotKey(h.Handle, 1, MOD_CONTROL | MOD_NOREPEAT, 0x31);  //0x42 is 'b'
            if (re4s == false) MessageBox.Show("RegisterHotKey failed re2s");

            //bool re45s = RegisterHotKey(h.Handle, 1, MOD_CONTROL | MOD_NOREPEAT, 48);  //0x42 is 'b'
            //if (re45s == false) MessageBox.Show("RegisterHotKey failed re2s");
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

using DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    /// <summary>
    /// Логика взаимодействия для Window_ManagementProfile.xaml
    /// </summary>
    /// 


    public partial class Window_ManagementProfile : Window
    {
        public class TablesTest
        {           
            public Test test { get; set; }
            public int Count { get { return test.Quests.Count(); } }
            public string Open { get; set; } = "Открыть";
            public string Delete { get; set; } = "Удалить";         
        }
      
   
        public Window_ManagementProfile()
        {
            InitializeComponent();
            Loaded += Window_ManagementProfile_Loaded;
        }
        ObservableCollection<TablesTest> tablesTest = new ObservableCollection<TablesTest>();
        private void Window_ManagementProfile_Loaded(object sender, RoutedEventArgs e)
        {
            Button_Back.Visibility = Visibility.Collapsed;// кнопка не видна       
            Button_Сhange.Visibility = Visibility.Collapsed;// кнопка не видна     
            if (ProfBox.profile == null) return;
            Title = "Управление профилем [" + ProfBox.profile.Name + "]";
            TextBox_ProfileName.Text = ProfBox.profile.Name;
            ResetTablesDV();
        }

        /*Перерисовка таблицы*/
        private void ResetTablesDV()
        {
            if (ProfBox.profile == null) return;
            ProfBox.profile.Refresh();
  
            Tables_TestBox.ItemsSource = null; //сборс
            tablesTest = new ObservableCollection<TablesTest>();
            foreach (Test testP in ProfBox.profile.Tests)
            {
                tablesTest.Add(new TablesTest { test = testP, /*Id = testP.Id, GroupName = testP.Group, TestName = testP.Name, Count = testP.Quests.Count()*/});
            }        
            Tables_TestBox.ItemsSource = tablesTest;
            Tables_TestBox.Items.Refresh();
        }

        /*Двойное нажатие на строчку в таблице*/
        public long testId = -1;
        private void Tables_TestBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int selectedColumn = Tables_TestBox.CurrentCell.Column.DisplayIndex; //индеск колонки
            //if (selectedColumn == 1 || selectedColumn == 2) return;
            var nameColumn = Tables_TestBox.CurrentCell.Column.Header.ToString();
            //if (nameColumn == "Открыть") {}

            if (nameColumn == "Удалить")
            {
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                ProfBox.DeleteTestAt(customer.test.Id);
                ResetTablesDV();
            }
            else
            {
                /*Если не удалить то открыть тест*/
                var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                testId = customer.test.Id;
                DialogResult = true; //диалог закончен выбором 
            }
        }

        /*Добавление нового теста*/
        private void Button_AddNewTest_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_GroupName.Text == "" || TextBox_TestName.Text == "")
            {
                MessageBox.Show("Не указанно название группы или название теста!");
                return;
            }
            ProfBox.CreateNewTest(TextBox_GroupName.Text, TextBox_TestName.Text);   //добавить   
            ResetTablesDV(); //обновить таблицу
        }
        /*Кнопка изменить вопрос*/
        private void Button_Сhange_Click(object sender, RoutedEventArgs e)
        {
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem;

            var a1 = customer.test.Group;
            var a = customer.test.Name;

            

            BackSelect();
            ProfBox.CreateNewTest(TextBox_GroupName.Text, TextBox_TestName.Text);   //добавить   
            ResetTablesDV(); //обновить таблицу
        }

        /*Кнопка что бы убрать все выделения*/
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            BackSelect();
        }

        private void BackSelect()
        {
            /*Отмена выделения*/
            Tables_TestBox.SelectedItem = null;
            TextBox_GroupName.Text = "";
            TextBox_TestName.Text = "";
            Button_Back.Visibility = Visibility.Collapsed;// кнопка не видна       
            Button_Сhange.Visibility = Visibility.Collapsed;// кнопка не видна     
            Button_AddNewTest.Visibility = Visibility.Visible;// кнопка не видна     
        }



        /*Cобытие выбора строки*/
        private void Tables_TestBox_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Button_Back.Visibility = Visibility.Visible;// кнопка не видна       
            Button_Сhange.Visibility = Visibility.Visible;// кнопка не видна     
            Button_AddNewTest.Visibility = Visibility.Collapsed;// кнопка не видна     


            // var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
           // MessageBox.Show("Изменен объект: " + customer.test.Group.ToString() + " " + customer.test.Name.ToString());

            if(Tables_TestBox.SelectedItem != null) {
                TextBox_GroupName.Text = ((TablesTest)Tables_TestBox.SelectedItem).test.Group;
                TextBox_TestName.Text = ((TablesTest)Tables_TestBox.SelectedItem).test.Name;
            }
        }










        /*Метод вызвающийся при каждом изменении имени*/
        private void TextBox_ProfileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Title = "Управление профилем [" + TextBox_ProfileName.Text + "]";
        }
        /*Форма закрывается изменения сохраняются*/
        private void Form_Closing(object sender, EventArgs e)
        {
            if (ProfBox.profile != null)
            {
                ProfBox.profile.Name = TextBox_ProfileName.Text;
                ProfBox.SaveToChangeDB();                
            }
        }


        /*Кнопка - Удалить профиль*/
        private void Button_DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfBox.DeleteProfileAt();
            DialogResult = false;
        }
        /*Кнопка  - смена пароля */
        private void Button_NewPassword_Click(object sender, RoutedEventArgs e)
        {
            new Window_NewPassword().ShowDialog();
        }

        /*Событие после изменения таблицы*/
        int currentIndex = -1;
        private void Tables_TestBox_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            /*
             При завершении редактирования изменение не фиксируется, но фиксируется после еще одного изменения разобратся почему так!!!
             
             */
            int numRow = e.Row.GetIndex();
            currentIndex = e.Row.GetIndex();
            TablesTest customer1 = (TablesTest)e.Row.Item;
            MessageBox.Show("Изменен объект: " + customer1.test.Group.ToString() + " " + customer1.test.Name.ToString());

            var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
            MessageBox.Show("Изменен объект: " + customer.test.Group.ToString() + " " + customer.test.Name.ToString());
            //var tests = ProfBox.profile.Tests;
            foreach (var test in ProfBox.profile.Tests)
            {
                if(test.Id == customer.test.Id)
                {
                    test.Group = customer.test.Group;
                    test.Name = customer.test.Name;
                    break;
                }
            }

            //MessageBox.Show("Изменен объект: " + customer.test.Id.ToString());
        }

        private void Tables_TestBox_CurrentCellChanged(object sender, EventArgs e)
        {
           


            TablesTest customer1 = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
            MessageBox.Show("Изменен объект: " + customer1.test.Group.ToString() + " " + customer1.test.Name.ToString());

            var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
            MessageBox.Show("Изменен объект: " + customer.test.Group.ToString() + " " + customer.test.Name.ToString());
        }

        private void Tables_TestBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //int numRow = e.Row.GetIndex();
            //TablesTest customer1 = (TablesTest)e.Row.Item;
            //MessageBox.Show("Изменен объект: " + customer1.test.Group.ToString() + " " + customer1.test.Name.ToString());

            var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
            MessageBox.Show("Изменен объект: " + customer.test.Group.ToString() + " " + customer.test.Name.ToString());
        }

        private void Tables_TestBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {


            var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
            MessageBox.Show("Изменен объект: " + customer.test.Group.ToString() + " " + customer.test.Name.ToString());
        }

        private void Tables_TestBox_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
            TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
            MessageBox.Show("Изменен TargetUpdated: " + customer.test.Group.ToString() + " " + customer.test.Name.ToString());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        /*Нажатие правой клавишей миши*/
        private void Tables_TestBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Правая");
        }


        /*Нажатие правой на элетмет*/
        private void Tables_TestBox_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Правая на элемент");
        }  
    }

 
}


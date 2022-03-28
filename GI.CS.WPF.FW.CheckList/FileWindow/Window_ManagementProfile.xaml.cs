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
            public string Delete { get; set; } = "     [X]";         
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
            customer.test.Group = TextBox_GroupName.Text;
            customer.test.Name = TextBox_TestName.Text;
            ProfBox.ChangeTestName(customer.test);

            BackSelect(); //сборсить выделение таблицы      
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

    }


}


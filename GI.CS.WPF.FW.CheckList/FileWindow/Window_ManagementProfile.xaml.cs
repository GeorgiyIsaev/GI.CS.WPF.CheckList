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
           
            //public long Id { get; set; }
            //public string GroupName { get; set; }
            //public string TestName { get; set; }
            public int Count { get { return test.Quests.Count(); } }
            public string Open { get; set; } = "Открыть";
            public string Delete { get; set; } = "Удалить";
            public Test test { get; set; }
        }
      


        public Window_ManagementProfile()
        {
            InitializeComponent();
            Loaded += Window_ManagementProfile_Loaded;
        }
        ObservableCollection<TablesTest> tablesTest = new ObservableCollection<TablesTest>();
        private void Window_ManagementProfile_Loaded(object sender, RoutedEventArgs e)
        {
            if (ProfBox.profile == null) return;
            Title = "Управление профилем [" + ProfBox.profile.Name + "]";
            TextBox_ProfileName.Text = ProfBox.profile.Name;
            ResetTablesDV();


        }

        private void ResetTablesDV()
        {
           
            //if (ProfBox.profile == null) return;
            //ProfBox.ReConnect();
            if (ProfBox.profile == null) return;
            ProfBox.profile.Refresh();
            //ProfBox.ReConnect();
            Tables_TestBox.ItemsSource = null; //сборс
            tablesTest = new ObservableCollection<TablesTest>();
            foreach (Test testP in ProfBox.profile.Tests)
            {
                tablesTest.Add(new TablesTest { test = testP, /*Id = testP.Id, GroupName = testP.Group, TestName = testP.Name, Count = testP.Quests.Count()*/});
            }        
            Tables_TestBox.ItemsSource = tablesTest;
            Tables_TestBox.Items.Refresh();
        }

        private void ResetDBChange()
        {

            if (ProfBox.profile == null) return;
            ProfBox.ReConnect();
            if (ProfBox.profile == null) return;
            ProfBox.profile.Refresh();

            //foreach (TablesTest test in tablesTest)
            //{
            //    Test d = test.test;
            //    ((List<Test>)(ProfBox.profile.Tests)).Find(test.test);

            //}



            //foreach (var test in ProfBox.profile.Tests)
            //{
            //    tablesTest.


            //    test

            //    if (test.Id = tablesTest.Find(test.Id)
            //}

            //    //ProfBox.ReConnect();
            //    Tables_TestBox.ItemsSource = null; //сборс
            //tablesTest = new List<TablesTest>();
            //foreach (var test in ProfBox.profile.Tests)
            //{
            //    tablesTest.Add(new TablesTest { Id = test.Id, GroupName = test.Group, TestName = test.Name, Count = test.Quests.Count() });
            //}
            //Tables_TestBox.ItemsSource = tablesTest;
            //Tables_TestBox.Items.Refresh();
        }



        /*Удаляем тест по ID*/
        private void DeleteTestID(long ID)
        {
            if (ProfBox.profile == null) return;
            DataBase.Tables.Test findTest = null;
            foreach (var test in ProfBox.profile.Tests)
            {
                if (ID == test.Id)
                {
                    findTest = test;
                    break;
                }
            }
            if (findTest != null)
            {
                ProfBox.profile.Tests.Remove(findTest);
                ProfBox.SaveToChangeDB();
            }
           // ProfBox.ReConnect();
        }







        private void Tables_TestBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int selectedColumn = Tables_TestBox.CurrentCell.Column.DisplayIndex; //индеск колонки
            //if (selectedColumn == 1 || selectedColumn == 2) return;
            var nameColumn = Tables_TestBox.CurrentCell.Column.Header.ToString();
            if (nameColumn == "Открыть")
            {
                var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                ProfBox.TestRefresh(customer.test.Id);
                DialogResult = true; //диалог закончен выбором

              //  MessageBox.Show("Открыт объект: " + customer.test.Id.ToString());
       



            }
            if (nameColumn == "Удалить")
            {
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                ProfBox.DeleteTestAt(customer.test.Id);

               // DeleteTestID(customer.Id);
                ResetTablesDV();
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


        /*Удалить профиль*/
        private void Button_DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfBox.DeleteProfileAt();
            DialogResult = false;
        }

        private void Button_NewPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        /*Событие после изменения таблицы*/
        private void Tables_TestBox_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            /*
             При завершении редактирования изменение не фиксируется, но фиксируется после еще одного изменения разобратся почему так!!!
             
             */



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
    }

 
}


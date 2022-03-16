using System;
using System.Collections.Generic;
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
    public static class TablesExtensions
    {
        public static string Open(this DataBase.Tables.Test test)
        {
           return "Открыть";
        }
        public static string Delete(this DataBase.Tables.Test test)
        {
            return "Удалить";
        }

        public static void Refresh(this ICollection<DataBase.Tables.Test> tests)
        {

            // ProfBox.profile.Tests.
        }

    }


    public partial class Window_ManagementProfile : Window
    {
        public class TablesTest
        {
           
            public long Id { get; set; }
            public string GroupName { get; set; }
            public string TestName { get; set; }
            public int Count { get; set; }
            public string Open { get; set; } = "Открыть";
            public string Delete { get; set; } = "Удалить";
        }
      


        public Window_ManagementProfile()
        {
            InitializeComponent();
            Loaded += Window_ManagementProfile_Loaded;
        }
        List<TablesTest> tablesTest = new List<TablesTest>();
        private void Window_ManagementProfile_Loaded(object sender, RoutedEventArgs e)
        {
            if (ProfBox.profile == null) return;
            Title = "Управление профилем [" + ProfBox.profile.Name + "]";
            TextBox_ProfileName.Text = ProfBox.profile.Name;
            ResetTablesDV();
        }

        private void ResetTablesDV()
        {
            if (ProfBox.profile == null) return;
            foreach (var test in ProfBox.profile.Tests)
            {
                tablesTest.Add(new TablesTest { Id = test.Id, GroupName = test.Group, TestName = test.Name, Count = test.Quests.Count() });
            }
            Tables_TestBox.ItemsSource = tablesTest;

            Tables_TestBox.ItemsSource = null;
            Tables_TestBox.ItemsSource = tablesTest;
            Tables_TestBox.Items.Refresh();
        }
        private void DeleteTestID(long ID)
        {
            if (ProfBox.profile == null) return;
            DataBase.Tables.Test findTest = null;
            foreach (var test in ProfBox.profile.Tests)
            {
                if(ID == test.Id)
                    findTest = test;
            }
            if (findTest != null)
               ProfBox.profile.Tests.Remove(findTest);
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
                MessageBox.Show("Открыт объект: " + customer.Id.ToString());
            }
            if (nameColumn == "Удалить")
            {
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                DeleteTestID(customer.Id);
                ResetTablesDV();



                //tablesTest.Remove(customer);

                //tablesTest.Add(new TablesTest { No = 99, GroupName = TextBox_GroupName.Text, TestName = TextBox_TestName.Text, Count = 0 });
                //Tables_TestBox.ItemsSource = tablesTest;
//  Tables_TestBox.ItemsSource = null;
            //    Tables_TestBox.ItemsSource = tablesTest;
           //     Tables_TestBox.Items.Refresh();



                // MessageBox.Show("customer: " + customer.No.ToString());
            }

        }

        private void Button_AddNewTest_Click(object sender, RoutedEventArgs e)
        {
            var a = TextBox_GroupName.Text;
            var b = TextBox_TestName.Text;
            if (TextBox_GroupName.Text == "" || TextBox_TestName.Text == "")
            {
                MessageBox.Show("Не указанно название группы или название теста!");
                return;
            }
            ProfBox.profile.Tests.Add(new DataBase.Tables.Test() { Group = TextBox_GroupName.Text, Name = TextBox_TestName.Text });
            ProfBox.SaveToDB();
            ResetTablesDV();

            // tablesTest.Add(new TablesTest { No = 99, GroupName = TextBox_GroupName.Text, TestName = TextBox_TestName.Text, Count = 0 });

            Tables_TestBox.ItemsSource = null;
            Tables_TestBox.ItemsSource = tablesTest;
            Tables_TestBox.Items.Refresh();

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
                ProfBox.SaveToDB();                
            }
        }

    }

 
}


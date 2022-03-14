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

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    /// <summary>
    /// Логика взаимодействия для Window_ManagementProfile.xaml
    /// </summary>
    public partial class Window_ManagementProfile : Window
    {
        public class TablesTest
        {
            public int No { get; set; }
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
            int count = 0; 
            for(int i = 0; i<3; i++)
            {
                string groupName = "Группа " + i;
                for (int j = 0; j < 3; j++)
                {
                    string name = "Тест " + j;
                    tablesTest.Add(new TablesTest { No = count++, GroupName=groupName,TestName=name,Count=20 });
                }
            }
            Tables_TestBox.ItemsSource = tablesTest;
        }

        private void Tables_TestBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {     
            //int selectedColumn = Tables_TestBox.CurrentCell.Column.DisplayIndex; //индеск колонки
            //if (selectedColumn == 1 || selectedColumn == 2) return;

            var nameColumn = Tables_TestBox.CurrentCell.Column.Header.ToString();
            if(nameColumn == "Открыть")
            {
                var indexSelect = Tables_TestBox.SelectedIndex; //индекс строки
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                MessageBox.Show("Открыт объект: " + customer.No.ToString());
            }
            if (nameColumn == "Удалить")
            {
                TablesTest customer = (TablesTest)Tables_TestBox.SelectedItem; //Получиль объект из таблицы
                tablesTest.Remove(customer);

                //tablesTest.Add(new TablesTest { No = 99, GroupName = TextBox_GroupName.Text, TestName = TextBox_TestName.Text, Count = 0 });
                //Tables_TestBox.ItemsSource = tablesTest;
                Tables_TestBox.Items.Refresh();



                MessageBox.Show("customer: " + customer.No.ToString());
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
            tablesTest.Add(new TablesTest { No = 99, GroupName = TextBox_GroupName.Text, TestName = TextBox_TestName.Text, Count = 0 });
            Tables_TestBox.ItemsSource = tablesTest;
            Tables_TestBox.Items.Refresh(); 

        }
    }
}

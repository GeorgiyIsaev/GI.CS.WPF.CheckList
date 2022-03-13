using System;
using System.Collections.Generic;
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

        }

 
        public Window_ManagementProfile()
        {
            InitializeComponent();
            Loaded += Window_ManagementProfile_Loaded;


        }

        private void Window_ManagementProfile_Loaded(object sender, RoutedEventArgs e)
        {
            List<TablesTest> tablesTest = new List<TablesTest>();
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
    }
}

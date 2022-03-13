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
            public string Btn { get; set; } = "Изменить";
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

        private void Tables_TestBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var nameColumn = Tables_TestBox.CurrentCell.Column.Header.ToString();
            if (nameColumn == "Группа" || nameColumn == "Название Теста") return;
            /*Получаем индекс и столбец*/
            var d = Tables_TestBox.SelectedIndex;

            DataRowView rowView = Tables_TestBox.SelectedValue as DataRowView;

            //int index= Tables_TestBox.CurrentCell.Column.Header.ToString();
      


            int selectedColumn = Tables_TestBox.CurrentCell.Column.DisplayIndex;
            var selectedCell = Tables_TestBox.SelectedCells[selectedColumn];
            var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);

            MessageBox.Show("selectedColumn " + selectedColumn + " \nselectedCell " + selectedCell + " \ncellContent "+ cellContent);

            if (cellContent is TextBlock)
            {
                MessageBox.Show((cellContent as TextBlock).Text);
            }

         
            MessageBox.Show("Нажатие на таблицу " + d + " " + 0 + " " );


            var row = (DataGridRow)Tables_TestBox.ItemContainerGenerator.ContainerFromIndex(d);

            var rowp = (TablesTest)row;
            MessageBox.Show("row " + row + " \n rowp" + rowp + " ");
        }

   
    }
}

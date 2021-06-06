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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для PageColorHTML.xaml
    /// </summary>
    public partial class PageColorHTML : Page
    {
        public PageColorHTML()
        {
            InitializeComponent();
            CreateComboBox_FontSize();
            StandartStileButton();

        }
        private void CreateComboBox_FontSize()
        {
            for (int i = 8; i < 30; i += 2)
            {              
                ComboBox_FontSize_Head.Items.Add(i);
            }           
        }
        private void StandartStileButton()
        {

            Button_head_G.IsChecked = true;
            Button_head_I.IsChecked = false;
            Button_head_Z.IsChecked = true;
            ComboBox_FontSize_Head.SelectedIndex = 4;
        }
        private void ButtonClick_CSS(object sender, RoutedEventArgs e)
        {
            TBCSS_head.FontWeight = (Button_head_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            TBCSS_head.FontStyle = (Button_head_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            TBCSS_head.TextDecorations = (Button_head_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;
        }
        private void SelectionChanged_FontSize(object sender, SelectionChangedEventArgs e)
        {
            TBCSS_head.FontSize = Convert.ToInt32(ComboBox_FontSize_Head.SelectedValue.ToString());
        }


    }

}

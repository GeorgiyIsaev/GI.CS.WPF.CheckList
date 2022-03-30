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

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    /// <summary>
    /// Логика взаимодействия для UserControl_CSSInit.xaml
    /// </summary>
    public partial class UserControl_CSSInit : UserControl
    {
        public UserControl_CSSInit()
        {
            InitializeComponent();
            Loaded += Windows_Loaded;


        }
        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            CreateComboBox_FontSize(); //запалнение шрифтов
           // FontStyleInit();
          //  ColorPickerInitialize();
        }


        private void CreateComboBox_FontSize()
        {
            for (int i = 6; i < 42; i += 2)
            {
                ComboBox_FontSize.Items.Add(i);
            }
            StandartStileButton();
        }
        private void StandartStileButton()
        {

            Button_G.IsChecked = true;
            Button_Z.IsChecked = true;
            Button_I.IsChecked = true;

            int baseSize = 5;
            ComboBox_FontSize.SelectedIndex = baseSize;
        }






        /*Нажатие на Ж К З*/
        private void ButtonClick_CSS(object sender, RoutedEventArgs e)
        {

        }

        /*Выбор шрифта*/
        private void SelectionChanged_FontSize(object sender, SelectionChangedEventArgs e)
        {
          
        }

        /*Выбор Цвета*/
        private void ColorPicker_ColorInitialize(object sender, MouseEventArgs e)
        {
           
        }
    }
}

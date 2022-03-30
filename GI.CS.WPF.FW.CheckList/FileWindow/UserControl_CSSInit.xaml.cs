using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                                       // DefaultCSS();

            //widthTitle = 190;
        }

      


        private void CreateComboBox_FontSize()
        {
            for (int i = 6; i < 42; i += 2)       
                ComboBox_FontSize.Items.Add(i);                
        }
        private void DefaultCSS()
        {
            Button_G.IsChecked = false;
            Button_Z.IsChecked = false;
            Button_I.IsChecked = false;
            int baseSize = 5;
            ComboBox_FontSize.SelectedIndex = baseSize;
            ColorPickerInit.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");
        }

        /*Метод для заполнения состояния из вне*/
        public void InitCSS(bool bold, bool crossed, bool italic, int fontSize)
        {
            Button_G.IsChecked = bold;
            Button_Z.IsChecked = crossed;
            Button_I.IsChecked = italic;

            if(fontSize >=6 && fontSize <= 42)
            {
                int index = fontSize  - 6;
                index = index / 2;
                ComboBox_FontSize.SelectedIndex = index;
            }              
        }
        public void InitCSSColor(String colorCode)
        {
            colorCode = colorCode.Substring(1);
            colorCode = "#ff" + colorCode;
            try
            {
                ColorPickerInit.SelectedColor = (Color?)ColorConverter.ConvertFromString(colorCode);
            }
            catch { }
        }
        public void InitCSS(CCSFont ccsFont)
        {     
            InitCSS(ccsFont.Bold, ccsFont.Strike, ccsFont.Italics, ccsFont.SizeFront);
            InitCSSColor(ccsFont.Color);
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




        /*Свовства*/
        [DisplayName(@"TextTitle"), Description("Тектс заголовка"), Category("New"), DefaultValue(false)]
        public string TextTitle
        {
            get
            {
                return TextContorl.Text;
            }
            set
            {
                TextContorl.Text = value;
            }
        }

       // public double widthTitle { get; set; } = 170;
        [DisplayName(@"WidthTitle"), Description("Ширина заголовка"), Category("New"), DefaultValue(false)]
        public GridLength WidthTitle
        {
            get
            {     
                return TitleColumn.Width; 
            }
            set
            {
                TitleColumn.Width = value;
            }
        }



    }
}

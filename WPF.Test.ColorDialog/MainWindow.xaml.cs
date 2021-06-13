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


using System.ComponentModel;
using PropertyTools.Wpf;
//using System.Windows.Media;


namespace WPF.Test.ColorDialog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Color color1;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));

            }
        }

        public Color Color1
        {
            get
            {
                MessageBox.Show("");
                return this.color1;
            }

            set
            {
                this.color1 = value;
                this.RaisePropertyChanged("Color1");
                MessageBox.Show(this.ToString());

            }
        }

        private void ButtonColorDialog_test1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Color.Text = "13";
            Color? color = ButtonColorDialog_test1.SelectedColor;

            MessageBox.Show(color.ToString());



            //TextBox_Color.Text = ButtonColorDialog_test1.SelectedColor.ToString();
        }

        private void ButtonColorDialog_test1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox_Color.Text = "22";
            Color? color = ButtonColorDialog_test1.SelectedColor;
            if (color != null)
            {
                MessageBox.Show(color.ToString());
            }
        }
        public SolidColorBrush Brush { get; set; }



        private void ButtonColorDialog_test1_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox_Color.Text = "33";
            Color? color = ButtonColorDialog_test1.SelectedColor;
            if (color != null)
            {
                MessageBox.Show(color.ToString());
            }
        }

        private void ButtonColorDialog_test1_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            TextBox_Color.Text = "36";
            Color? color = ButtonColorDialog_test1.SelectedColor;
            if (color != null)
            {
                MessageBox.Show(color.ToString());
            }
            // ButtonColorDialog_test1.SourceUpdated
        }

        private void ButtonColorDialog_test1_Selected(object sender, RoutedEventArgs e)
        {
            TextBox_Color.Text = "37";
        }

        private void ButtonColorDialog_test1_ContextMenuClosing_1(object sender, ContextMenuEventArgs e)
        {
            TextBox_Color.Text = "38";
        }

        private void ButtonColorDialog_test1_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBox_Color.Text = "39";
            Color? color = ButtonColorDialog_test1.SelectedColor;
            if (color != null)
            {
                // MessageBox.Show(color.ToString());
            }
            TextBox_Color.Text = color.ToString();
            Color colorIR5 = (Color)ColorConverter.ConvertFromString("#ffaabbcc");
            SolidColorBrush brush = new SolidColorBrush(colorIR5);
            if (color.Value != null) {    
                colorIR5 = (Color)color.Value;
                brush = new SolidColorBrush(colorIR5);
                TextBox_Color.Foreground = brush;
            }        
        }

        private void ButtonColorDialog_test1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox_Color.Text = "43";
        }

        private void ButtonColorDialog_test1_Initialized(object sender, EventArgs e)
        {
            TextBox_Color.Text = "44";
        }

        private void ButtonColorDialog_test1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Color.Text = "45";
        }

        private void ButtonColorDialog_test1_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            TextBox_Color.Text = "46";
        }

        private void ColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Color.Text = "47";
        }

        private void ButtonColorDialog_test1_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            TextBox_Color.Text = "48";
        }

        private void ButtonColorDialog_test1_StylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            TextBox_Color.Text = "49";
        }

        private void ButtonColorDialog_test1_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
            TextBox_Color.Text = "50";
        }

        private void ButtonColorDialog_test1_TouchDown(object sender, TouchEventArgs e)
        {
            TextBox_Color.Text = "51";
        }

        private void ButtonColorDialog_test1_TouchLeave(object sender, TouchEventArgs e)
        {
            TextBox_Color.Text = "52";
        }

        private void ButtonColorDialog_test1_StylusUp(object sender, StylusEventArgs e)
        {
            TextBox_Color.Text = "53";
        }

        private void ButtonColorDialog_test1_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox_Color.Text = "54";
        }

        private void ButtonColorDialog_test1_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TextBox_Color.Text = "55";
        }

        private void ButtonColorDialog_test1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonColorDialog_test1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox_Color.Text = "57";
        }

        private void ButtonColorDialog_test1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox_Color.Text = "58";
        }

        private void ButtonColorDialog_test1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox_Color.Text = "59";
        }

        private void ButtonColorDialog_test1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox_Color.Text = "60";
        }

        private void ButtonColorDialog_test1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TextBox_Color.Text = "61";
        }

        private void ButtonColorDialog_test1_MouseMove(object sender, MouseEventArgs e)
        {
            //TextBox_Color.Text = "62";
            // при любом навдениеии хуже чем при уберании
        }

        private void ButtonColorDialog_test1_MouseEnter_1(object sender, MouseEventArgs e)
        {
            TextBox_Color.Text = "63";
        }

        private void ButtonColorDialog_test1_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            TextBox_Color.Text = "64";
        }

    }
}

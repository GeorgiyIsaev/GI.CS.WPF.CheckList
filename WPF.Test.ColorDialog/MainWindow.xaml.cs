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
//using System.Windows.Media;
using PropertyTools.Wpf;

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
                MessageBox.Show(color.ToString());
            }           
        }

        private void ButtonColorDialog_test1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox_Color.Text = "43";
        }
    }
}

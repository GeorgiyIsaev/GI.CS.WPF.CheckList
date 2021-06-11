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
                return this.color1;
            }

            set
            {
                this.color1 = value;
                this.RaisePropertyChanged("Color1");


               // TextBox_Color.Text = Convert.ToString(this.color1);
            }
        }

        private void ButtonColorDialog_test1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Color.Text = "13";
            Color? color = ButtonColorDialog_test1.SelectedColor;

            //TextBox_Color.Text = ButtonColorDialog_test1.SelectedColor.ToString();
        }
    }
}

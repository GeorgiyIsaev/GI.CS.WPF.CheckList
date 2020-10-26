using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace WPF_TestElement
{
    public partial class MainWindow : Window
    {    
        private ObservableCollection<MyModel> _models = new ObservableCollection<MyModel>();

        public MainWindow()
        {
            InitializeComponent();
            Models.Add(new MyModel { tName = "Test", Description = "Hello" });
            Models.Add(new MyModel { tName = "Test2", Description = "Hello2" });
            Models.Add(new MyModel { tName = "Test3", Description = "Hello3" }); 
        }

        public ObservableCollection<MyModel> Models
        {
            get { return _models; }
            set { _models = value; }
        }
    }

    public class MyModel// :  INotifyCollectionChanged
    {
        private string _tName;
        private string _description;

        public string tName
        {
            get { return _tName; }
            set { _tName = value; NotifyPropertyChanged("tName"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged("Description"); }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

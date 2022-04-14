using System.Windows;


namespace MyTestCopy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_LoadedKeyPaste;   
        }
        private void AddTextBox(string text)
        {
            if (TB.Text != "") TB.Text += "\n";
            TB.Text += text;
        }
        public void Window_LoadedKeyPaste(object sender, RoutedEventArgs e)
        {
            CopyCtrl.AddTextEvent += AddTextBox;    
            CopyCtrl.Window_LoadedKeyQ(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_CheckListQuests
{
    /// <summary>
    /// Логика взаимодействия для Windows_HTNLSetup.xaml
    /// </summary>
    public partial class Windows_Load : Window
    {
        public Windows_Load()
        {
            InitializeComponent();
            Loaded += Windows_HTNLSetup_Loaded;
        }

        private void Windows_HTNLSetup_Loaded(object sender, RoutedEventArgs e)
        {
             TextBlock_Directori.Text = Directory.GetCurrentDirectory();
            inputElementWindow();
        } 
        
        void inputElementWindow()
        {     
            ListBox_FileMenedger.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(TextBlock_Directori.Text);

            ListBox_FileMenedger.Items.Add("<--");
            //string PathFolder1 = Path.GetDirectoryName(PathFolder2);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo crrDir in dirs)
            {
                ListBox_FileMenedger.Items.Add(crrDir.Name);
            }


            FileInfo[] filesTXT = dir.GetFiles("**.txt");
            foreach (FileInfo crrDir in filesTXT)
            {
                ListBox_FileMenedger.Items.Add(crrDir.Name);
            }

            FileInfo[] filesHTML = dir.GetFiles("**.html");
            foreach (FileInfo crrDir in filesHTML)
            {
                ListBox_FileMenedger.Items.Add(crrDir.Name);
            }

        }


       

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            string namefile = nameFile.Text;
            if (nameFile.Text == "") { MessageBox.Show("Не указано имя файла"); return; }

            if (!System.IO.File.Exists(nameFile.Text))
            {
                MessageBox.Show($"Файл {nameFile.Text} не обнаружен!");
                return;
            }


            if (nameFile.Text.LastIndexOf(".txt") > -1) {
                int count = QuestsBox.file_readTXT(nameFile.Text);
                MessageBox.Show($"Добавлено {count} вопросов.");
            }
            else if (nameFile.Text.LastIndexOf(".html") > -1)
            {
                int count = HTMLEdition.readHTML(nameFile.Text);
                MessageBox.Show($"Добавлено {count} вопросов.");
            }
            else {
                MessageBox.Show($"Указан не читаемый формат (Допустимы файлы .txt и .html)");
            }  
        }

        private void ListBox_FileMenedger_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox_FileMenedger.SelectedIndex == 0)
            {
                TextBlock_Directori.Text = Directory.GetParent(TextBlock_Directori.Text).FullName;
                inputElementWindow();
            }
            else if (true)
            {
                TextBlock_Directori.Text += ListBox_FileMenedger.SelectedItems.ToString();
            }
            
            
         
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
           
        } 
        
       

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            string namefile = nameFile.Text;
            if (nameFile.Text == "") { MessageBox.Show("Не указано имя файла"); return; }

            if (!System.IO.File.Exists(nameFile.Text))            
                MessageBox.Show($"Файл {nameFile.Text} не обнаружен!");


            int count = HTMLEdition.readHTML(nameFile.Text);
            MessageBox.Show($"Добавлено {count} вопросов.");

        }
      
 
    }
}

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
    public partial class Windows_HTNLSetup : Window
    {
        public Windows_HTNLSetup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameFile.Text=="") { MessageBox.Show("Должно быть указано имя файла"); return; }

            HTMLEdition.bilderHTML(nameFile.Text);

            var result = MessageBox.Show($"Файл {nameFile.Text}.html успешно создан\n Хотите открыть файл?", 
                "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string forever_papka = Environment.CurrentDirectory + "\\" + nameFile.Text + ".html";         
                System.Diagnostics.Process.Start("explorer", forever_papka);
            }  
        }
    }
}

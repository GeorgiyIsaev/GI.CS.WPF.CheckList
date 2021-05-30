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

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для Windows_HTNLSetup.xaml
    /// </summary>
    public partial class Windows_HTNLSetup : Window
    {
        public Windows_HTNLSetup()
        {
            InitializeComponent();
            Loaded += Windows_HTNLSetup_Loaded;
        }

        private void Windows_HTNLSetup_Loaded(object sender, RoutedEventArgs e)
        {
            CreateComboBox_FontSize();
        } 
        
        private void CreateComboBox_FontSize()
        {
            for(int i = 8; i<30; i+=2)
                ComboBox_FontSize.Items.Add($"Шрифт: {i}");
            ComboBox_FontSize.SelectedIndex = 4;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (nameFile.Text=="") { MessageBox.Show("Должно быть указано имя файла"); return; }
            if (input_header.Text == "") { MessageBox.Show("Не указан заголовок для чек-листа"); return; }
            setupHTML();


            EditionHTML.bilderHTML(nameFile.Text);
            var result = MessageBox.Show($"Файл {nameFile.Text}.html успешно создан\n Хотите открыть файл?", 
                "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string forever_papka = Environment.CurrentDirectory + "\\" + nameFile.Text + ".html";         
                System.Diagnostics.Process.Start("explorer", forever_papka);
            }  
        }
        private void setupHTML()
        {
            EditionHTML.headerHTML = input_header.Text;
            EditionHTML.describeHTML = input_describe.Text;
            EditionHTML.signFooterHTML = input_sign.Text;
            EditionHTML.FrontSiseBody = ((ComboBox_FontSize.SelectedIndex) * 2) + 8;
            EditionHTML.deleteAnAnswerIf = CB_lineThrough.IsChecked == true;
            EditionHTML.spoilerIf = CB_spoilerIf.IsChecked == true;
        }

        private void ColorStack()
        {
           // CB_FonBack.Items
        }

      

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
    }
}

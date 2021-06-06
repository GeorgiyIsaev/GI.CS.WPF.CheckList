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
            EditionHTML.DefaultCSS(); //устанавливает css по умолчанию
            CreateComboBox_FontSize();
        } 
        
        private void CreateComboBox_FontSize()
        {
            for (int i = 8; i < 30; i += 2)
            {
                ComboBox_FontSize.Items.Add($"Шрифт: {i}");
                ComboBox_FontSize_Head.Items.Add($" {i} ");
            }
            ComboBox_FontSize.SelectedIndex = 4;
        }
        private void StandartStileButton()
        {
            Button_head_G.Background. 
                Button_head_I 
                Button_head_Z
            ComboBox_FontSize_Head.SelectedIndex = 4;
        }
       



        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            input_header.Background = Brushes.White;
            nameFile.Background = Brushes.White;
            string nameANDformat = nameFile.Text;
            if (nameFile.Text == "") {   
                nameFile.Background = Brushes.Yellow;
                MessageBox.Show("Необходимо указать имя для сохраняемого файла"); return; 
            }
            if (ComboBox_FormatSave.SelectedIndex == 0)
            {               
                if (input_header.Text == "") {
                    input_header.Background = Brushes.Yellow;
                    MessageBox.Show("Не указан заголовок для HTML чек-листа"); return; }
                nameANDformat += ".html";
                setupHTML();
                EditionHTML.bilderHTML(nameANDformat);
            }
            else if(ComboBox_FormatSave.SelectedIndex == 1)
            {
                nameANDformat += ".txt";
                EditionTXT.WriteInTXT(nameANDformat);
            }
            else if (ComboBox_FormatSave.SelectedIndex == 2)
            {       
                nameANDformat += ".json";
                EditionJson.WriteJSON(nameANDformat, (bool)CB_spoilerIf.IsChecked, (bool)CB_lineThrough.IsChecked);
            }

            var result = MessageBox.Show($"Файл {nameANDformat} успешно создан\n Хотите открыть файл?", 
                "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string forever_papka = Environment.CurrentDirectory + "\\" + nameANDformat;         
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

        private void ComboBox_FormatSave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_FormatSave.SelectedIndex)
            {
                case 0:
                    WinIsEnabled();
                    break;
                case 1:
                    WinIsEnabled(false);                
                    break;
                case 2:
                    WinIsEnabled(false,true);                
                    break;
            }
        }

        private void WinIsEnabled(bool ifnow = true, bool ifJson = false)
        {
            TabControl_Edition.SelectedIndex = 0;
            Board_Base.IsEnabled = ifnow;
            Board_Coolor.IsEnabled = ifnow;
            input_header.IsEnabled = ifnow;
            input_describe.IsEnabled = ifnow;
            input_sign.IsEnabled = ifnow;
            ComboBox_FontSize.IsEnabled = ifnow;            
            CB_spoilerIf.IsEnabled = ifnow || ifJson;
            CB_lineThrough.IsEnabled = ifnow || ifJson;
            if (!ifJson)
            {
                CB_spoilerIf.Content = "Скрыть пояснения под спойлер";
                CB_lineThrough.Content = "Зачеркнуть неверные ответы";
                CB_spoilerIf.ToolTip = "При использовании скроет поясения по спойлер";
                CB_lineThrough.ToolTip = "При использовании зачернет не верные ответы";
            }
            else
            {
                CB_spoilerIf.Content = "Добавить в JSON файл переносы";
                CB_lineThrough.Content = "Записать в Unicode"; //Unicode Escape-последовательности
                CB_spoilerIf.ToolTip = "При использовании в файл JSON будут добавлены пробелы и переносы!";
                CB_lineThrough.ToolTip = "При использовании файл JSON будит записан в Unicode,\n" +
                                       "по умолчанию используется Escape-последовательность";
            }

        }
    }
}

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
    public partial class Window_SaveCheckList : Window
    {
        PageColorHTML PageColorHTML;


        public Window_SaveCheckList()
        {
            InitializeComponent();
            Loaded += Windows_HTNLSetup_Loaded;

        }

        private void Windows_HTNLSetup_Loaded(object sender, RoutedEventArgs e)
        {
            EditionHTML.DefaultCSS(); //устанавливает css по умолчанию
            CreateComboBox_FontSize();
            PageColorHTML = new PageColorHTML(this);
            TabHTMLColor.Content = PageColorHTML;
        }
        private void CreateComboBox_FontSize()
        {
            for (int i = 8; i < 30; i += 2)
            {
                ComboBox_FontSize.Items.Add($"Шрифт: {i}");
            }
            ComboBox_FontSize.SelectedIndex = 4;

            ComboBox_StileCSS.Items.Add("<< Пользовательский стиль >>");
            ComboBox_StileCSS.Items.Add("Классический стиль оформления");
            ComboBox_StileCSS.SelectedIndex = 1;
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
                //if (input_header.Text == "") {
                //    input_header.Background = Brushes.Yellow;
                //    MessageBox.Show("Не указан заголовок для HTML чек-листа"); return; }
                nameANDformat += ".html";
                setupHTML();
                EditionHTML.WriteHTmlCodeToFile(nameANDformat);
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

            var result = MessageBox.Show($"Чек-Лист {nameANDformat} успешно создан\n Хотите открыть файл?", 
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
            EditionHTML.spoilerIf = CB_spoilerIf.IsChecked == false;
        }





        private void ColorStack()
        {
           // CB_FonBack.Items
        }

        private void ComboBox_FormatSave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_FormatSave.SelectedIndex)
            {
                case 0: //HTML
                    WinIsEnabled();
                    DecorationHTML();
                    break;
                case 1: //TXT
                    WinIsEnabled(false);
                    DecorationTXT();
                    break;
                case 2: //JSON
                    WinIsEnabled(false);
                    DecorationJSON();
                    break;
            }
        }
        private void DecorationHTML()
        {
            CB_lineThrough.Visibility = Visibility.Collapsed;
            ComboBox_StileCSS.Visibility = Visibility.Visible;
            CB_spoilerIf.Visibility = Visibility.Visible;
            CB_spoilerIf.IsChecked = true;
            CB_spoilerIf.Content = "Открытый спойлер";
            CB_spoilerIf.ToolTip = "Если активен: Спойлер с пояснением открыт";      
        }
        private void DecorationJSON()
        {
            CB_lineThrough.Visibility = Visibility.Visible;
            CB_spoilerIf.Visibility = Visibility.Visible;
            ComboBox_StileCSS.Visibility = Visibility.Collapsed;
   
            CB_spoilerIf.IsChecked = false;
            CB_spoilerIf.Content = "Многострочный JSON";
            CB_spoilerIf.ToolTip = "Если активен: JSON генерирует переносы строки и табуляцию";

            CB_lineThrough.Content = "Записать в Unicode"; //Unicode Escape-последовательности            
            CB_lineThrough.ToolTip = "Если активен: Cодержимое JSON в Unicode;\n" +
                                     "По умолчанию: Escape-последовательность";
        }
        private void DecorationTXT()
        {
            CB_lineThrough.Visibility = Visibility.Collapsed;
            ComboBox_StileCSS.Visibility = Visibility.Collapsed;
            CB_spoilerIf.Visibility = Visibility.Collapsed; 
        }
        private void WinIsEnabled(bool isEnabled = true)
        {
            TabControl_Edition.SelectedIndex = 0;
            Board_Base.IsEnabled = isEnabled;
            Board_Coolor.IsEnabled = isEnabled;
            input_header.IsEnabled = isEnabled;
            input_describe.IsEnabled = isEnabled;
            input_sign.IsEnabled = isEnabled;
            ComboBox_FontSize.IsEnabled = isEnabled;  
        }

        private void ComboBox_FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int siseFont = (ComboBox_FontSize.SelectedIndex * 2) + 8;
            EditionHTML.ChangeFullFontSize(siseFont);
            ComboBox_StileCSS.SelectedIndex = 0;
        }

        private void ComboBox_StileCSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_StileCSS.SelectedIndex)
            {
                case 0: 
                    //Пользовательский
                    break;
                case 1:
                    //Класический стиль
                    ComboBox_FontSize.SelectedIndex = 4;
                    //PageColorHTML = new PageColorHTML(this);
                    TabHTMLColor.Content = PageColorHTML;
                    EditionHTML.DefaultCSS();                   
                    break;
            }
        }
    }
}

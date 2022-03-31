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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для Window_DescriptionForApplication.xaml
    /// </summary>
    public partial class Window_DescriptionForApplication : Window
    {
        public Window_DescriptionForApplication()
        {
            InitializeComponent();
            Loaded += Window_DescriptionForApplication_Loaded;




        }

        private void Window_DescriptionForApplication_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock_Title.Text = "Автоматизация обработки чек-листов в системе дистанционного и самостоятельно обучения v.1.0";
            TextBlock_TitleInfo.Text = "\nПрограмма обеспечивает следующий функционал: ";

            TextBlock_info.Text =
"   1. Создание чек-листов с вопросами в виде стилистически оформленной HTML-страницы; \n" +
"   2. Создание чек-листов в иных форматах (JSON, TXT); \n" +
"   3. Хранение чек-листов с вопросами в программе виде каталогов и профилей с быстрым переключения между ними; \n" +
"   4. Редактирование профилей, каталогов и чек-листов; \n" +
"   5. Тестирование знаний пользователя на основе собранных чек-листов с предоставлением итогового результата; \n";



            TextBlock_sign.Text = " Made by georgiyelbaf\n  Copyright © 2022";
        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/GeorgiyIsaev/GI.CS.WPF.CheckList"); //открытие ссылки в браузере
        }
    }
}

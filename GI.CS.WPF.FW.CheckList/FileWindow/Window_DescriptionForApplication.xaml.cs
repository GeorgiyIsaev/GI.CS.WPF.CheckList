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

namespace GI.CS.WPF.Core.CheckList
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
            TextBlock_info.Text= "Предназначение приложения:\n\n" +
                "1. Приложение позволяет собирать вопросы и ответы в единый чек-лист в виде HTML-страницы \n"+
                "2. Приложение проверяет добавляемые вопрос на повторы\n"+
                "3. Приложение позволяет добавлять к вопросу краткое пояснение\n"+
                "4. Сохранённые HTML-чек-листы можно редактировать через приложение\n"+
                "5. Сохранённые HTML-чек-листы можно использовать для запуска активных тестов внутри приложения для проверки своих знаний";

            TextBlock_sign.Text = " Made by georgiyelbaf\n  Copyright © 2020";

        }
    }
}

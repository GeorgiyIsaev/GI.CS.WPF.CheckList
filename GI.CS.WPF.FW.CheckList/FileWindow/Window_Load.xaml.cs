﻿using System;
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

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для Windows_HTNLSetup.xaml
    /// </summary>
    public partial class Window_Load : Window
    {
        public Window_Load()
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

            try
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo crrDir in dirs)
                {
                    ListBox_FileMenedger.Items.Add(crrDir.Name);
                }


                FileInfo[] filesTXT = dir.GetFiles("**.txt");
                foreach (FileInfo crrDir in filesTXT)
                {
                    ListBox_FileMenedger.Items.Add("    " + crrDir.Name);
                }
                FileInfo[] filesHTML = dir.GetFiles("**.html");
                foreach (FileInfo crrDir in filesHTML)
                {
                    ListBox_FileMenedger.Items.Add("    " + crrDir.Name);
                }
                FileInfo[] filesJSON = dir.GetFiles("**.json");
                foreach (FileInfo crrDir in filesJSON)
                {
                    ListBox_FileMenedger.Items.Add("    " + crrDir.Name);
                }
            }
            catch { }
        }


       


        private void startFile(string fileName)
        {
            int count = 0;
            if (fileName.LastIndexOf(".txt") > -1)            
                count = EditionTXT.file_readTXT(fileName);
            else if (fileName.LastIndexOf(".html") > -1)           
                count = EditionHTML.readHTML(fileName);
            else if (fileName.LastIndexOf(".json") > -1)
                count = EditionJson.ReadJSON(fileName);

            if (count == 0)
                MessageBox.Show($"В данном файле вопросы не обнаруженны!");
            else
            {
                var result = MessageBox.Show($"Добавлено {count} вопросов.\n\n Закрыть окно?", "Успех!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    this.Close(); 
             
            }

        }
   








        private void ListBox_FileMenedger_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string fileName = ListBox_FileMenedger.SelectedItem.ToString();

            if (ListBox_FileMenedger.SelectedIndex == 0)
            {
                try
                {                    
                    TextBlock_Directori.Text = Directory.GetParent(TextBlock_Directori.Text).FullName;
                    inputElementWindow();
                }
                catch /*(NullReferenceException ex)*/ { 
                    //TODO Найти способ показать все диски
                }        
            }
            else if (fileName.LastIndexOf(".txt") > -1 || fileName.LastIndexOf(".html") > -1 || fileName.LastIndexOf(".json") > -1)
            {
                fileName = fileName.Replace("    ", "");
                startFile(TextBlock_Directori.Text + "\\" + fileName);
            }
            else
            {
                TextBlock_Directori.Text += "\\" + fileName;
                inputElementWindow();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    /// <summary>
    /// Логика взаимодействия для WindowLoginProfile.xaml
    /// </summary>
    public partial class WindowLoginProfile : Window
    {
        public WindowLoginProfile()
        {
            InitializeComponent();
            ReplaceWindow();
        }
        bool isCrateProfile = false; //состояние текущего окна
        void ReplaceWindow()
        {
            if (isCrateProfile)
            {
                Title = "Создание профиля";
                Buttun_CreateProfile.Content = "Войти в существующий";
                Buttun_EnterProfile.Content = "Создать";
                TB_Pass02i.Visibility = Visibility.Visible;
                TB_Pass02.Visibility = Visibility.Visible;
            }
            else
            {
                Title = "Войти в профиль";
                Buttun_CreateProfile.Content = "Создать новый профиль";
                Buttun_EnterProfile.Content = "Войти";
                TB_Pass02i.Visibility = Visibility.Collapsed;
                TB_Pass02.Visibility = Visibility.Collapsed;
            }
        }

        /*Кнопка для создания профилия и возврата ко входу*/
        public void Buttun_CreateProfile_Click(object sender, RoutedEventArgs e) {
            if (isCrateProfile)isCrateProfile = false;            
            else isCrateProfile = true; 
            ReplaceWindow();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string ProfileName
        {
            get { return TB_Login.Text; }
        }
        public string Password01
        {
            get { return TB_Pass01.Text; }
        }
        public string Password02
        {
            get { return TB_Pass02.Text; }
        }



        private void Buttun_EnterProfile_Click(object sender, RoutedEventArgs e)
        {
            if (ProfileName == ""){ MessageBox.Show("Не введено имя профиля");return; }
            if (Password01 == "") { MessageBox.Show("Не введен пароль"); return; }
            if (isCrateProfile)
            {
                if (Password01 == Password02) { MessageBox.Show("Пороль не совпадает"); return; }
                this.DialogResult = true;
            }
            else
            {
                /*Тут будит подключение к БД и сохранение профиля в прогу*/

                /*Пока типа два профиля*/
                if (ProfileName == "1" && Password01 == "1") {this.DialogResult = true; return; }
                if (ProfileName == "Admin" && Password01 == "Admin") {this.DialogResult = true; return; }

                MessageBox.Show("Совпадения имяни пароля не обнаружено!");
                
            }
        }
    }
  
}

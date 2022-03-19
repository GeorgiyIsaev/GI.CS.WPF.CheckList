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
using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    /// <summary>
    /// Логика взаимодействия для WindowLoginProfile.xaml
    /// </summary>
    public partial class Window_LoginProfile : Window
    {
        
        
        bool isCrateProfile = false; //состояние текущего окна
        public Window_LoginProfile(bool isCrate, String name = "")
        {
            InitializeComponent();
            isCrateProfile = isCrate;
            TB_Login.Text = name;
            ReplaceWindow();
        }

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
                Title = "Вход в профиль";
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

        public string ProfileName
        {
            get { return TB_Login.Text; }
        }
        public string Password01
        {
            get { return TB_Pass01.Password; }
        }
        public string Password02
        {
            get { return TB_Pass02.Password; }
        }

        private void Buttun_EnterProfile_Click(object sender, RoutedEventArgs e)
        {                  
            if (ProfileName == ""){ MessageBox.Show("Не введено имя профиля");return; }
           // if (Password01 == "") { MessageBox.Show("Не введен пароль"); return; } //пустой пароль будит доупустим!

            if (isCrateProfile)
            {
                if (Password01 != Password02) { MessageBox.Show("Пороль не совпадает"); return; }
                ProfBox.CreateNewProfile(ProfileName, Password01);
                ProfBox.ConnectProfile(ProfileName, Password01);
                if (ProfBox.profile != null) { this.DialogResult = true;  } //Если профиль получен закрываем окно

            }
            else
            {
                /*Тут будит подключение к БД и сохранение профиля в прогу*/
                ProfBox.ConnectProfile(ProfileName, Password01);          
                if (ProfBox.profile == null) { return;}

                /*Пока типа два профиля*/
                //  if (ProfileName == "1" && Password01 == "1") {this.DialogResult = true; return; }
                // if (ProfileName == "Admin" && Password01 == "Admin") {this.DialogResult = true; return; }
                this.DialogResult = true; //вурнуть успех
            }


        }
    }
  
}

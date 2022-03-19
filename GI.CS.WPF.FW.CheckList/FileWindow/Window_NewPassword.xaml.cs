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

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для Window_NewPassword.xaml
    /// </summary>
    public partial class Window_NewPassword : Window
    {
        public Window_NewPassword()
        {
            InitializeComponent();
        }

        private void Buttun_NewPassword_Click(object sender, RoutedEventArgs e)
        {
            if(ProfBox.profile.Password != TB_PasswordOld.Password)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }
            if(TB_PasswordNew01.Password != TB_PasswordNew02.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            ProfBox.profile.Password = TB_PasswordNew01.Password;
            ProfBox.SaveToChangeDB();
            DialogResult = true;
        }
    }
}

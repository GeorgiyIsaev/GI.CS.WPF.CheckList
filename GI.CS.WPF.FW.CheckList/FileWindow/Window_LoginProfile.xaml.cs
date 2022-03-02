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
                Buttun_CreateProfile.Content = "Войти в существующий";
                Buttun_EnterProfile.Content = "Создать";
                TB_Pass02i.Visibility = Visibility.Visible;
                TB_Pass02.Visibility = Visibility.Visible;
            }
            else
            {
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

    }
  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProfileBox = Data.Model.ProfileBox;


namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    public class MenuItemRefresh
    {   
        
        //static bool isLogin = true;
        static bool isLogin = false;
     
        public static void Refresh(MainWindow mainWindow)
        {

            mainWindow.MenuItem_Profile.Items.Clear();
            if (isLogin)
            {
                TestConectDB();

                MenuItem mi = new MenuItem();
                mi.Header = "Выйти из профиля";
                mi.Click += new RoutedEventHandler(
                 (sendItem, args) => { LogOut(mainWindow); });
                mainWindow.MenuItem_Profile.Items.Add(mi);

                MenuItem mi2 = new MenuItem();
                mi2.Header = "Управление профилем";
                mi2.Click += new RoutedEventHandler(
                 (sendItem, args) => { ManagementProfile(mainWindow); });
                mainWindow.MenuItem_Profile.Items.Add(mi2);

                MenuItem mi3 = new MenuItem();
                mi3.Header = "Создать новый тест";
                mi3.Click += new RoutedEventHandler(
                 (sendItem, args) => { CreateNewTest(mainWindow); });
                mainWindow.MenuItem_Profile.Items.Add(mi3);
            }
            else
            {
                MenuItem mi = new MenuItem();
                mi.Header = "Войти в профль";         
                mi.Click += new RoutedEventHandler(
                    (sendItem, args) =>{LogIn(mainWindow);});   
                mainWindow.MenuItem_Profile.Items.Add(mi);



            }
        }
        private static void TestConectDB()
        {

            Data.Model.ProfileBox.ConnectProfile("Admin", "0000");

            if (ProfileBox.profile != null)
            {
                MessageBox.Show("!!!!!");
                String text = "profile: " + ProfileBox.profile.Name + " password: " + ProfileBox.profile.Password + " Id: " + ProfileBox.profile.Id;
                MessageBox.Show(text);
            }
            //MessageBox.Show("МИМА");

        }






        /*Меню-Профиль войти в профиль*/
        private static void LogIn(MainWindow mainWindow)
        {
            Window_LoginProfile windowLoginProfile = new Window_LoginProfile();

            if (windowLoginProfile.ShowDialog() == true)
            {  
                MessageBox.Show($"Вы вышли в профиль {windowLoginProfile.ProfileName} с паролем {windowLoginProfile.Password01}");
                isLogin = true;
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
            Refresh(mainWindow);
        }
        /*Меню-Профиль выйти из профиля*/
        private static void LogOut(MainWindow mainWindow)
        {
            //MessageBox.Show("Действие");
            isLogin = false;
            Refresh(mainWindow);
        }

        /*Меню-Профиль  Управление профилем*/
        private static void ManagementProfile(MainWindow mainWindow)
        {
            //MessageBox.Show("Управление");
            new Window_ManagementProfile().ShowDialog();
       
        }

        /*Меню-Профиль  Создать тест*/
        private static void CreateNewTest(MainWindow mainWindow)
        {     
            String nameTest = DateTime.Now.ToString();
            String nameGroup = "Без группы";
            MessageBox.Show($"Создан тест: Група [{nameGroup}] Название [{nameTest}]");
        }

    }
}

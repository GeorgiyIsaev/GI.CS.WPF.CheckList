using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProfBox = DataBase.Model.ProfileBox;

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    public class MenuItemRefresh
    {   
        
       // static bool isLogin = true;
        static bool isLogin = false;
     
        public static void Refresh(MainWindow mainWindow)
        {
            //TestConectDB();
            mainWindow.MenuItem_Profile.Items.Clear();
            if (isLogin)
            {
                ProfilesMenuItem(mainWindow);
                MenuItem mi = new MenuItem();
                mi.Header = "Выйти из профиля";
                mi.Click += new RoutedEventHandler(
                 (sendItem, args) => { LogOut(mainWindow); });
                mainWindow.MenuItem_Profile.Items.Add(mi);

                MenuItem mi2 = new MenuItem();
                mi2.Header = "Управление профилем [" + ProfBox.profile.Name + "]";
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
        public static void ProfilesMenuItem(MainWindow mainWindow)
        {
            MenuItem mi = new MenuItem();
            mi.Header = "Сменить профиль";
           /* mi.Click += new RoutedEventHandler(
             (sendItem, args) => { LogOut(mainWindow); });*/
            mainWindow.MenuItem_Profile.Items.Add(mi);

            MenuItem mi1 = new MenuItem();
            mi1.Header = "Профиль 1";
            MenuItem mi2= new MenuItem();
            mi2.Header = "Профиль 1";
            mi.Items.Add(mi1);
            mi.Items.Add(mi2);


        }






        public static bool TestConectDB(string name = "Admin", string password = "0000")
        {
            ProfBox.ConnectProfile(name, password);
            if (ProfBox.profile != null)
            {
                String text = "profile: " + ProfBox.profile.Name + " password: " + ProfBox.profile.Password + " Id: " + ProfBox.profile.Id;
                MessageBox.Show(text);
                isLogin = true;
                return true;
            }
            else
            {
                isLogin = false;
                return false;
            }           
        }



        /*Меню-Профиль войти в профиль*/
        private static void LogIn(MainWindow mainWindow)
        {
            Window_LoginProfile windowLoginProfile = new Window_LoginProfile();
           // isLogin = true;
            //TestConectDB();

            if (windowLoginProfile.ShowDialog() == true)
            {
                MessageBox.Show($"Вы вышли в профиль {windowLoginProfile.ProfileName} с паролем {windowLoginProfile.Password01}");
              //  TestConectDB(windowLoginProfile.ProfileName, windowLoginProfile.Password01);
                if (ProfBox.profile != null)
                {
                    MessageBox.Show($"Вы вышли в профиль {windowLoginProfile.ProfileName} с паролем {windowLoginProfile.Password01}");
                    isLogin = true;
                }
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

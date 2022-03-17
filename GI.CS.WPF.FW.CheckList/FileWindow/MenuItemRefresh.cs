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


        static bool IsLogin {
            get {
                if (ProfBox.profile == null) return false;
                else return true;
            }
        }

        public static void Refresh(MainWindow mainWindow)
        {
            //TestConectDB();
            mainWindow.MenuItem_Profile.Items.Clear();
           // ProfilesMenuItem(mainWindow);
            if (IsLogin)
            {         
                MenuItem mi = new MenuItem();
                mi.Header = "Выйти из профиля";
                mi.Click += new RoutedEventHandler(
                 (sendItem, args) => { LogOut(mainWindow); });
                mainWindow.MenuItem_Profile.Items.Add(mi);

                ProfilesMenuItem(mainWindow);

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
                    (sendItem, args) => { LogIn(mainWindow, false); });
                mainWindow.MenuItem_Profile.Items.Add(mi);

                ProfilesMenuItem(mainWindow);
            }
        }
        public static void ProfilesMenuItem(MainWindow mainWindow)
        {
            MenuItem mi = new MenuItem();
            mi.Header = "Сменить профиль";
            mainWindow.MenuItem_Profile.Items.Add(mi);

            MenuItem newCreate = new MenuItem();
            newCreate.Header = "Добавить новый";
            newCreate.FontStyle = FontStyles.Italic; //курсив
            newCreate.Click += new RoutedEventHandler(
             (sendItem, args) => { LogIn(mainWindow, true); });
            mi.Items.Add(newCreate);



            DataBase.Model.ProfilesGet.Connect();
            foreach(var profile in DataBase.Model.ProfilesGet.profiles)
            {
               // if (profile.Password != "") continue; //пропуск если с паролем                
                
                MenuItem mi1 = new MenuItem();
                mi1.Header = profile.Name;

                if (IsLogin && profile.Name == ProfBox.profile.Name) { mi1.FontWeight = FontWeights.UltraBold; }    //жирный для текущего профиля

                if (profile.Password != "")
                {
                    mi1.Header = profile.Name + "🔑";
                    mi1.Click += new RoutedEventHandler(
                    (sendItem, args) => { LogIn(mainWindow, false, profile.Name); });
                }
                else
                {
                    mi1.Click += new RoutedEventHandler(
                    (sendItem, args) => { ConectPR(mainWindow, args); });
                }
                mi.Items.Add(mi1);
            }
        }
        private static void ConectPR(MainWindow mainWindow, RoutedEventArgs e)
        {        

            var nameProfile = ((MenuItem)e.OriginalSource).Header.ToString();
            TestConectDB(nameProfile, "");
            if (ProfBox.profile != null) { isLogin = true; Refresh(mainWindow); }
           // else MessageBox.Show("No");
        }







        public static bool TestConectDB(string name = "Admin", string password = "0000")
        {
            ProfBox.ConnectProfile(name, password);
            if (ProfBox.profile != null)
            {
                String text = "profile: " + ProfBox.profile.Name + " password: " + ProfBox.profile.Password + " Id: " + ProfBox.profile.Id;
                //MessageBox.Show(text); //!!!!!!!!!!!!!!!!!!!!!
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
        private static void LogIn(MainWindow mainWindow, bool isCreate, String NameProfile="")
        {
            Window_LoginProfile windowLoginProfile = new Window_LoginProfile(isCreate, NameProfile);
           // isLogin = true;
            //TestConectDB();

            if (windowLoginProfile.ShowDialog() == true)
            {
               // MessageBox.Show($"Вы вышли в профиль {windowLoginProfile.ProfileName} с паролем {windowLoginProfile.Password01}");
              //  TestConectDB(windowLoginProfile.ProfileName, windowLoginProfile.Password01);
                //if (ProfBox.profile != null)
                //{               
                //    isLogin = true;
                //}
            }
            else
            {
               //MessageBox.Show("Авторизация не пройдена");
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
            var window = new Window_ManagementProfile().ShowDialog();
            if(window.Value == false) { isLogin = false; Refresh(mainWindow); }

        }

        /*Меню-Профиль  Создать тест*/
        private static void CreateNewTest(MainWindow mainWindow)
        {     
            String nameTest = DateTime.Now.ToString();
            String nameGroup = "Без группы";

            ProfBox.CreateNewTest(nameGroup, nameTest);   //добавить   
           // MessageBox.Show($"Создан тест: Група [{nameGroup}] Название [{nameTest}]");
        }

    }
}

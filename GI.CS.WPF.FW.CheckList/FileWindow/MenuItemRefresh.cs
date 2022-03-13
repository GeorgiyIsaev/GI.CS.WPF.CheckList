using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GI.CS.WPF.FW.CheckList.FileWindow
{
    public class MenuItemRefresh
    {
        static bool isLogin = false;

        public static void Refresh(MainWindow mainWindow)
        {

            mainWindow.MenuItem_Profile.Items.Clear();
            if (isLogin)
            {
                MenuItem mi = new MenuItem();
                mi.Header = "Выйти из профиля";
                mi.Click += new RoutedEventHandler(
                 (sendItem, args) => { LogOut(mainWindow); });

                mainWindow.MenuItem_Profile.Items.Add(mi);
         

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

        private static void LogIn(MainWindow mainWindow)
        {
            //MessageBox.Show("Действие");
            isLogin = true;
            Refresh(mainWindow);
        }
        private static void LogOut(MainWindow mainWindow)
        {
            //MessageBox.Show("Действие");
            isLogin = false;
            Refresh(mainWindow);
        }

    }
}

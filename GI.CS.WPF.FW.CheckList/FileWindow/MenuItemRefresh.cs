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
        //static bool isLogin = false;


        static bool IsLogin {
            get {
                if (ProfBox.profile == null) return false;
                else return true;
            }
        }

        public static void Refresh(MainWindow mainWindow)
        {
            //ConectDBProfile();
            mainWindow.MenuItem_Profile.Items.Clear();

            if(ProfBox.testCurrent != null)
                mainWindow.GridMain.IsEnabled = true;
            if(ProfBox.profile !=null && ProfBox.testCurrent == null) 
                mainWindow.GridMain.IsEnabled = false;

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

                mainWindow.MenuItem_Profile.Items.Add(new Separator());
                MenuItem mi3 = new MenuItem();
                mi3.Header = "Новый безымянный тест";
                mi3.FontStyle = FontStyles.Italic; //курсив
                mi3.Click += new RoutedEventHandler(
                 (sendItem, args) => { CreateNewTest(mainWindow); });
                mainWindow.MenuItem_Profile.Items.Add(mi3);
    
                ProfileTestsMenuItem(mainWindow);

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

        /*Меню с профилями*/
        public static void ProfilesMenuItem(MainWindow mainWindow)
        {
            MenuItem mi = new MenuItem();
            mi.Header = "Сменить профиль";
            mainWindow.MenuItem_Profile.Items.Add(mi);

            MenuItem newCreate = new MenuItem();
            newCreate.Header = " Добавить новый";
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
                    (sendItem, args) => { ConectProfileNotPassword(mainWindow, args); });
                }
                mi.Items.Add(mi1);
            }
        }

        /*Меню с тестами*/
        public static void ProfileTestsMenuItem(MainWindow mainWindow)
        {
            List<MenuItem> testItem = new List<MenuItem>();            
            foreach (DataBase.Tables.Test test in ProfBox.profile.Tests)
            {
                /*Вызваемый тест*/
                MenuItem TestItem = new MenuItem();
                TestItem.Header = test.Name;
                TestItem.Click += new RoutedEventHandler(
                (sendItem, args) => {
                    EnterTest(mainWindow, test.Id);               
                });                

                /*Отметка выбраного теста*/
                if (ProfBox.testCurrent != null && ProfBox.testCurrent.Id == test.Id)
                {
                    TestItem.FontWeight = FontWeights.Bold;             
                }
                else TestItem.FontWeight = FontWeights.Normal;

                 /*Создание групп*/         
                MenuItem tempItem = testItem.Find(t1 => t1.Header.ToString() == test.Group);
                if (tempItem == null)
                {
                    MenuItem GroupTestItem = new MenuItem();
                    GroupTestItem.Header = test.Group;
                    testItem.Add(GroupTestItem);
                    GroupTestItem.Items.Add(TestItem);           
                }
                else
                {
                    testItem.Find(t1 => t1.Header.ToString() == test.Group).Items.Add(TestItem);
                }

                /*Подсветка группы меню*/
                if (ProfBox.testCurrent != null && ProfBox.testCurrent.Id == test.Id)
                {               
                    testItem.Find(t1 => t1.Header.ToString() == test.Group).FontWeight = FontWeights.Bold;
                }
         
            }
            foreach(var t in testItem)
            {
                mainWindow.MenuItem_Profile.Items.Add(t);
            }
        }



        /*Вход в тест*/
        private static void EnterTest(MainWindow mainWindow, long id)
        {      
            ProfBox.TestRefresh(id);
            Refresh(mainWindow);

            /*Загружаем тест в контейнер вопросов приложения*/
            if (ProfBox.testCurrent != null)
            {      
                mainWindow.ClearForm();         
                mainWindow.GridMain.Visibility = Visibility.Visible;
                QuestsBox.ReadQuestDB(ProfBox.testCurrent);
            }
        }


        /*МЕНЮ - Выбора профилия из списка ВХОД*/
        private static void ConectProfileNotPassword(MainWindow mainWindow, RoutedEventArgs e)
        { 
            var nameProfile = ((MenuItem)e.OriginalSource).Header.ToString();
            ConectDBProfile(mainWindow, nameProfile, "");
            if (ProfBox.profile != null) {                 
                Refresh(mainWindow);
                mainWindow.ClearForm();    
            }          
        }
  







        public static void ConectDBProfile(MainWindow mainWindow, string name, string password = "")
        {
            /*Очистка вопросов если лист заполенен*/
            if (QuestsBox.questItems.Count() > 1)
            {
                var result = MessageBox.Show($"Очистить форму от вопросов?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No) return;
            }
            mainWindow.ClearForm();
            ProfBox.ConnectProfile(name, password);         
        }



        /*Меню-Профиль войти в профиль*/
        private static void LogIn(MainWindow mainWindow, bool isCreate, String NameProfile="")
        {
            Window_LoginProfile windowLoginProfile = new Window_LoginProfile(isCreate, NameProfile); //вход профиль внутри окна
            if (windowLoginProfile.ShowDialog() == true)
            {
                if (QuestsBox.questItems.Count() > 1)
                {
                    var result = MessageBox.Show($"Очистить форму от вопросов?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No) return;
                }
                mainWindow.ClearForm();
            }
            Refresh(mainWindow);
        }
        /*Меню-Профиль - выйти из профиля*/
        private static void LogOut(MainWindow mainWindow)
        {
            ProfBox.EndConect();
            mainWindow.ClearForm();
            mainWindow.GridMain.IsEnabled = true;
            Refresh(mainWindow);
        }

        /*Меню-Профиль -  Управление профилем*/
        private static void ManagementProfile(MainWindow mainWindow)
        {    
            var windowpop = new Window_ManagementProfile();
            if(windowpop.ShowDialog() == true) {       
                EnterTest(mainWindow, windowpop.testId);                     
            }
            Refresh(mainWindow); // вызваем в любом случаии
        }

        /*Меню-Профиль - Быстрое создание теста*/
        private static void CreateNewTest(MainWindow mainWindow)
        {     
            String nameTest = DateTime.Now.ToString();
            String nameGroup = "Без группы";
            ProfBox.testCurrent = ProfBox.CreateNewTest(nameGroup, nameTest);  //добавляем и открываем

            // ProfBox.TestRefresh(ProfBox.CreateNewTest(nameGroup, nameTest).Id);
            Refresh(mainWindow);
            mainWindow.ClearForm();
        }

    }
}

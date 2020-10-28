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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CheckListQuests
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*Контейнер с привязкой к листбоксу*/
            QuestItem questItem = new QuestItem();
            ListBox_Quest.ItemsSource = QuestsBox.questItems;
            /*Нулевой эл-т для новых вопросов*/
            questItem.quest = "<Добавить новый вопрос>";
            QuestsBox.questItems.Add(questItem);
            /*Чтение из временого файла*/
            QuestsBox.file_readTXT("TEMPTXT.txt");
            ListBox_Quest.SelectedIndex = 0;
            Title = $"Чек-Лист [{QuestsBox.questItems.Count}] вопросов";
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Quest.SelectedIndex == 0)
            {
                input_AnAnswer.Text = "";
                input_Answer.Text = "";
                input_Comment.Text = "";
                input_Quest.Text = "";
            }
            else {
                int val = ListBox_Quest.SelectedIndex;
                if (val > 0)  QuestsBox.questItems.RemoveAt(val);
                ListBox_Quest.SelectedIndex = 0;
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            int val = ListBox_Quest.SelectedIndex;        
            if (val == 0 && QuestsBox.if_ThereQuest(input_Quest.Text))
            {
                MessageBox.Show("Такой вопрос уже был добавлен ранее", "Невозможно добавить вопрос");
                return;
            }
            if (input_Quest.Text == "")
            {
                MessageBox.Show("Поле с вопросом не заполнено", "Невозможно добавить вопрос");
                return;
            }

            QuestItem questItem = new QuestItem();
            questItem.quest = input_Quest.Text;
            questItem.comment = input_Comment.Text;
            questItem.InputAnswerList(input_Answer.Text, input_AnAnswer.Text);

            if (ListBox_Quest.SelectedIndex != 0)
            {
                QuestsBox.questItems.Insert(val+1, questItem);
                QuestsBox.questItems.RemoveAt(val);
                ListBox_Quest.SelectedIndex = val;
            }
            else
                QuestsBox.questItems.Add(questItem);
            Title = $"Чек-Лист [{QuestsBox.questItems.Count}] вопросов";
        }       
        private void MenuItemSaveTXT_Click(object sender, RoutedEventArgs e)
        {
            QuestsBox.file_saveTXT("text.txt");
            MessageBox.Show("Файл сохранен text.txt");
        }

        private void ListBox_Quest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*Перемещение по лист боксу*/
            if (ListBox_Quest.SelectedIndex > 0)
            {
                int val = ListBox_Quest.SelectedIndex; // индекс выделеного эл-та
                input_AnAnswer.Text = QuestsBox.questItems.ElementAt(val).StrFullAnswer(false);
                input_Answer.Text = QuestsBox.questItems.ElementAt(val).StrFullAnswer();
                input_Comment.Text = QuestsBox.questItems.ElementAt(val).comment;
                input_Quest.Text = QuestsBox.questItems.ElementAt(val).quest;
                Button_Clear.Content = "Удалить";
                Button_Save.Content = "Изменить";
            }
            else
            {
                Button_Clear_Click(sender, e);
                Button_Clear.Content = "Очистить";
                Button_Save.Content = "Сохранить";
            }
        } 



        //private void Button_NewQuest_Click(object sender, RoutedEventArgs e)
        //{
        //    //if(ListBox_Quest.SelectedIndex != -1) ListBox_Quest.SelectedIndex = -1; // снимаем выделение   
        //    // ClearSelected(); только для винформ
        //    Button_Clear_Click(sender, e);
        //    Button_Clear.Content = "Очистить";
        //    Button_Save.Content = "Сохранить";
        //}
    }
}

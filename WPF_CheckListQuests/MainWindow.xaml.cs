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
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            input_AnAnswer.Text = "";
            input_Answer.Text = "";
            input_Comment.Text = "";
            input_Quest.Text = "";
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (QuestsBox.if_ThereQuest(input_Quest.Text))
            {
                MessageBox.Show("Такой вопрос уже был добавлен ранее","Невозможно добавить вопрос");
                return;
            }
            
            QuestItem questItem = new QuestItem();
            questItem.quest = input_Quest.Text;
            questItem.comment = input_Comment.Text;
            questItem.InputAnswerList(input_Answer.Text, input_AnAnswer.Text);
            addListBoxQuetsItem(questItem);
        }
        private void addListBoxQuetsItem(QuestItem questItem)
        {
            QuestsBox.questItem.Add(questItem);
            ListBox_Quest.Items.Add(questItem);    
            /*TODO будут ли они сортироваться, можно ли добаваить всплывающую подсказку*/
        }



    }
}

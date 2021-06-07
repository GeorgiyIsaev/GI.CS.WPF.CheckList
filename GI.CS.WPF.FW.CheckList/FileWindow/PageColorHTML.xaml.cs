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

namespace GI.CS.WPF.FW.CheckList
{
    /// <summary>
    /// Логика взаимодействия для PageColorHTML.xaml
    /// </summary>
    public partial class PageColorHTML : Page
    {
        public PageColorHTML()
        {
            InitializeComponent();
            Loaded += Windows_Loaded;
            

        }
        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            CreateComboBox_FontSize();           
            //FontSizeInit();
        }


        private void CreateComboBox_FontSize()
        {
            for (int i = 8; i < 38; i += 2)
            {              
                ComboBox_FontSizeHead.Items.Add(i);
                ComboBox_FontSizeDiscript.Items.Add(i);
                ComboBox_FontSizeQuest.Items.Add(i);
                ComboBox_FontSizeAnswer .Items.Add(i);
                ComboBox_FontSizeAnAnswer.Items.Add(i);
                ComboBox_FontSizeComment.Items.Add(i);
            }
            StandartStileButton();
        }
        private void StandartStileButton()
        {

            Button_head_G.IsChecked = true;
            Button_head_I.IsChecked = false;
            Button_head_Z.IsChecked = true;
            ComboBox_FontSizeHead.SelectedIndex = 4;
            ComboBox_FontSizeDiscript.SelectedIndex = 4;
            ComboBox_FontSizeQuest.SelectedIndex = 4;
            ComboBox_FontSizeAnswer.SelectedIndex = 4;
            ComboBox_FontSizeAnAnswer.SelectedIndex = 4;
            ComboBox_FontSizeComment.SelectedIndex = 4;
        }
        private void ButtonClick_CSS(object sender, RoutedEventArgs e)
        {
            RTB_Head.FontWeight = (Button_head_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Head.FontStyle = (Button_head_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Head.TextDecorations = (Button_head_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        }
        private void SelectionChanged_FontSize(object sender, SelectionChangedEventArgs e)
        {
            FontSizeInit();
        }

        private void FontSizeInit()
        {
            try
            {
                if(ComboBox_FontSizeHead.SelectedValue.ToString() != null) 
                    RTB_Head.FontSize = Convert.ToInt32(ComboBox_FontSizeHead.SelectedValue.ToString());
                if (ComboBox_FontSizeDiscript.SelectedItem != null)
                    RTB_Discript.FontSize = Convert.ToInt32(ComboBox_FontSizeDiscript.SelectedValue.ToString());
                if (ComboBox_FontSizeQuest.SelectedItem != null)
                    RTB_Quest.FontSize = Convert.ToInt32(ComboBox_FontSizeQuest.SelectedValue.ToString());

                if (ComboBox_FontSizeAnswer.SelectedItem != null)
                {
                    RTB_AnswerTrueIcon1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString()) + 2;
                    RTB_AnswerTrue1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString());
                    RTB_AnswerTrueIcon2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString()) + 2;
                    RTB_AnswerTrue2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString());
                }
                if (ComboBox_FontSizeAnAnswer.SelectedItem != null)
                {
                    RTB_AnswerFalseIcon1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString()) + 2;
                    RTB_AnswerFalse1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString());
                    RTB_AnswerFalseIcon2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString()) + 2;
                    RTB_AnswerFalse2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString());
                }
                if (ComboBox_FontSizeComment.SelectedItem != null)
                    RTB_Comment.FontSize = Convert.ToInt32(ComboBox_FontSizeComment.SelectedValue.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

}

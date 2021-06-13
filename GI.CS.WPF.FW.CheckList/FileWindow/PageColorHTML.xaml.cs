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

using System.ComponentModel;
using PropertyTools.Wpf;

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
            FontStyleInit();
            ColorInitialize();
        }


        private void CreateComboBox_FontSize()
        {
            for (int i = 6; i < 42; i += 2)
            {              
                ComboBox_FontSizeHead.Items.Add(i);
                ComboBox_FontSizeDiscript.Items.Add(i);
                ComboBox_FontSizeQuest.Items.Add(i);
                ComboBox_FontSizeAnswer .Items.Add(i);
                ComboBox_FontSizeAnswerI.Items.Add(i);
                ComboBox_FontSizeAnAnswer.Items.Add(i);
                ComboBox_FontSizeAnAnswerI.Items.Add(i);
                ComboBox_FontSizeComment.Items.Add(i);
            }
            StandartStileButton();
        }
        private void StandartStileButton()
        {

            Button_head_G.IsChecked = true;          
            Button_head_Z.IsChecked = true;
            Button_discript_I.IsChecked = true;

            int baseSize = 5;
            ComboBox_FontSizeHead.SelectedIndex = baseSize + 3;
            ComboBox_FontSizeDiscript.SelectedIndex = baseSize - 1;
            ComboBox_FontSizeQuest.SelectedIndex = baseSize;
            ComboBox_FontSizeAnswer.SelectedIndex = baseSize;
            ComboBox_FontSizeAnAnswer.SelectedIndex = baseSize;
            ComboBox_FontSizeAnswerI.SelectedIndex = baseSize+1;
            ComboBox_FontSizeAnAnswerI.SelectedIndex = baseSize+1;
            ComboBox_FontSizeComment.SelectedIndex = baseSize;
        }
        private void ButtonClick_CSS(object sender, RoutedEventArgs e)
        {
            FontStyleInit();
        }
        private void FontStyleInit()
        {
            RTB_Head.FontWeight = (Button_head_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Head.FontStyle = (Button_head_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Head.TextDecorations = (Button_head_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_Discript.FontWeight = (Button_discript_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Discript.FontStyle = (Button_discript_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Discript.TextDecorations = (Button_discript_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_Quest.FontWeight = (Button_Quest_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Quest.FontStyle = (Button_Quest_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Quest.TextDecorations = (Button_Quest_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_AnswerTrue2.FontWeight = RTB_AnswerTrue1.FontWeight = (Button_Answer_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerTrue2.FontStyle = RTB_AnswerTrue1.FontStyle = (Button_Answer_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerTrue2.TextDecorations = RTB_AnswerTrue1.TextDecorations = (Button_Answer_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_AnswerTrueIcon2.FontWeight = RTB_AnswerTrueIcon1.FontWeight = (Button_AnswerI_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerTrueIcon2.FontStyle = RTB_AnswerTrueIcon1.FontStyle = (Button_Answer_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerTrueIcon2.TextDecorations = RTB_AnswerTrueIcon1.TextDecorations = (Button_Answer_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_AnswerFalse2.FontWeight = RTB_AnswerFalse1.FontWeight = (Button_AnAnswer_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerFalse2.FontStyle = RTB_AnswerFalse1.FontStyle = (Button_AnAnswer_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerFalse2.TextDecorations = RTB_AnswerFalse1.TextDecorations = (Button_AnAnswer_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_AnswerFalseIcon2.FontWeight = RTB_AnswerFalseIcon1.FontWeight = (Button_AnAnswerI_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerFalseIcon2.FontStyle = RTB_AnswerFalseIcon1.FontStyle = (Button_AnAnswerI_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerFalseIcon2.TextDecorations = RTB_AnswerFalseIcon1.TextDecorations = (Button_AnAnswerI_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

            RTB_Comment.FontWeight = (Button_Comment_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Comment.FontStyle = (Button_Comment_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Comment.TextDecorations = (Button_Comment_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

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
                    RTB_AnswerTrue1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString());
                    RTB_AnswerTrue2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString());
                }
                if (ComboBox_FontSizeAnswerI.SelectedItem != null)
                {
                    RTB_AnswerTrueIcon1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswerI.SelectedValue.ToString());
                    RTB_AnswerTrueIcon2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswerI.SelectedValue.ToString());            
                }

                if (ComboBox_FontSizeAnAnswer.SelectedItem != null)
                {                 
                    RTB_AnswerFalse1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString());
                    RTB_AnswerFalse2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString());
                }
                if (ComboBox_FontSizeAnAnswerI.SelectedItem != null)
                {
                    RTB_AnswerFalseIcon2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswerI.SelectedValue.ToString());
                    RTB_AnswerFalseIcon1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswerI.SelectedValue.ToString());
                }
                if (ComboBox_FontSizeComment.SelectedItem != null)                
                    RTB_Comment.FontSize = Convert.ToInt32(ComboBox_FontSizeComment.SelectedValue.ToString());              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ColorInitialize()
        {
            ColorPicker_MainFon.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ffffffff");
            ColorPicker_BeckFon.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ffc4d0c7");
            ColorPicker_SignFon.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ffa9a9a9");

            ColorPicker_Head.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");
            ColorPicker_Discript.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");
            ColorPicker_Quest.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");
            ColorPicker_Answer.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");
            ColorPicker_AnAnswer.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");
            ColorPicker_AnswerI.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff1eaf1e");
            ColorPicker_AnAnswerI.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ffff0000");
            ColorPicker_Comment.SelectedColor = (Color?)ColorConverter.ConvertFromString("#ff000000");       
        }



        private void ColorPicker_BeckFon_MouseLeave(object sender, MouseEventArgs e)
        {         
            Color? color = ColorPicker_BeckFon.SelectedColor;         
            //Color colorIR5 = (Color)ColorConverter.ConvertFromString("#ffaabbcc");
           // SolidColorBrush brush = new SolidColorBrush(colorIR5);
            if (color.Value != null)
            {
                Color colorIR5 = (Color)color.Value;
                SolidColorBrush brush = new SolidColorBrush(colorIR5);
                BackFon.Background = brush;
            }
        }
    }

}

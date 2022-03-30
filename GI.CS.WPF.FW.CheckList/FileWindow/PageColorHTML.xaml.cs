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
            /*Передаем стили СSS в постройку*/
            MyTitle.InitCSS(EditionHTML.structCCS.title);
            MyDiscription.InitCSS(EditionHTML.structCCS.description);
            MyQuest.InitCSS(EditionHTML.structCCS.question);
            MyAnswer.InitCSS(EditionHTML.structCCS.trueAanswer);
            MyAnswerItem.InitCSS(EditionHTML.structCCS.trueAanswerIcon);
            MyAnAnswer.InitCSS(EditionHTML.structCCS.falseAnswer);
            MyAnAnswerItem.InitCSS(EditionHTML.structCCS.falseAanswerIcon);
            MyComment.InitCSS(EditionHTML.structCCS.comment);




            //CreateComboBox_FontSize();
            //  FontStyleInit();
            //  ColorPickerInitialize();
            //Contol.InitCSS(true, true, false, 6);
            //Contol.InitCSSColor("#c4d0c7");

            //   Contol.InitCSS(EditionHTML.structCCS.title);
        }


        //private void CreateComboBox_FontSize()
        //{
        //    for (int i = 6; i < 42; i += 2)
        //    {              
        //        ComboBox_FontSizeHead.Items.Add(i);
        //        ComboBox_FontSizeDiscript.Items.Add(i);
        //        ComboBox_FontSizeQuest.Items.Add(i);
        //        ComboBox_FontSizeAnswer .Items.Add(i);
        //        ComboBox_FontSizeAnswerI.Items.Add(i);
        //        ComboBox_FontSizeAnAnswer.Items.Add(i);
        //        ComboBox_FontSizeAnAnswerI.Items.Add(i);
        //        ComboBox_FontSizeComment.Items.Add(i);
        //    }
        //    StandartStileButton();

        //}
        //private void StandartStileButton()
        //{

        //    Button_head_G.IsChecked = true;          
        //    Button_head_Z.IsChecked = true;
        //    Button_discript_I.IsChecked = true;

        //    int baseSize = 5;
        //    ComboBox_FontSizeHead.SelectedIndex = baseSize + 3;
        //    ComboBox_FontSizeDiscript.SelectedIndex = baseSize - 1;
        //    ComboBox_FontSizeQuest.SelectedIndex = baseSize;
        //    ComboBox_FontSizeAnswer.SelectedIndex = baseSize;
        //    ComboBox_FontSizeAnAnswer.SelectedIndex = baseSize;
        //    ComboBox_FontSizeAnswerI.SelectedIndex = baseSize+1;
        //    ComboBox_FontSizeAnAnswerI.SelectedIndex = baseSize+1;
        //    ComboBox_FontSizeComment.SelectedIndex = baseSize;
        //}
        //private void ButtonClick_CSS(object sender, RoutedEventArgs e)
        //{
        //    FontStyleInit();
        //}
        //private void FontStyleInit()
        //{
        //    RTB_Head.FontWeight = (Button_head_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_Head.FontStyle = (Button_head_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_Head.TextDecorations = (Button_head_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_Discript.FontWeight = (Button_discript_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_Discript.FontStyle = (Button_discript_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_Discript.TextDecorations = (Button_discript_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_Quest.FontWeight = (Button_Quest_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_Quest.FontStyle = (Button_Quest_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_Quest.TextDecorations = (Button_Quest_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_AnswerTrue2.FontWeight = RTB_AnswerTrue1.FontWeight = (Button_Answer_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_AnswerTrue2.FontStyle = RTB_AnswerTrue1.FontStyle = (Button_Answer_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_AnswerTrue2.TextDecorations = RTB_AnswerTrue1.TextDecorations = (Button_Answer_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_AnswerTrueIcon2.FontWeight = RTB_AnswerTrueIcon1.FontWeight = (Button_AnswerI_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_AnswerTrueIcon2.FontStyle = RTB_AnswerTrueIcon1.FontStyle = (Button_Answer_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_AnswerTrueIcon2.TextDecorations = RTB_AnswerTrueIcon1.TextDecorations = (Button_Answer_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_AnswerFalse2.FontWeight = RTB_AnswerFalse1.FontWeight = (Button_AnAnswer_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_AnswerFalse2.FontStyle = RTB_AnswerFalse1.FontStyle = (Button_AnAnswer_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_AnswerFalse2.TextDecorations = RTB_AnswerFalse1.TextDecorations = (Button_AnAnswer_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_AnswerFalseIcon2.FontWeight = RTB_AnswerFalseIcon1.FontWeight = (Button_AnAnswerI_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_AnswerFalseIcon2.FontStyle = RTB_AnswerFalseIcon1.FontStyle = (Button_AnAnswerI_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_AnswerFalseIcon2.TextDecorations = RTB_AnswerFalseIcon1.TextDecorations = (Button_AnAnswerI_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //    RTB_Comment.FontWeight = (Button_Comment_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
        //    RTB_Comment.FontStyle = (Button_Comment_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        //    RTB_Comment.TextDecorations = (Button_Comment_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;

        //}





        //private void SelectionChanged_FontSize(object sender, SelectionChangedEventArgs e)
        //{
        //    FontSizeInit();
        //}
        //private void FontSizeInit()
        //{
        //    try
        //    {
        //        //< !--dsd  MyDiscription MyQuest MyAnswer MyAnswerItem MyAnAnswer MyAnAnswerItem MyComment-- >
        //        if (ComboBox_FontSizeHead.SelectedValue.ToString() != null)
        //            RTB_Head.FontSize = Convert.ToInt32(ComboBox_FontSizeHead.SelectedValue.ToString());
        //        if (ComboBox_FontSizeDiscript.SelectedItem != null)
        //            RTB_Discript.FontSize = Convert.ToInt32(ComboBox_FontSizeDiscript.SelectedValue.ToString());
        //        if (ComboBox_FontSizeQuest.SelectedItem != null)
        //            RTB_Quest.FontSize = Convert.ToInt32(ComboBox_FontSizeQuest.SelectedValue.ToString());

        //        if (ComboBox_FontSizeAnswer.SelectedItem != null)
        //        {
        //            RTB_AnswerTrue1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString());
        //            RTB_AnswerTrue2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswer.SelectedValue.ToString());
        //        }
        //        if (ComboBox_FontSizeAnswerI.SelectedItem != null)
        //        {
        //            RTB_AnswerTrueIcon1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswerI.SelectedValue.ToString());
        //            RTB_AnswerTrueIcon2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnswerI.SelectedValue.ToString());
        //        }

        //        if (ComboBox_FontSizeAnAnswer.SelectedItem != null)
        //        {
        //            RTB_AnswerFalse1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString());
        //            RTB_AnswerFalse2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswer.SelectedValue.ToString());
        //        }
        //        if (ComboBox_FontSizeAnAnswerI.SelectedItem != null)
        //        {
        //            RTB_AnswerFalseIcon2.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswerI.SelectedValue.ToString());
        //            RTB_AnswerFalseIcon1.FontSize = Convert.ToInt32(ComboBox_FontSizeAnAnswerI.SelectedValue.ToString());
        //        }
        //        if (ComboBox_FontSizeComment.SelectedItem != null)
        //            RTB_Comment.FontSize = Convert.ToInt32(ComboBox_FontSizeComment.SelectedValue.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        private void ColorPicker_ColorInitialize(object sender, MouseEventArgs e)
        {

        }

        /*Событие которые происходит при изменении свойств*/
        private void EventChangeCSS()
        {
            var a = MyTitle.GetCSS();
                   
            /*Меняем цвет шрифта*/
            RTB_Head.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyTitle.GetCSS().Color);
            RTB_Discript.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyDiscription.GetCSS().Color);
            RTB_Quest.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyQuest.GetCSS().Color);
            RTB_AnswerTrue2.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnswer.GetCSS().Color);
            RTB_AnswerTrue1.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnswer.GetCSS().Color);
            RTB_AnswerTrueIcon2.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnswerItem.GetCSS().Color);
            RTB_AnswerTrueIcon1.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnswerItem.GetCSS().Color);
            RTB_AnswerFalse1.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnAnswer.GetCSS().Color);
            RTB_AnswerFalse2.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnAnswer.GetCSS().Color);
            RTB_AnswerFalseIcon2.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnAnswerItem.GetCSS().Color);
            RTB_AnswerFalseIcon1.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyAnAnswerItem.GetCSS().Color);
            RTB_Comment.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom(MyComment.GetCSS().Color);

            /*Меняем размер шрифта*/
            RTB_Head.FontSize = MyTitle.GetCSS().SizeFront;
            RTB_Discript.FontSize = MyDiscription.GetCSS().SizeFront;
            RTB_Quest.FontSize = MyQuest.GetCSS().SizeFront;
            RTB_AnswerTrue2.FontSize = MyAnswer.GetCSS().SizeFront;
            RTB_AnswerTrue1.FontSize = MyAnswer.GetCSS().SizeFront;
            RTB_AnswerTrueIcon2.FontSize = MyAnswerItem.GetCSS().SizeFront;
            RTB_AnswerTrueIcon1.FontSize = MyAnswerItem.GetCSS().SizeFront;
            RTB_AnswerFalse1.FontSize = MyAnAnswer.GetCSS().SizeFront;
            RTB_AnswerFalse2.FontSize = MyAnAnswer.GetCSS().SizeFront;
            RTB_AnswerFalseIcon2.FontSize = MyAnAnswerItem.GetCSS().SizeFront;
            RTB_AnswerFalseIcon1.FontSize = MyAnAnswerItem.GetCSS().SizeFront;
            RTB_Comment.FontSize = MyComment.GetCSS().SizeFront;

            /*Жриный шрифт*/
            RTB_Head.FontWeight = (MyTitle.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal; 
            RTB_Discript.FontWeight = (MyDiscription.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Quest.FontWeight = (MyQuest.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerTrue2.FontWeight = (MyAnswer.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerTrue1.FontWeight = (MyAnswer.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerTrueIcon2.FontWeight = (MyAnswerItem.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerTrueIcon1.FontWeight = (MyAnswerItem.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerFalse1.FontWeight = (MyAnAnswer.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerFalse2.FontWeight = (MyAnAnswer.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerFalseIcon2.FontWeight = (MyAnAnswerItem.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_AnswerFalseIcon1.FontWeight = (MyAnAnswerItem.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;
            RTB_Comment.FontWeight = (MyComment.GetCSS().Bold == true) ? FontWeights.Bold : FontWeights.Normal;

            /*Курсив*/
            RTB_Head.FontStyle = (MyTitle.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Discript.FontStyle = (MyDiscription.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Quest.FontStyle = (MyQuest.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerTrue2.FontStyle = (MyAnswer.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerTrue1.FontStyle = (MyAnswer.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerTrueIcon2.FontStyle = (MyAnswerItem.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerTrueIcon1.FontStyle = (MyAnswerItem.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerFalse1.FontStyle = (MyAnAnswer.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerFalse2.FontStyle = (MyAnAnswer.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerFalseIcon2.FontStyle = (MyAnAnswerItem.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_AnswerFalseIcon1.FontStyle = (MyAnAnswerItem.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;
            RTB_Comment.FontStyle = (MyComment.GetCSS().Italic == true) ? FontStyles.Italic : FontStyles.Normal;

            /*Зачеркнут*/
            RTB_Head.TextDecorations = (MyTitle.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_Discript.TextDecorations = (MyDiscription.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_Quest.TextDecorations = (MyQuest.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerTrue2.TextDecorations = (MyAnswer.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerTrue1.TextDecorations = (MyAnswer.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerTrueIcon2.TextDecorations = (MyAnswerItem.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerTrueIcon1.TextDecorations = (MyAnswerItem.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerFalse1.TextDecorations = (MyAnAnswer.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerFalse2.TextDecorations = (MyAnAnswer.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerFalseIcon2.TextDecorations = (MyAnAnswerItem.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_AnswerFalseIcon1.TextDecorations = (MyAnAnswerItem.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;
            RTB_Comment.TextDecorations = (MyComment.GetCSS().Strike == true) ? TextDecorations.Strikethrough : null;

            ////    RTB_Head.FontWeight = (Button_head_G.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal;
            //    RTB_Head.FontStyle = (Button_head_I.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
            //    RTB_Head.TextDecorations = (Button_head_Z.IsChecked == true) ? TextDecorations.Strikethrough : null;
            //MessageBox.Show(a.GetCreateStringCSS());
            // FontSizeInit();

            //<!--dsd  MyDiscription  MyQuest MyAnswer MyAnswerItem MyAnAnswer MyAnAnswerItem MyComment-->
            //ColorInitialize();

            //  MessageBox.Show("Djq");
        }

        private void ColorPicker_SignFon_DropDownClosed(object sender, EventArgs e)
        {
            string text = ColorPicker_SignFon.SelectedColor.Value.ToString();



            var br = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffaacc");
            MessageBox.Show(text);
        }


        //private void ColorInitialize()
        //{
        //    Color? colorTemp;
        //    SolidColorBrush brushTemp;

        //    colorTemp = ColorPicker_BeckFon.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        BackFon.Background = brushTemp;
        //    }

        //    colorTemp = ColorPicker_MainFon.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RichTextBox_Fon.Background = brushTemp;
        //    }


        //    colorTemp = ColorPicker_Head.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_Head.Foreground = brushTemp;
        //    }
        //    colorTemp = ColorPicker_Discript.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_Discript.Foreground = brushTemp;
        //    }
        //    colorTemp = ColorPicker_Quest.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_Quest.Foreground = brushTemp;
        //    }
        //    colorTemp = ColorPicker_Answer.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_AnswerTrue1.Foreground = brushTemp;
        //        RTB_AnswerTrue2.Foreground = brushTemp;
        //    }

        //    colorTemp = ColorPicker_AnAnswer.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_AnswerFalse1.Foreground = brushTemp;
        //        RTB_AnswerFalse2.Foreground = brushTemp;
        //    }

        //    colorTemp = ColorPicker_AnswerI.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_AnswerTrueIcon1.Foreground = brushTemp;
        //        RTB_AnswerTrueIcon2.Foreground = brushTemp;
        //    }

        //    colorTemp = ColorPicker_AnAnswerI.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_AnswerFalseIcon1.Foreground = brushTemp;
        //        RTB_AnswerFalseIcon2.Foreground = brushTemp;
        //    }

        //    colorTemp = ColorPicker_Comment.SelectedColor;
        //    if (colorTemp.Value != null)
        //    {
        //        brushTemp = new SolidColorBrush((Color)colorTemp.Value);
        //        RTB_Comment.Foreground = brushTemp;
        //        RTB_Comment.Foreground = brushTemp;
        //    }

        //}




        //private void ColorPicker_ColorInitialize(object sender, MouseEventArgs e)
        //{
        //    ColorInitialize();
        //}
    }

}

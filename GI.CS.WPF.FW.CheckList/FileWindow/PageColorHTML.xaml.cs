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
            InitCssMyHTML();

            /*Задать состояние фона для таблицы*/
            string colorCode = "#ff" + EditionHTML.structCCS.mainBackend.color.Substring(1);        
            ColorPicker_MainFon.SelectedColor = (Color?)ColorConverter.ConvertFromString(colorCode);         

            colorCode = "#ff" + EditionHTML.structCCS.baseBackend.color.Substring(1);
            ColorPicker_BeckFon.SelectedColor = (Color?)ColorConverter.ConvertFromString(colorCode);

            colorCode = "#ff" + EditionHTML.structCCS.futterBackend.color.Substring(1);
            ColorPicker_SignFon.SelectedColor = (Color?)ColorConverter.ConvertFromString(colorCode);

        }

        /*Передаем стили СSS в постройку*/
        public void InitCssMyHTML() {
           
            MyTitle.InitCSS(EditionHTML.structCCS.title);
            MyDiscription.InitCSS(EditionHTML.structCCS.description);
            MyQuest.InitCSS(EditionHTML.structCCS.question);
            MyAnswer.InitCSS(EditionHTML.structCCS.trueAanswer);
            MyAnswerItem.InitCSS(EditionHTML.structCCS.trueAanswerIcon);
            MyAnAnswer.InitCSS(EditionHTML.structCCS.falseAnswer);
            MyAnAnswerItem.InitCSS(EditionHTML.structCCS.falseAanswerIcon);
            MyComment.InitCSS(EditionHTML.structCCS.comment);
        }

        /*Меняет цвет фона*/
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
        }

        private void ColorPicker_SignFon_DropDownClosed(object sender, EventArgs e)
        {
            Color? colorTemp;
            SolidColorBrush brushTemp;

            colorTemp = ColorPicker_BeckFon.SelectedColor;
            if (colorTemp.Value != null)
            {
                brushTemp = new SolidColorBrush((Color)colorTemp.Value);
                BackFon.Background = brushTemp;
            }

            colorTemp = ColorPicker_MainFon.SelectedColor;
            if (colorTemp.Value != null)
            {
                brushTemp = new SolidColorBrush((Color)colorTemp.Value);
                RichTextBox_Fon.Background = brushTemp;
            }



            //string text = ColorPicker_SignFon.SelectedColor.Value.ToString();
            //var br = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffaacc");
            //MessageBox.Show(text);
        }
    }

}

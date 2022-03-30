using System;
using System.Collections.Generic;
using System.Text;

namespace GI.CS.WPF.FW.CheckList
{
    public struct CCSFont
    {
        private string fullStringCss;
        private int sizeFront;
        private bool italics;
        private bool bold;
        private bool strike; //зачеркнут
        private string color;

        /*Строка СSS со стилем шрифта*/
        public string FullStringCss => fullStringCss;
        public int SizeFront => sizeFront;
        public bool Italic => italics;
        public bool Bold => bold;
        public bool Strike => strike;
        public string Color => color;

      
        public void CreateCSS(int sizeFront, bool italics, bool bold, bool strike, string color)
        {
            this.sizeFront = sizeFront;
            this.sizeFront = sizeFront;
            this.italics = italics;
            this.bold = bold;
            this.strike = strike;
            this.color = color;
            GetCreateStringCSS();
        }
        public string GetCreateStringCSS()
        {
            fullStringCss = $"font-size: {sizeFront}px; ";
            if (italics) fullStringCss += "font-style:italic; ";
            if (bold) fullStringCss += "font-weight: bold; " ;
            if (strike) fullStringCss += "text-decoration: line-through; ";
            fullStringCss += $"color: {color};";
            return fullStringCss;
        }

    }
    public struct CCSBackend
    {
        public string color;
    }

    public struct StructCCS
    {
        public CCSBackend baseBackend;
        public CCSBackend mainBackend;
        public CCSBackend futterBackend;

        public CCSFont title;
        public CCSFont description;
        public CCSFont question;
        public CCSFont trueAanswer;
        public CCSFont trueAanswerIcon;
        public CCSFont falseAnswer;
        public CCSFont falseAanswerIcon;
        public CCSFont comment;
        public CCSFont signature;

        
    }
}

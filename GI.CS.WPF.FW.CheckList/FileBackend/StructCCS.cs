using System;
using System.Collections.Generic;
using System.Text;

namespace GI.CS.WPF.FW.CheckList
{
    public struct StructCCSFont
    {
        public int sizeFront;
        public bool italics;
        public bool bold;
        public bool strike; //зачеркнут
        public string color;

    }
    public struct StructCCSBackend
    {
        public string color;
    }

    public struct StructCCS
    {
        public StructCCSBackend baseBackend;
        public StructCCSBackend mainBackend;
        public StructCCSBackend futterBackend;

        public StructCCSFont title;
        public StructCCSFont description;
        public StructCCSFont question;
        public StructCCSFont trueAanswer;
        public StructCCSFont falseAnswer;
        public StructCCSFont comment;
        public StructCCSFont signature;
    }
}

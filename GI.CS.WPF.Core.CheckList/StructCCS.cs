using System;
using System.Collections.Generic;
using System.Text;

namespace GI.CS.WPF.Core.CheckList
{
    struct StructCCSFont
    {
        int sizeFront;
        bool italics;
        bool bold;
        bool strike; //зачеркнут
        string color;

    }
    struct StructCCSBackend
    {
        string color;
    }

    struct StructCCS
    {
        StructCCSBackend baseBackend;
        StructCCSBackend mainBackend;
        StructCCSBackend futterBackend;

        StructCCSFont title;
        StructCCSFont description;
        StructCCSFont question;
        StructCCSFont trueAanswer;
        StructCCSFont falseAnswer;
        StructCCSFont comment;
        StructCCSFont signature;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox
{
    public interface ITSTSentenceParserImpl
    {
        bool ConvertToConceptualGraph { get; set; }
        void Parse(string text);
    }
}

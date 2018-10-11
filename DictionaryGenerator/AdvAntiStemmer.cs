using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public class AdvAntiStemmer : BaseAntiStemmer
    {
        public AdvAntiStemmer()
            : base(new AdvExceptionCasesWordNetSource())
        {
        }
    }
}

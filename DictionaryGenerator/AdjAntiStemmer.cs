using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public class AdjAntiStemmer : BaseAntiStemmer
    {
        public AdjAntiStemmer()
            : base(new AdjExceptionCasesWordNetSource())
        {
        }
    }
}

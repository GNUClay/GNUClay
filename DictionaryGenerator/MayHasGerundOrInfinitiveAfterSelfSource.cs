using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public class MayHasGerundOrInfinitiveAfterSelfSource: LogicalMeaningsSourceForOneMeaningByRelativePath
    {
        public MayHasGerundOrInfinitiveAfterSelfSource()
            : base(@"Resources\MyDicts\MayHasGerundOrInfinitiveAfterSelf.txt")
        {
        }
    }
}

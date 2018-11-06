using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public abstract class BaseWordPhrase_v2: BasePhrase_v2
    {
        protected BaseWordPhrase_v2(bool getKey)
            : base(getKey)
        {
        }

        public override bool IsBaseWordPhrase => true;
        public override BaseWordPhrase_v2 AsBaseWordPhrase => this;

        public abstract BaseWordPhrase_v2 ForkAsBaseWordPhrase();
    }
}

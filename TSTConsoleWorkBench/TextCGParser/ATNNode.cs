using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNNode
    {
        public ATNNode(TextPhraseContext context, ATNParser parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ATNNode");

            mParent = parent;
            mContext = context;
        }

        private TextPhraseContext mContext = null;
        private ATNParser mParent = null;

        public bool Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");



            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNFinishNode : BaseATNNode
    {
        public ATNFinishNode(TextPhraseContext context, ATNParser parent)
            : base(context, parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mContext = {mContext.ToDbgString()}");

            var state = mContext.State;

            NLog.LogManager.GetCurrentClassLogger().Info($"Run state = {state}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mContext = {mContext.ToDbgString()}");

            var result = new Sentence();
            result.Subject = mContext.Subject;
            result.Verb = mContext.Verb;
            result.Object = mContext.Object;

            switch (state)
            {
                case ATNNodeState.NP_V:
                    result.Aspect = GrammaticalAspect.Simple;
                    result.TypeOfSentence = TypeOfSentence.Declaration;
                    result.Tense = result.Verb.Tenses.First();

                    mParent.AddResult(result);

                    return;

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state.ToString());
            }
        }
    }
}

using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNTailNode: BaseATNNode
    {
        public ATNTailNode(TextPhraseContext context, ATNParser parent)
            : base(context, parent)
        {
             NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private ExtendToken CurrToken = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var state = mContext.TailState;

            NLog.LogManager.GetCurrentClassLogger().Info($"Run state = {state}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mContext = {mContext.ToDbgString()}");

            CurrToken = mContext.GetToken();

            NLog.LogManager.GetCurrentClassLogger().Info($"Run CurrToken = {CurrToken}");

            switch(state)
            {
                case ExtendTokenGoal.NP:
                    var targetNpContext = new ATNNPParserContext(mContext);

                    targetNpContext.Recovery(CurrToken);

                    var npParser = new ATNNPParser(targetNpContext);
                    npParser.Run();

                    var npResult = npParser.Result;

                    if (npResult.Count == 0)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("Run npResult.Count == 0");

                        throw new NotImplementedException();
                    }
                    else
                    {
                        foreach (var npItem in npResult)
                        {
                            NLog.LogManager.GetCurrentClassLogger().Info($"Run npItem = {npItem.ToDbgString()}");

                            var targetContext_2 = mContext.Clone();
                            targetContext_2.AssignTokens(npItem.Context);

                            targetContext_2.Object = npItem.NP;

                            TryNextDetect(targetContext_2);
                            break;
                        }
                    }
                    break;
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state.ToString());
            }
        }

        private void TryNextDetect(TextPhraseContext context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("TryNextDetect");

            var token = context.GetToken();

            NLog.LogManager.GetCurrentClassLogger().Info($"TryNextDetect token = {token}");

            if(token == null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("TryNextDetect token == null");

                throw new NotImplementedException();
            }

            var tokenKind = token.TokenKind;

            switch(tokenKind)
            {
                case TokenKind.Point:
                    Finish(context);
                    return;

                default:
                    throw new ArgumentOutOfRangeException(nameof(tokenKind), tokenKind.ToString());
            }
        }

        private void Finish(TextPhraseContext context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("TryNextDetect");

            var node = new ATNFinishNode(context, mParent);
            node.Run();
        }  
    }
}

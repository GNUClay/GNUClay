using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class ATNNPNode
    {
        public ATNNPNode(ATNNPParserContext context, ATNNPParser parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mParent = parent;
            mContext = context;
        }

        private ATNNPParserContext mContext = null;
        private ATNNPParser mParent = null;
        private ExtendToken CurrToken = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            CurrToken = mContext.GetToken();

            NLog.LogManager.GetCurrentClassLogger().Info($"Run CurrToken = {CurrToken}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mContext.RootNP = {mContext.RootNP?.ToDbgString()}");

            var partsOfSpeechList = CurrToken.PartOfSpeech;

            if (partsOfSpeechList.Count == 0)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Run partsOfSpeechList.Count == 0");

                var tokenKind = CurrToken.TokenKind;

                switch (tokenKind)
                {
                    case TokenKind.Point:
                        PutRootAsNPAndExit();
                        return;

                    default: throw new ArgumentOutOfRangeException(nameof(tokenKind), tokenKind.ToString());
                }

                throw new NotImplementedException();
            }

            foreach (var partOfSpeech in partsOfSpeechList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Run partOfSpeech = {partOfSpeech}");

                switch (partOfSpeech)
                {
                    case GrammaticalPartOfSpeech.Article:
                        InitRootNPIfNotExists();

                        mContext.CurrentNP.Determiner = CurrToken;

                        ToNextNode();
                        break;

                    case GrammaticalPartOfSpeech.Noun:
                        InitRootNPIfNotExists();

                        mContext.CurrentNP.Noun = CurrToken;

                        ToNextNode();
                        break;

                    case GrammaticalPartOfSpeech.Verb:
                        PutRootAsNPAndExit();
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech.ToString());
                }
            }
        }

        private void InitRootNPIfNotExists()
        {
            if (mContext.CurrentNP == null)
            {
                mContext.CurrentNP = new NounPhrase();
                mContext.RootNP = mContext.CurrentNP;
            }
        }

        private void ToNextNode()
        {
            var targetContext = mContext.Clone();

            var node = new ATNNPNode(targetContext, mParent);
            node.Run();
        }

        private void PutRootAsNPAndExit()
        {
            var targetContext = mContext.Clone();

            targetContext.Recovery(CurrToken);

            mParent.AddResult(mContext.RootNP, targetContext);
        }
    }
}

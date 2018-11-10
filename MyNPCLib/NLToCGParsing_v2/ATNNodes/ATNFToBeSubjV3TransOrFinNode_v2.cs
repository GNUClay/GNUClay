using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjV3TransOrFinNodeAction(ATNFToBeSubjV3TransOrFinNode_v2 item);

    public class ATNFToBeSubjV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjV3TransOrFinNodeFactory_v2(ATNFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjV3TransOrFinNodeFactory_v2(ATNFToBeSubjV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjTransNode_v2 mParentNode;
        private ATNFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_V3_Obj_TransOrFin
    FToBe_Subj_V3_No_Trans
    FToBe_Subj_V3_Condition_Fin
*/

    public class ATNFToBeSubjV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjV3TransOrFinNode_v2 sameNode, InitATNFToBeSubjV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_V3_TransOrFin;

        public ATNFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjV3TransOrFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            var verbPhrase = new VerbPhrase_v2();
            verbPhrase.Verb = Token;
            Sentence.AddVerbPhrase(verbPhrase);
            Sentence.Aspect = GrammaticalAspect.Simple;
            Sentence.Voice = GrammaticalVoice.Passive;
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                Context.PutSentenceToResult();
                return;
            }

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.Point:
                        Context.PutSentenceToResult();
                        break;

                    case KindOfItemOfSentence.QuestionMark:
                        Context.PutSentenceToResult();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}


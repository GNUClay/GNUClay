using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjVerbTransOrFinNodeAction(ATNFToDoSubjVerbTransOrFinNode_v2 item);

    public class ATNFToDoSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjVerbTransOrFinNodeFactory_v2(ATNFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjVerbTransOrFinNodeFactory_v2(ATNFToDoSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjTransNode_v2 mParentNode;
        private ATNFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Verb_Obj_TransOrFin
    FToDo_Subj_Verb_No_Trans
    FToDo_Subj_Verb_Condition_Fin
*/

    public class ATNFToDoSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbTransOrFinNode_v2 sameNode, InitATNFToDoSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Verb_TransOrFin;

        public ATNFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNFToDoSubjVerbTransOrFinNodeAction mInitAction;

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
            Sentence.Tense = Token.Tense;
            Sentence.Mood = GrammaticalMood.Indicative;
            Sentence.Voice = GrammaticalVoice.Active;
            Sentence.Modal = KindOfModal.None;
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                throw new NotImplementedException();
            }

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.QuestionMark:
                        PutSentenceToResult();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}


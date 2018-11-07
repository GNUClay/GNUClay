using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjVerbTransOrFinNodeAction(ATNSubjVerbTransOrFinNode_v2 item);

    public class ATNSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjVerbTransOrFinNodeFactory_v2(ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjVerbTransOrFinNodeFactory_v2(ATNSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjTransNode_v2 mParentNode;
        private ATNSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Verb_Obj_TransOrFin
    Subj_Verb_No_Trans
    Subj_Verb_Condition_Fin
*/

    public class ATNSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbTransOrFinNode_v2 sameNode, InitATNSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Verb_TransOrFin;

        public ATNSubjTransNode_v2 ParentNode { get; private set; }
        private ATNSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjVerbTransOrFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            var partOfSpeech = Token.PartOfSpeech;

            switch (partOfSpeech)
            {
                case GrammaticalPartOfSpeech.Verb:
                    {
                        var verbPhrase = new VerbPhrase_v2();
                        verbPhrase.Verb = Token;
                        Sentence.AddVerbPhrase(verbPhrase);
                        Sentence.Aspect = GrammaticalAspect.Simple;
                        Sentence.Tense = Token.Tense;
                        Sentence.Mood = GrammaticalMood.Indicative;
                        Sentence.Voice = GrammaticalVoice.Active;
                        Sentence.Modal = KindOfModal.None;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
            }
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
                    case KindOfItemOfSentence.Point:
                        Context.PutSentenceToResult();
                        break;

                    case KindOfItemOfSentence.Not:
                        break;

                    case KindOfItemOfSentence.Subj:
                        break;

                    case KindOfItemOfSentence.Obj:
                        AddTask(new ATNSubjVerbObjTransOrFinNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Condition:
                        AddTask(new ATNSubjVerbConditionFinNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}


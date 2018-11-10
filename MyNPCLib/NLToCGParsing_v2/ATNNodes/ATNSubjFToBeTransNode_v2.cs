using MyNPCLib.NLToCGParsing;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeTransNodeAction(ATNSubjFToBeTransNode_v2 item);

    public class ATNSubjFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeTransNodeFactory_v2(ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeTransNodeFactory_v2(ATNSubjFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjTransNode_v2 mParentNode;
        private ATNSubjFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Ving_TransOrFin
    Subj_FToBe_Not_Trans
    Subj_FToBe_V3_TransOrFin
    Subj_FToBe_Being_Trans
    Subj_FToBe_Condition_Trans
*/

    public class ATNSubjFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeTransNode_v2 sameNode, InitATNSubjFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Trans;

        public ATNSubjTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeTransNode_v2 mSameNode;
        private InitATNSubjFToBeTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            Sentence.Tense = Token.Tense;
            Sentence.Mood = GrammaticalMood.Indicative;
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
                    case KindOfItemOfSentence.Verb:
                        break;

                    case KindOfItemOfSentence.V3:
                        AddTask(new ATNSubjFToBeV3TransOrFinNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Not:
                        AddTask(new ATNSubjFToBeNotTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Condition:
                        AddTask(new ATNSubjFToBeConditionTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Subj:
                        break;

                    case KindOfItemOfSentence.Obj:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}


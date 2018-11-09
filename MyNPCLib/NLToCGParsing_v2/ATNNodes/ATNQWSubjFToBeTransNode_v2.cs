using MyNPCLib.NLToCGParsing;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeTransNodeAction(ATNQWSubjFToBeTransNode_v2 item);

    public class ATNQWSubjFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeTransNodeFactory_v2(ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeTransNodeFactory_v2(ATNQWSubjFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjTransNode_v2 mParentNode;
        private ATNQWSubjFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Ving_TransOrFin
    QWSubj_FToBe_V3_TransOrFin
    QWSubj_FToBe_Being_Trans
    QWSubj_FToBe_Condition_Trans
*/

    public class ATNQWSubjFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeTransNode_v2 sameNode, InitATNQWSubjFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Trans;

        public ATNQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeTransNode_v2 mSameNode;
        private InitATNQWSubjFToBeTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            Context.Sentence.IsQuestion = true;
            Sentence.Aspect = GrammaticalAspect.Simple;
            Sentence.Tense = Token.Tense;
            Sentence.Modal = KindOfModal.None;
            Sentence.Mood = GrammaticalMood.Undefined;
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
                        AddTask(new ATNQWSubjFToBeV3TransOrFinNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}


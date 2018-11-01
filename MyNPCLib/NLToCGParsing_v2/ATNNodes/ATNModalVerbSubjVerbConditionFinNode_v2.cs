using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjVerbConditionFinNodeAction(ATNModalVerbSubjVerbConditionFinNode_v2 item);

    public class ATNModalVerbSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjVerbConditionFinNodeFactory_v2(ATNModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjVerbConditionFinNodeFactory_v2(ATNModalVerbSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbConditionFinNode_v2 sameNode, InitATNModalVerbSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Verb_Condition_Fin;

        public ATNModalVerbSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNModalVerbSubjVerbConditionFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}


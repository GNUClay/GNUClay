using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbConditionFinNodeAction(ATNConditionModalVerbSubjVerbConditionFinNode_v2 item);

    public class ATNConditionModalVerbSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbConditionFinNodeFactory_v2(ATNConditionModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbConditionFinNodeFactory_v2(ATNConditionModalVerbSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbConditionFinNode_v2 sameNode, InitATNConditionModalVerbSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_Condition_Fin;

        public ATNConditionModalVerbSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbConditionFinNodeAction mInitAction;

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


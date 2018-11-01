using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjVerbConditionFinNodeAction(ATNQWSubjVerbConditionFinNode_v2 item);

    public class ATNQWSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjVerbConditionFinNodeFactory_v2(ATNQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjVerbConditionFinNodeFactory_v2(ATNQWSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbConditionFinNode_v2 sameNode, InitATNQWSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Verb_Condition_Fin;

        public ATNQWSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNQWSubjVerbConditionFinNodeAction mInitAction;

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


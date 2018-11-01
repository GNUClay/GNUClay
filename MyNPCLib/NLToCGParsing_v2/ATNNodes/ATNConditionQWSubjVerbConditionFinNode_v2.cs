using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjVerbConditionFinNodeAction(ATNConditionQWSubjVerbConditionFinNode_v2 item);

    public class ATNConditionQWSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjVerbConditionFinNodeFactory_v2(ATNConditionQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjVerbConditionFinNodeFactory_v2(ATNConditionQWSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjVerbConditionFinNode_v2 sameNode, InitATNConditionQWSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Verb_Condition_Fin;

        public ATNConditionQWSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjVerbConditionFinNodeAction mInitAction;

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


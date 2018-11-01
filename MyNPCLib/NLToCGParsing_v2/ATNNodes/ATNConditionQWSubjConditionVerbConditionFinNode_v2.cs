using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionVerbConditionFinNodeAction(ATNConditionQWSubjConditionVerbConditionFinNode_v2 item);

    public class ATNConditionQWSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionVerbConditionFinNodeFactory_v2(ATNConditionQWSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionVerbConditionFinNodeFactory_v2(ATNConditionQWSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbConditionFinNode_v2 sameNode, InitATNConditionQWSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Verb_Condition_Fin;

        public ATNConditionQWSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionVerbConditionFinNodeAction mInitAction;

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


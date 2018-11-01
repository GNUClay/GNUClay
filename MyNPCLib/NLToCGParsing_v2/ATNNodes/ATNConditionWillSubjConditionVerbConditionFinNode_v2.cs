using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjConditionVerbConditionFinNodeAction(ATNConditionWillSubjConditionVerbConditionFinNode_v2 item);

    public class ATNConditionWillSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjConditionVerbConditionFinNodeFactory_v2(ATNConditionWillSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjConditionVerbConditionFinNodeFactory_v2(ATNConditionWillSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbConditionFinNode_v2 sameNode, InitATNConditionWillSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Condition_Verb_Condition_Fin;

        public ATNConditionWillSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjConditionVerbConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjBeConditionV3ConditionFinNodeAction(ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2 item);

    public class ATNQWObjWillSubjBeConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjBeConditionV3ConditionFinNodeFactory_v2(ATNQWObjWillSubjBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjBeConditionV3ConditionFinNodeFactory_v2(ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjBeConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjBeConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2 sameNode, InitATNQWObjWillSubjBeConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Be_Condition_V3_Condition_Fin;

        public ATNQWObjWillSubjBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjBeConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjBeConditionV3ConditionFinNodeAction mInitAction;

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


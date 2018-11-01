using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeAction(ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_Condition_V3_Condition_Fin;

        public ATNConditionQWObjWillSubjBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeConditionV3ConditionFinNodeAction mInitAction;

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


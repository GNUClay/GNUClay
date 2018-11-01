using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeAction(ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_Condition_V3_Condition_Fin;

        public ATNSubjWillNotFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenConditionV3ConditionFinNodeAction mInitAction;

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


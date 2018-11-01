using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveConditionV3NoObjConditionFinNodeAction(ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 item);

    public class ATNSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2(ATNSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2(ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 sameNode, InitATNSubjWillFToHaveConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Condition_V3_No_Obj_Condition_Fin;

        public ATNSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveConditionV3NoObjConditionFinNodeAction mInitAction;

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


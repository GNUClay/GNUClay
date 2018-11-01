using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction(ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Condition_V3_No_Obj_Condition_Fin;

        public ATNQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction mInitAction;

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


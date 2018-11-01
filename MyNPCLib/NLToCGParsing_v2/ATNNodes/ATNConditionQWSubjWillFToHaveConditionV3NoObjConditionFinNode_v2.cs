using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction(ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Condition_V3_No_Obj_Condition_Fin;

        public ATNConditionQWSubjWillFToHaveConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveConditionV3NoObjConditionFinNodeAction mInitAction;

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


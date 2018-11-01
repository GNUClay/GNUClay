using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeAction(ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Condition_V3_Obj_Condition_Fin;

        public ATNQWSubjWillFToHaveConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveConditionV3ObjConditionFinNodeAction mInitAction;

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


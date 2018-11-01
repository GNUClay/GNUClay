using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveConditionV3ObjConditionFinNodeAction(ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Condition_V3_Obj_Condition_Fin;

        public ATNQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveConditionV3ObjConditionFinNodeAction mInitAction;

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


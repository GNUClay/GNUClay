using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveV3ObjConditionFinNodeAction(ATNQWSubjFToHaveV3ObjConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToHaveV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveV3ObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveV3ObjConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_V3_Obj_Condition_Fin;

        public ATNQWSubjFToHaveV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveV3ObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveV3ObjConditionFinNodeAction mInitAction;

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


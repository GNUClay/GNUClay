using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveV3ObjConditionFinNodeAction(ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveV3ObjConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveV3ObjConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_V3_Obj_Condition_Fin;

        public ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveV3ObjConditionFinNodeAction mInitAction;

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


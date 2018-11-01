using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeConditionV3ObjConditionFinNodeAction(ATNWillSubjBeConditionV3ObjConditionFinNode_v2 item);

    public class ATNWillSubjBeConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeConditionV3ObjConditionFinNodeFactory_v2(ATNWillSubjBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeConditionV3ObjConditionFinNodeFactory_v2(ATNWillSubjBeConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjBeConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionV3ObjConditionFinNode_v2 sameNode, InitATNWillSubjBeConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Condition_V3_Obj_Condition_Fin;

        public ATNWillSubjBeConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjBeConditionV3ObjConditionFinNodeAction mInitAction;

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


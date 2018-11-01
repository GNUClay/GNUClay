using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeAction(ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Condition_V3_Obj_Condition_Fin;

        public ATNConditionSubjWillNotBeConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeConditionV3ObjConditionFinNodeAction mInitAction;

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


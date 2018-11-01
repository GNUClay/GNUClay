using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingV3ObjConditionFinNodeAction(ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjBeingV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingV3ObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjBeingV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingV3ObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjBeingV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjBeingV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_V3_Obj_Condition_Fin;

        public ATNConditionFToBeSubjBeingV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingV3ObjConditionFinNodeAction mInitAction;

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


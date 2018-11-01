using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeBeingV3ObjConditionFinNodeAction(ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeBeingV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeBeingV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeBeingV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeBeingV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeBeingV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeBeingV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeBeingV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeBeingV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Being_V3_Obj_Condition_Fin;

        public ATNConditionSubjFToBeBeingV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeBeingV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeBeingV3ObjConditionFinNodeAction mInitAction;

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


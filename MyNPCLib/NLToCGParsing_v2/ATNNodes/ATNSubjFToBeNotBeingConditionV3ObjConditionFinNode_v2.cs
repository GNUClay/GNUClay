using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeAction(ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2 item);

    public class ATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeNotBeingConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotBeingConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2 sameNode, InitATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Being_Condition_V3_Obj_Condition_Fin;

        public ATNSubjFToBeNotBeingConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotBeingConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotBeingConditionV3ObjConditionFinNodeAction mInitAction;

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


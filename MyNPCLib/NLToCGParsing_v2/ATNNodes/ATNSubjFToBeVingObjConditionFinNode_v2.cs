using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeVingObjConditionFinNodeAction(ATNSubjFToBeVingObjConditionFinNode_v2 item);

    public class ATNSubjFToBeVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeVingObjConditionFinNodeFactory_v2(ATNSubjFToBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeVingObjConditionFinNodeFactory_v2(ATNSubjFToBeVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingObjConditionFinNode_v2 sameNode, InitATNSubjFToBeVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Ving_Obj_Condition_Fin;

        public ATNSubjFToBeVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeVingObjConditionFinNodeAction mInitAction;

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


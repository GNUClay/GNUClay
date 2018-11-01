using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeVingObjConditionFinNodeAction(ATNConditionQWSubjFToBeVingObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Ving_Obj_Condition_Fin;

        public ATNConditionQWSubjFToBeVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeVingObjConditionFinNodeAction mInitAction;

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


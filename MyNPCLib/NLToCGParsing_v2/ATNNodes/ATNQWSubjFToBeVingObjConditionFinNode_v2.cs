using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeVingObjConditionFinNodeAction(ATNQWSubjFToBeVingObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeVingObjConditionFinNodeFactory_v2(ATNQWSubjFToBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeVingObjConditionFinNodeFactory_v2(ATNQWSubjFToBeVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeVingObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Ving_Obj_Condition_Fin;

        public ATNQWSubjFToBeVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeVingObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeVingObjConditionFinNodeAction mInitAction;

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


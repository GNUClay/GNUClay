using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionVingNoObjConditionFinNodeAction(ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_Ving_No_Obj_Condition_Fin;

        public ATNQWSubjFToBeConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionVingNoObjConditionFinNodeAction mInitAction;

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


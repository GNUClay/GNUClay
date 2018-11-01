using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeConditionVingNoObjConditionFinNodeAction(ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Condition_Ving_No_Obj_Condition_Fin;

        public ATNConditionSubjFToBeConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeConditionVingNoObjConditionFinNodeAction mInitAction;

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


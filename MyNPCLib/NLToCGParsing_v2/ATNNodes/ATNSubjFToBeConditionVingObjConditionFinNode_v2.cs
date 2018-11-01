using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeConditionVingObjConditionFinNodeAction(ATNSubjFToBeConditionVingObjConditionFinNode_v2 item);

    public class ATNSubjFToBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, InitATNSubjFToBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Condition_Ving_Obj_Condition_Fin;

        public ATNSubjFToBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

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


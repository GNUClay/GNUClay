using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionVingObjConditionFinNodeAction(ATNQWSubjFToBeConditionVingObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_Ving_Obj_Condition_Fin;

        public ATNQWSubjFToBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

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


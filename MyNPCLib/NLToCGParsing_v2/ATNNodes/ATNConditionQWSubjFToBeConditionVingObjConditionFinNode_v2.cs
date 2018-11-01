using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionVingObjConditionFinNodeAction(ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionQWSubjFToBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

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


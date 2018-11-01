using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeConditionVingObjConditionFinNodeAction(ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionSubjFToBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeConditionVingObjConditionFinNodeAction mInitAction;

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


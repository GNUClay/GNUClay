using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionVingObjConditionFinNodeAction(ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionVingObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionVingObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionFToBeSubjConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionVingObjConditionFinNodeAction mInitAction;

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


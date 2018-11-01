using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotVingObjConditionFinNodeAction(ATNSubjFToBeNotVingObjConditionFinNode_v2 item);

    public class ATNSubjFToBeNotVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotVingObjConditionFinNodeFactory_v2(ATNSubjFToBeNotVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotVingObjConditionFinNodeFactory_v2(ATNSubjFToBeNotVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotVingObjConditionFinNode_v2 sameNode, InitATNSubjFToBeNotVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Ving_Obj_Condition_Fin;

        public ATNSubjFToBeNotVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotVingObjConditionFinNodeAction mInitAction;

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


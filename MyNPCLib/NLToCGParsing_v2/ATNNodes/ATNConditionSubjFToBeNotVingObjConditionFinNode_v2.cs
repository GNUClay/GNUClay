using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotVingObjConditionFinNodeAction(ATNConditionSubjFToBeNotVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotVingObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Ving_Obj_Condition_Fin;

        public ATNConditionSubjFToBeNotVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotVingObjConditionFinNodeAction mInitAction;

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


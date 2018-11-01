using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeAction(ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Been_V3_Condition_Fin;

        public ATNConditionQWObjWillSubjFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveBeenV3ConditionFinNodeAction mInitAction;

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


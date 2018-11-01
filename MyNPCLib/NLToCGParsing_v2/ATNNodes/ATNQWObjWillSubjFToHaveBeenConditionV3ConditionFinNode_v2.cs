using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeAction(ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Condition_V3_Condition_Fin;

        public ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenConditionV3ConditionFinNodeAction mInitAction;

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


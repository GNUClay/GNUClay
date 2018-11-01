using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenVingConditionFinNodeAction(ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenVingConditionFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenVingConditionFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Ving_Condition_Fin;

        public ATNQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenVingConditionFinNodeAction mInitAction;

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


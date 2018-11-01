using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeAction(ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Been_Ving_Condition_Fin;

        public ATNConditionQWObjWillSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveBeenVingConditionFinNodeAction mInitAction;

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


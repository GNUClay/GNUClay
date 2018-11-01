using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeAction(ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Condition_Ving_Condition_Fin;

        public ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjConditionVerbConditionFinNodeAction(ATNQWObjWillSubjConditionVerbConditionFinNode_v2 item);

    public class ATNQWObjWillSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjConditionVerbConditionFinNodeFactory_v2(ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjConditionVerbConditionFinNodeFactory_v2(ATNQWObjWillSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjConditionVerbConditionFinNode_v2 sameNode, InitATNQWObjWillSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Condition_Verb_Condition_Fin;

        public ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjConditionVerbConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjVerbConditionFinNodeAction(ATNQWObjWillSubjVerbConditionFinNode_v2 item);

    public class ATNQWObjWillSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjVerbConditionFinNodeFactory_v2(ATNQWObjWillSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjVerbConditionFinNodeFactory_v2(ATNQWObjWillSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjVerbConditionFinNode_v2 sameNode, InitATNQWObjWillSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Verb_Condition_Fin;

        public ATNQWObjWillSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjVerbConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoVerbConditionFinNodeAction(ATNQWSubjFToDoVerbConditionFinNode_v2 item);

    public class ATNQWSubjFToDoVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoVerbConditionFinNodeFactory_v2(ATNQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoVerbConditionFinNodeFactory_v2(ATNQWSubjFToDoVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToDoVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbConditionFinNode_v2 sameNode, InitATNQWSubjFToDoVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Verb_Condition_Fin;

        public ATNQWSubjFToDoVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoVerbConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoVerbConditionFinNodeAction mInitAction;

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


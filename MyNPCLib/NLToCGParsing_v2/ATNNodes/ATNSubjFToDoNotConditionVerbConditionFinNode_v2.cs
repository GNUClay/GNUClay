using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotConditionVerbConditionFinNodeAction(ATNSubjFToDoNotConditionVerbConditionFinNode_v2 item);

    public class ATNSubjFToDoNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotConditionVerbConditionFinNodeFactory_v2(ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotConditionVerbConditionFinNodeFactory_v2(ATNSubjFToDoNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjFToDoNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToDoNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotConditionVerbConditionFinNode_v2 sameNode, InitATNSubjFToDoNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Condition_Verb_Condition_Fin;

        public ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotConditionVerbConditionFinNodeAction mInitAction;

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


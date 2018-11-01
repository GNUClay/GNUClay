using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotConditionVerbConditionFinNodeAction(ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2 item);

    public class ATNConditionSubjFToDoNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2 sameNode, InitATNConditionSubjFToDoNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Condition_Verb_Condition_Fin;

        public ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotConditionVerbConditionFinNodeAction mInitAction;

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


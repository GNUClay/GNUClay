using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotVerbConditionFinNodeAction(ATNSubjFToDoNotVerbConditionFinNode_v2 item);

    public class ATNSubjFToDoNotVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotVerbConditionFinNodeFactory_v2(ATNSubjFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotVerbConditionFinNodeFactory_v2(ATNSubjFToDoNotVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjFToDoNotVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToDoNotVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbConditionFinNode_v2 sameNode, InitATNSubjFToDoNotVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Verb_Condition_Fin;

        public ATNSubjFToDoNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotVerbConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotVerbConditionFinNodeAction(ATNConditionSubjFToDoNotVerbConditionFinNode_v2 item);

    public class ATNConditionSubjFToDoNotVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotVerbConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotVerbConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToDoNotVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotVerbConditionFinNode_v2 sameNode, InitATNConditionSubjFToDoNotVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Verb_Condition_Fin;

        public ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotVerbConditionFinNodeAction mInitAction;

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


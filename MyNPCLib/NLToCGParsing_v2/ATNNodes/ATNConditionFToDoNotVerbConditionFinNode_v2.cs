using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotVerbConditionFinNodeAction(ATNConditionFToDoNotVerbConditionFinNode_v2 item);

    public class ATNConditionFToDoNotVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotVerbConditionFinNodeFactory_v2(ATNConditionFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotVerbConditionFinNodeFactory_v2(ATNConditionFToDoNotVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoNotVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoNotVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToDoNotVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotVerbConditionFinNode_v2 sameNode, InitATNConditionFToDoNotVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Verb_Condition_Fin;

        public ATNConditionFToDoNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionFToDoNotVerbConditionFinNodeAction mInitAction;

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


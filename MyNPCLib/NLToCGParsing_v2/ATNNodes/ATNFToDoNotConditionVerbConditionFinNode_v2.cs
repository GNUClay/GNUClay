using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoNotConditionVerbConditionFinNodeAction(ATNFToDoNotConditionVerbConditionFinNode_v2 item);

    public class ATNFToDoNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoNotConditionVerbConditionFinNodeFactory_v2(ATNFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoNotConditionVerbConditionFinNodeFactory_v2(ATNFToDoNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNFToDoNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbConditionFinNode_v2 sameNode, InitATNFToDoNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Not_Condition_Verb_Condition_Fin;

        public ATNFToDoNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNFToDoNotConditionVerbConditionFinNodeAction mInitAction;

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


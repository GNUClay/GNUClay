using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjConditionVerbConditionFinNodeAction(ATNFToDoSubjConditionVerbConditionFinNode_v2 item);

    public class ATNFToDoSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjConditionVerbConditionFinNodeFactory_v2(ATNFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjConditionVerbConditionFinNodeFactory_v2(ATNFToDoSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbConditionFinNode_v2 sameNode, InitATNFToDoSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Condition_Verb_Condition_Fin;

        public ATNFToDoSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNFToDoSubjConditionVerbConditionFinNodeAction mInitAction;

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


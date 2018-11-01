using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjVerbConditionFinNodeAction(ATNFToDoSubjVerbConditionFinNode_v2 item);

    public class ATNFToDoSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjVerbConditionFinNodeFactory_v2(ATNFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjVerbConditionFinNodeFactory_v2(ATNFToDoSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbConditionFinNode_v2 sameNode, InitATNFToDoSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Verb_Condition_Fin;

        public ATNFToDoSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNFToDoSubjVerbConditionFinNodeAction mInitAction;

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


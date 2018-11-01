using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoVerbConditionFinNodeAction(ATNConditionQWSubjFToDoVerbConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToDoVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoVerbConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoVerbConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToDoVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToDoVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Verb_Condition_Fin;

        public ATNConditionQWSubjFToDoVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoVerbConditionFinNodeAction mInitAction;

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


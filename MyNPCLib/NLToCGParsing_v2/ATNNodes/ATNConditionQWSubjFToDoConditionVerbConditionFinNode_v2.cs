using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoConditionVerbConditionFinNodeAction(ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToDoConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoConditionVerbConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToDoConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Condition_Verb_Condition_Fin;

        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoConditionVerbConditionFinNodeAction mInitAction;

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


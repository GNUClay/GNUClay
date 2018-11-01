using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbConditionVerbConditionFinNodeAction(ATNQWSubjModalVerbConditionVerbConditionFinNode_v2 item);

    public class ATNQWSubjModalVerbConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbConditionVerbConditionFinNodeFactory_v2(ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbConditionVerbConditionFinNodeFactory_v2(ATNQWSubjModalVerbConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjModalVerbConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjModalVerbConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionVerbConditionFinNode_v2 sameNode, InitATNQWSubjModalVerbConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Condition_Verb_Condition_Fin;

        public ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNQWSubjModalVerbConditionVerbConditionFinNodeAction mInitAction;

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


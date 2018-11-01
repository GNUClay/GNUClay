using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbConditionVerbConditionFinNodeAction(ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Condition_Verb_Condition_Fin;

        public ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbConditionVerbConditionFinNodeAction mInitAction;

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


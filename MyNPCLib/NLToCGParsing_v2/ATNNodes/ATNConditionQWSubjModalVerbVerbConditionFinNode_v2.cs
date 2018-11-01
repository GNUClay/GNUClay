using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbVerbConditionFinNodeAction(ATNConditionQWSubjModalVerbVerbConditionFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbVerbConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbVerbConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjModalVerbVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbConditionFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Verb_Condition_Fin;

        public ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbVerbConditionFinNodeAction mInitAction;

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


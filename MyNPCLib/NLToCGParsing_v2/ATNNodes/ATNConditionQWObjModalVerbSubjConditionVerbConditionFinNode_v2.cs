using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeAction(ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2 item);

    public class ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeFactory_v2(ATNConditionQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeFactory_v2(ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2 sameNode, InitATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_ModalVerb_Subj_Condition_Verb_Condition_Fin;

        public ATNConditionQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjModalVerbSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjModalVerbSubjConditionVerbConditionFinNodeAction mInitAction;

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


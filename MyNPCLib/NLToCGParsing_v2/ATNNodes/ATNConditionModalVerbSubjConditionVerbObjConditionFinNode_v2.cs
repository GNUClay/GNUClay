using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjConditionVerbObjConditionFinNodeAction(ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionModalVerbSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionModalVerbSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionModalVerbSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjConditionVerbObjConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbConditionVerbObjConditionFinNodeAction(ATNSubjModalVerbConditionVerbObjConditionFinNode_v2 item);

    public class ATNSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, InitATNSubjModalVerbConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Condition_Verb_Obj_Condition_Fin;

        public ATNSubjModalVerbConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

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


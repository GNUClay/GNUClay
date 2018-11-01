using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotConditionVerbObjConditionFinNodeAction(ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNSubjModalVerbNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotConditionVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotConditionVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNSubjModalVerbNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbNotConditionVerbObjConditionFinNodeAction mInitAction;

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


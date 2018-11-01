using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeAction(ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionSubjModalVerbNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbNotConditionVerbObjConditionFinNodeAction mInitAction;

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


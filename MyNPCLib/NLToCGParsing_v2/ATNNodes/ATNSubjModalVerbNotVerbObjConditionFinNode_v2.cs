using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotVerbObjConditionFinNodeAction(ATNSubjModalVerbNotVerbObjConditionFinNode_v2 item);

    public class ATNSubjModalVerbNotVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbNotVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbNotVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbNotVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotVerbObjConditionFinNode_v2 sameNode, InitATNSubjModalVerbNotVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Verb_Obj_Condition_Fin;

        public ATNSubjModalVerbNotVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbNotVerbObjConditionFinNodeAction mInitAction;

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


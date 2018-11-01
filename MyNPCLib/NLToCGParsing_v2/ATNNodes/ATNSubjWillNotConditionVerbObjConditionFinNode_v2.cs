using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotConditionVerbObjConditionFinNodeAction(ATNSubjWillNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNSubjWillNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotConditionVerbObjConditionFinNodeFactory_v2(ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotConditionVerbObjConditionFinNodeFactory_v2(ATNSubjWillNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNSubjWillNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNSubjWillNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotConditionVerbObjConditionFinNodeAction mInitAction;

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


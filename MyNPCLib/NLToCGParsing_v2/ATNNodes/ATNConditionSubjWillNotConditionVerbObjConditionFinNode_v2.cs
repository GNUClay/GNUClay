using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotConditionVerbObjConditionFinNodeAction(ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionSubjWillNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotConditionVerbObjConditionFinNodeAction mInitAction;

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


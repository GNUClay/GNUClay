using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotVerbObjConditionFinNodeAction(ATNSubjWillNotVerbObjConditionFinNode_v2 item);

    public class ATNSubjWillNotVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotVerbObjConditionFinNodeFactory_v2(ATNSubjWillNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotVerbObjConditionFinNodeFactory_v2(ATNSubjWillNotVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotVerbObjConditionFinNode_v2 sameNode, InitATNSubjWillNotVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Verb_Obj_Condition_Fin;

        public ATNSubjWillNotVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotVerbObjConditionFinNodeAction mInitAction;

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


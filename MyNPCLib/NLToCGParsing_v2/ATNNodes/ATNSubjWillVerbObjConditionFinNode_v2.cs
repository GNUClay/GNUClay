using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillVerbObjConditionFinNodeAction(ATNSubjWillVerbObjConditionFinNode_v2 item);

    public class ATNSubjWillVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillVerbObjConditionFinNodeFactory_v2(ATNSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillVerbObjConditionFinNodeFactory_v2(ATNSubjWillVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbObjConditionFinNode_v2 sameNode, InitATNSubjWillVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Verb_Obj_Condition_Fin;

        public ATNSubjWillVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillVerbObjConditionFinNodeAction mInitAction;

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


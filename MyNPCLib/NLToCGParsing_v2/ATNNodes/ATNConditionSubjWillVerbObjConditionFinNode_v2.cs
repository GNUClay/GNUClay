using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillVerbObjConditionFinNodeAction(ATNConditionSubjWillVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillVerbObjConditionFinNodeFactory_v2(ATNConditionSubjWillVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Verb_Obj_Condition_Fin;

        public ATNConditionSubjWillVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillVerbObjConditionFinNodeAction mInitAction;

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


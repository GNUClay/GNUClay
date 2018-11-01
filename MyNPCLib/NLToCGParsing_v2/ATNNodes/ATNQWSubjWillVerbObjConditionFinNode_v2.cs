using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillVerbObjConditionFinNodeAction(ATNQWSubjWillVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjWillVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillVerbObjConditionFinNodeFactory_v2(ATNQWSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillVerbObjConditionFinNodeFactory_v2(ATNQWSubjWillVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjWillVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Verb_Obj_Condition_Fin;

        public ATNQWSubjWillVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillVerbObjConditionFinNodeAction mInitAction;

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


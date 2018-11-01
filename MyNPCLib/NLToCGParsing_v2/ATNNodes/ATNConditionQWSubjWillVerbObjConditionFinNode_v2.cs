using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillVerbObjConditionFinNodeAction(ATNConditionQWSubjWillVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillVerbObjConditionFinNodeAction mInitAction;

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


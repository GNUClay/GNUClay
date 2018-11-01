using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjConditionVerbObjConditionFinNodeAction(ATNSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjConditionVerbObjConditionFinNodeFactory_v2(ATNSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjConditionVerbObjConditionFinNodeFactory_v2(ATNSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjConditionVerbObjConditionFinNodeAction mInitAction;

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


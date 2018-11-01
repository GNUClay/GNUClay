using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeConditionVingObjConditionFinNodeAction(ATNSubjWillNotBeConditionVingObjConditionFinNode_v2 item);

    public class ATNSubjWillNotBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeConditionVingObjConditionFinNodeFactory_v2(ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeConditionVingObjConditionFinNodeFactory_v2(ATNSubjWillNotBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingObjConditionFinNode_v2 sameNode, InitATNSubjWillNotBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Condition_Ving_Obj_Condition_Fin;

        public ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeConditionVingObjConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionVingNoObjConditionFinNodeAction(ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillBeConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Ving_No_Obj_Condition_Fin;

        public ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionVingNoObjConditionFinNodeAction mInitAction;

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


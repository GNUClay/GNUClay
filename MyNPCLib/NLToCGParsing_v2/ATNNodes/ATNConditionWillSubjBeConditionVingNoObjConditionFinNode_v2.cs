using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionVingNoObjConditionFinNodeAction(ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_Ving_No_Obj_Condition_Fin;

        public ATNConditionWillSubjBeConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionVingNoObjConditionFinNodeAction mInitAction;

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


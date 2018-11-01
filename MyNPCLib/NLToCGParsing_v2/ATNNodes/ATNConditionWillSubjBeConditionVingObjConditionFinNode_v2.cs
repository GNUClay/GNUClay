using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionVingObjConditionFinNodeAction(ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionVingObjConditionFinNodeAction mInitAction;

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


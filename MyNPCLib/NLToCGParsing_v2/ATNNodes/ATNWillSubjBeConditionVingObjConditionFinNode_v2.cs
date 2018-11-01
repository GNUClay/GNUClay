using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeConditionVingObjConditionFinNodeAction(ATNWillSubjBeConditionVingObjConditionFinNode_v2 item);

    public class ATNWillSubjBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeConditionVingObjConditionFinNodeFactory_v2(ATNWillSubjBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeConditionVingObjConditionFinNodeFactory_v2(ATNWillSubjBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingObjConditionFinNode_v2 sameNode, InitATNWillSubjBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Condition_Ving_Obj_Condition_Fin;

        public ATNWillSubjBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjBeConditionVingObjConditionFinNodeAction mInitAction;

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


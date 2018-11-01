using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionVingObjConditionFinNodeAction(ATNQWSubjWillBeConditionVingObjConditionFinNode_v2 item);

    public class ATNQWSubjWillBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionVingObjConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionVingObjConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingObjConditionFinNode_v2 sameNode, InitATNQWSubjWillBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_Ving_Obj_Condition_Fin;

        public ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionVingObjConditionFinNodeAction mInitAction;

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


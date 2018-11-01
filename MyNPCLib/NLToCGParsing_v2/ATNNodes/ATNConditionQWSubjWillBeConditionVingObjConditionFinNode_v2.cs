using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionVingObjConditionFinNodeAction(ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionQWSubjWillBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionVingObjConditionFinNodeAction mInitAction;

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


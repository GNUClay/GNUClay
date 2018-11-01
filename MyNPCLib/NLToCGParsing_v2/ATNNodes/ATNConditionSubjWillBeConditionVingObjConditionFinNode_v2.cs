using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionVingObjConditionFinNodeAction(ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillBeConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillBeConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Ving_Obj_Condition_Fin;

        public ATNConditionSubjWillBeConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionVingObjConditionFinNodeAction mInitAction;

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


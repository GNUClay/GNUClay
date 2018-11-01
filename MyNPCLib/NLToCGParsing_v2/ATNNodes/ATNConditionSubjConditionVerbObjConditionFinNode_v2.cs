using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjConditionVerbObjConditionFinNodeAction(ATNConditionSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjConditionVerbObjConditionFinNodeAction mInitAction;

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


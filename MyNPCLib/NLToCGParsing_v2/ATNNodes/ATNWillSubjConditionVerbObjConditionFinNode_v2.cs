using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjConditionVerbObjConditionFinNodeAction(ATNWillSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNWillSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjConditionVerbObjConditionFinNodeFactory_v2(ATNWillSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjConditionVerbObjConditionFinNodeFactory_v2(ATNWillSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNWillSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNWillSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNWillSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNWillSubjConditionVerbObjConditionFinNodeAction mInitAction;

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


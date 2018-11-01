using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillConditionVerbObjConditionFinNodeAction(ATNSubjWillConditionVerbObjConditionFinNode_v2 item);

    public class ATNSubjWillConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillConditionVerbObjConditionFinNodeFactory_v2(ATNSubjWillConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillConditionVerbObjConditionFinNodeFactory_v2(ATNSubjWillConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillConditionVerbObjConditionFinNode_v2 sameNode, InitATNSubjWillConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Condition_Verb_Obj_Condition_Fin;

        public ATNSubjWillConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillConditionVerbObjConditionFinNodeAction mInitAction;

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


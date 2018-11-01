using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbVerbObjConditionFinNodeAction(ATNSubjModalVerbVerbObjConditionFinNode_v2 item);

    public class ATNSubjModalVerbVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNSubjModalVerbVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbObjConditionFinNode_v2 sameNode, InitATNSubjModalVerbVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Verb_Obj_Condition_Fin;

        public ATNSubjModalVerbVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

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


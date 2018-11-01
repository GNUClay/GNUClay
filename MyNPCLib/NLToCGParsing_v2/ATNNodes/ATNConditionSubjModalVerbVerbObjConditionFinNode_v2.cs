using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbVerbObjConditionFinNodeAction(ATNConditionSubjModalVerbVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Verb_Obj_Condition_Fin;

        public ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

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


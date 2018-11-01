using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbVerbObjConditionFinNodeAction(ATNQWSubjModalVerbVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjModalVerbVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNQWSubjModalVerbVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjModalVerbVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjModalVerbVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Verb_Obj_Condition_Fin;

        public ATNQWSubjModalVerbVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

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


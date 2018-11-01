using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbVerbObjConditionFinNodeAction(ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjModalVerbVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbVerbObjConditionFinNodeAction mInitAction;

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


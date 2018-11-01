using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbConditionVerbObjConditionFinNodeAction(ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjModalVerbConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Condition_Verb_Obj_Condition_Fin;

        public ATNQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeAction(ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjModalVerbConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

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


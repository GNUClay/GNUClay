using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbConditionVerbObjConditionFinNodeAction(ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionSubjModalVerbConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbConditionVerbObjConditionFinNodeAction mInitAction;

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


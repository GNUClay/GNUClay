using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbConditionVerbNoObjTransOrFinNodeAction(ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2(ATNSubjModalVerbConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbConditionVerbNoObjTransOrFinNodeFactory_v2(ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbConditionVerbNoTransNode_v2 mParentNode;
        private ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_ModalVerb_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNSubjModalVerbConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Condition_Verb_No_Obj_TransOrFin;

        public ATNSubjModalVerbConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjModalVerbConditionVerbNoObjTransOrFinNodeAction mInitAction;

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


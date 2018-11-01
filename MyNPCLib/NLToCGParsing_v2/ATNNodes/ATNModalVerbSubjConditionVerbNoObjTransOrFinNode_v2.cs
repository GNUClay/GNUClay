using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjConditionVerbNoObjTransOrFinNodeAction(ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNModalVerbSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNModalVerbSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_Subj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNModalVerbSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Condition_Verb_No_Obj_TransOrFin;

        public ATNModalVerbSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNModalVerbSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeAction(ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 mParentNode;
        private ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Condition_Verb_No_Obj_TransOrFin;

        public ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNodeAction mInitAction;

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


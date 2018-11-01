using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbSubjConditionVerbTransOrFinNodeAction(ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNQWObjModalVerbSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbSubjConditionVerbTransOrFinNodeFactory_v2(ATNQWObjModalVerbSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbSubjConditionVerbTransOrFinNodeFactory_v2(ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjModalVerbSubjConditionTransNode_v2 mParentNode;
        private ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_ModalVerb_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNQWObjModalVerbSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Subj_Condition_Verb_TransOrFin;

        public ATNQWObjModalVerbSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWObjModalVerbSubjConditionVerbTransOrFinNodeAction mInitAction;

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


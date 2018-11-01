using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbSubjConditionTransNodeAction(ATNQWObjModalVerbSubjConditionTransNode_v2 item);

    public class ATNQWObjModalVerbSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbSubjConditionTransNodeFactory_v2(ATNQWObjModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbSubjConditionTransNodeFactory_v2(ATNQWObjModalVerbSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjModalVerbSubjTransNode_v2 mParentNode;
        private ATNQWObjModalVerbSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_ModalVerb_Subj_Condition_Verb_TransOrFin
*/

    public class ATNQWObjModalVerbSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjConditionTransNode_v2 sameNode, InitATNQWObjModalVerbSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Subj_Condition_Trans;

        public ATNQWObjModalVerbSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbSubjConditionTransNode_v2 mSameNode;
        private InitATNQWObjModalVerbSubjConditionTransNodeAction mInitAction;

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


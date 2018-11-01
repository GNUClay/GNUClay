using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjModalVerbSubjTransNodeAction(ATNConditionQWObjModalVerbSubjTransNode_v2 item);

    public class ATNConditionQWObjModalVerbSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjModalVerbSubjTransNodeFactory_v2(ATNConditionQWObjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjModalVerbSubjTransNodeFactory_v2(ATNConditionQWObjModalVerbSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjModalVerbSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjModalVerbTransNode_v2 mParentNode;
        private ATNConditionQWObjModalVerbSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjModalVerbSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjModalVerbSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjModalVerbSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_ModalVerb_Subj_Verb_TransOrFin
    Condition_QWObj_ModalVerb_Subj_Condition_Trans
*/

    public class ATNConditionQWObjModalVerbSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjModalVerbSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjModalVerbSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjModalVerbSubjTransNode_v2 sameNode, InitATNConditionQWObjModalVerbSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_ModalVerb_Subj_Trans;

        public ATNConditionQWObjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjModalVerbSubjTransNode_v2 mSameNode;
        private InitATNConditionQWObjModalVerbSubjTransNodeAction mInitAction;

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


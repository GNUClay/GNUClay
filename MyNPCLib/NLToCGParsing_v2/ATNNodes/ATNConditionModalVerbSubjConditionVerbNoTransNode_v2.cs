using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjConditionVerbNoTransNodeAction(ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 item);

    public class ATNConditionModalVerbSubjConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjConditionVerbNoTransNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjConditionVerbNoTransNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionModalVerbSubjConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 sameNode, InitATNConditionModalVerbSubjConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Condition_Verb_No_Trans;

        public ATNConditionModalVerbSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjConditionVerbNoTransNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjConditionVerbNoTransNodeAction(ATNModalVerbSubjConditionVerbNoTransNode_v2 item);

    public class ATNModalVerbSubjConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjConditionVerbNoTransNodeFactory_v2(ATNModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjConditionVerbNoTransNodeFactory_v2(ATNModalVerbSubjConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_Subj_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNModalVerbSubjConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbNoTransNode_v2 sameNode, InitATNModalVerbSubjConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Condition_Verb_No_Trans;

        public ATNModalVerbSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjConditionVerbNoTransNode_v2 mSameNode;
        private InitATNModalVerbSubjConditionVerbNoTransNodeAction mInitAction;

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


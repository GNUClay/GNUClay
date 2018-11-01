using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjTransNodeAction(ATNConditionSubjTransNode_v2 item);

    public class ATNConditionSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjTransNodeFactory_v2(ATNConditionSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Verb_TransOrFin
    Condition_Subj_FToDo_Trans
    Condition_Subj_Will_Trans
    Condition_Subj_FToBe_Trans
    Condition_Subj_FToHave_Trans
    Condition_Subj_ModalVerb_Trans
    Condition_Subj_Condition_Trans
*/

    public class ATNConditionSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjTransNode_v2 sameNode, InitATNConditionSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjTransNode_v2 mSameNode;
        private InitATNConditionSubjTransNodeAction mInitAction;

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


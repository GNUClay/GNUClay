using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeTransNodeAction(ATNConditionSubjFToBeTransNode_v2 item);

    public class ATNConditionSubjFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeTransNodeFactory_v2(ATNConditionSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeTransNodeFactory_v2(ATNConditionSubjFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Ving_TransOrFin
    Condition_Subj_FToBe_Not_Trans
    Condition_Subj_FToBe_V3_TransOrFin
    Condition_Subj_FToBe_Being_Trans
    Condition_Subj_FToBe_Condition_Trans
*/

    public class ATNConditionSubjFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeTransNode_v2 sameNode, InitATNConditionSubjFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Trans;

        public ATNConditionSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeTransNode_v2 mSameNode;
        private InitATNConditionSubjFToBeTransNodeAction mInitAction;

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


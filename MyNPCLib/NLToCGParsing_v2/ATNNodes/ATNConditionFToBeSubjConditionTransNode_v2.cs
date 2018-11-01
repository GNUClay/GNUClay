using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionTransNodeAction(ATNConditionFToBeSubjConditionTransNode_v2 item);

    public class ATNConditionFToBeSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionTransNodeFactory_v2(ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionTransNodeFactory_v2(ATNConditionFToBeSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Condition_Ving_TransOrFin
    Condition_FToBe_Subj_Condition_V3_TransOrFin
*/

    public class ATNConditionFToBeSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionTransNode_v2 sameNode, InitATNConditionFToBeSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Trans;

        public ATNConditionFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionTransNodeAction mInitAction;

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


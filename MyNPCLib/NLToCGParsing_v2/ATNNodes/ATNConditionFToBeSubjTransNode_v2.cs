using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjTransNodeAction(ATNConditionFToBeSubjTransNode_v2 item);

    public class ATNConditionFToBeSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjTransNodeFactory_v2(ATNConditionFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjTransNodeFactory_v2(ATNConditionFToBeSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Ving_TransOrFin
    Condition_FToBe_Subj_V3_TransOrFin
    Condition_FToBe_Subj_Being_Trans
    Condition_FToBe_Subj_Condition_Trans
*/

    public class ATNConditionFToBeSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjTransNode_v2 sameNode, InitATNConditionFToBeSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Trans;

        public ATNConditionFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjTransNodeAction mInitAction;

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


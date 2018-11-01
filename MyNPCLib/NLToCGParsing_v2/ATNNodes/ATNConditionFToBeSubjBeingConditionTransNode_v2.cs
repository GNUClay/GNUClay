using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingConditionTransNodeAction(ATNConditionFToBeSubjBeingConditionTransNode_v2 item);

    public class ATNConditionFToBeSubjBeingConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingConditionTransNodeFactory_v2(ATNConditionFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingConditionTransNodeFactory_v2(ATNConditionFToBeSubjBeingConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjBeingTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Being_Condition_V3_TransOrFin
*/

    public class ATNConditionFToBeSubjBeingConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingConditionTransNode_v2 sameNode, InitATNConditionFToBeSubjBeingConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_Condition_Trans;

        public ATNConditionFToBeSubjBeingTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingConditionTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingConditionTransNodeAction mInitAction;

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


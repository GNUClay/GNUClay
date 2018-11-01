using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingTransNodeAction(ATNConditionFToBeSubjBeingTransNode_v2 item);

    public class ATNConditionFToBeSubjBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingTransNodeFactory_v2(ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingTransNodeFactory_v2(ATNConditionFToBeSubjBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Being_V3_TransOrFin
    Condition_FToBe_Subj_Being_Condition_Trans
*/

    public class ATNConditionFToBeSubjBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingTransNode_v2 sameNode, InitATNConditionFToBeSubjBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_Trans;

        public ATNConditionFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingTransNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeTransNodeAction(ATNConditionFToBeTransNode_v2 item);

    public class ATNConditionFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeTransNodeFactory_v2(ATNConditionFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Trans
*/

    public class ATNConditionFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeTransNode_v2 sameNode, InitATNConditionFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeTransNode_v2 mSameNode;
        private InitATNConditionFToBeTransNodeAction mInitAction;

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


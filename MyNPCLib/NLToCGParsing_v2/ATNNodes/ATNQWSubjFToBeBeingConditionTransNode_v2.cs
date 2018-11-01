using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeBeingConditionTransNodeAction(ATNQWSubjFToBeBeingConditionTransNode_v2 item);

    public class ATNQWSubjFToBeBeingConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeBeingConditionTransNodeFactory_v2(ATNQWSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeBeingConditionTransNodeFactory_v2(ATNQWSubjFToBeBeingConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeBeingConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeBeingTransNode_v2 mParentNode;
        private ATNQWSubjFToBeBeingConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeBeingConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeBeingConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeBeingConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Being_Condition_V3_TransOrFin
*/

    public class ATNQWSubjFToBeBeingConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingConditionTransNode_v2 sameNode, InitATNQWSubjFToBeBeingConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Being_Condition_Trans;

        public ATNQWSubjFToBeBeingTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeBeingConditionTransNode_v2 mSameNode;
        private InitATNQWSubjFToBeBeingConditionTransNodeAction mInitAction;

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


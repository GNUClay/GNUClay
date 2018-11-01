using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeBeingConditionTransNodeAction(ATNConditionQWSubjFToBeBeingConditionTransNode_v2 item);

    public class ATNConditionQWSubjFToBeBeingConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeBeingConditionTransNodeFactory_v2(ATNConditionQWSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeBeingConditionTransNodeFactory_v2(ATNConditionQWSubjFToBeBeingConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeBeingConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeBeingTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeBeingConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeBeingConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeBeingConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeBeingConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Being_Condition_V3_TransOrFin
*/

    public class ATNConditionQWSubjFToBeBeingConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeBeingConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingConditionTransNode_v2 sameNode, InitATNConditionQWSubjFToBeBeingConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Being_Condition_Trans;

        public ATNConditionQWSubjFToBeBeingTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeBeingConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeBeingConditionTransNodeAction mInitAction;

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


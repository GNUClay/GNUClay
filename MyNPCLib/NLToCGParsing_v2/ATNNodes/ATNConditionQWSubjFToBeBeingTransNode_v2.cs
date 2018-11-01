using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeBeingTransNodeAction(ATNConditionQWSubjFToBeBeingTransNode_v2 item);

    public class ATNConditionQWSubjFToBeBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeBeingTransNodeFactory_v2(ATNConditionQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeBeingTransNodeFactory_v2(ATNConditionQWSubjFToBeBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Being_V3_TransOrFin
    Condition_QWSubj_FToBe_Being_Condition_Trans
*/

    public class ATNConditionQWSubjFToBeBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingTransNode_v2 sameNode, InitATNConditionQWSubjFToBeBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Being_Trans;

        public ATNConditionQWSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeBeingTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeBeingTransNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeTransNodeAction(ATNConditionQWSubjFToBeTransNode_v2 item);

    public class ATNConditionQWSubjFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeTransNodeFactory_v2(ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeTransNodeFactory_v2(ATNConditionQWSubjFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Ving_TransOrFin
    Condition_QWSubj_FToBe_V3_TransOrFin
    Condition_QWSubj_FToBe_Being_Trans
    Condition_QWSubj_FToBe_Condition_Trans
*/

    public class ATNConditionQWSubjFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeTransNode_v2 sameNode, InitATNConditionQWSubjFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Trans;

        public ATNConditionQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeTransNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionTransNodeAction(ATNConditionQWSubjFToBeConditionTransNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionTransNodeFactory_v2(ATNConditionQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionTransNodeFactory_v2(ATNConditionQWSubjFToBeConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Condition_Ving_TransOrFin
    Condition_QWSubj_FToBe_Condition_V3_TransOrFin
*/

    public class ATNConditionQWSubjFToBeConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionTransNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_Trans;

        public ATNConditionQWSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionTransNodeAction mInitAction;

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


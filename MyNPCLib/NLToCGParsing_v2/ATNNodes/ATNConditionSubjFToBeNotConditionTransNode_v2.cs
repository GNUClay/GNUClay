using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotConditionTransNodeAction(ATNConditionSubjFToBeNotConditionTransNode_v2 item);

    public class ATNConditionSubjFToBeNotConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotConditionTransNodeFactory_v2(ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotConditionTransNodeFactory_v2(ATNConditionSubjFToBeNotConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_Condition_Ving_TransOrFin
    Condition_Subj_FToBe_Not_Condition_V3_TransOrFin
*/

    public class ATNConditionSubjFToBeNotConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionTransNode_v2 sameNode, InitATNConditionSubjFToBeNotConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Condition_Trans;

        public ATNConditionSubjFToBeNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotConditionTransNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotConditionTransNodeAction mInitAction;

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


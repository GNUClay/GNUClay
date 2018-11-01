using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeBeingV3NoTransNodeAction(ATNConditionSubjFToBeBeingV3NoTransNode_v2 item);

    public class ATNConditionSubjFToBeBeingV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeBeingV3NoTransNodeFactory_v2(ATNConditionSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeBeingV3NoTransNodeFactory_v2(ATNConditionSubjFToBeBeingV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeBeingV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeBeingV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeBeingV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeBeingV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeBeingV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeBeingV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Being_V3_No_Obj_TransOrFin
*/

    public class ATNConditionSubjFToBeBeingV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingV3NoTransNode_v2 sameNode, InitATNConditionSubjFToBeBeingV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Being_V3_No_Trans;

        public ATNConditionSubjFToBeBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeBeingV3NoTransNode_v2 mSameNode;
        private InitATNConditionSubjFToBeBeingV3NoTransNodeAction mInitAction;

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


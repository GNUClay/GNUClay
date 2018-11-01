using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjV3NoTransNodeAction(ATNConditionFToBeSubjV3NoTransNode_v2 item);

    public class ATNConditionFToBeSubjV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjV3NoTransNodeFactory_v2(ATNConditionFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjV3NoTransNodeFactory_v2(ATNConditionFToBeSubjV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjV3TransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_V3_No_Obj_TransOrFin
*/

    public class ATNConditionFToBeSubjV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjV3NoTransNode_v2 sameNode, InitATNConditionFToBeSubjV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_V3_No_Trans;

        public ATNConditionFToBeSubjV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjV3NoTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjV3NoTransNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjV3TransOrFinNodeAction(ATNConditionFToBeSubjV3TransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjV3TransOrFinNodeFactory_v2(ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjV3TransOrFinNodeFactory_v2(ATNConditionFToBeSubjV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_V3_Obj_TransOrFin
    Condition_FToBe_Subj_V3_No_Trans
    Condition_FToBe_Subj_V3_Condition_Fin
*/

    public class ATNConditionFToBeSubjV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjV3TransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_V3_TransOrFin;

        public ATNConditionFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjV3TransOrFinNodeAction mInitAction;

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


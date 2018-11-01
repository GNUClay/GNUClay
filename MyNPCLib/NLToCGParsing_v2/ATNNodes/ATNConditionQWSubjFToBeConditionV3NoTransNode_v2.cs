using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionV3NoTransNodeAction(ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionV3NoTransNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionV3NoTransNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjFToBeConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_V3_No_Trans;

        public ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionV3NoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionV3NoTransNodeAction mInitAction;

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


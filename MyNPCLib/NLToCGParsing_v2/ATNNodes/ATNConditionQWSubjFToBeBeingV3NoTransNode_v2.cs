using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeBeingV3NoTransNodeAction(ATNConditionQWSubjFToBeBeingV3NoTransNode_v2 item);

    public class ATNConditionQWSubjFToBeBeingV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeBeingV3NoTransNodeFactory_v2(ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeBeingV3NoTransNodeFactory_v2(ATNConditionQWSubjFToBeBeingV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeBeingV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeBeingV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeBeingV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeBeingV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeBeingV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Being_V3_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjFToBeBeingV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeBeingV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingV3NoTransNode_v2 sameNode, InitATNConditionQWSubjFToBeBeingV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Being_V3_No_Trans;

        public ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeBeingV3NoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeBeingV3NoTransNodeAction mInitAction;

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


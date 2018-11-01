using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeBeingV3TransOrFinNodeAction(ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToBeBeingV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeBeingV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeBeingV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeBeingV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeBeingTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeBeingV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Being_V3_Obj_TransOrFin
    Condition_QWSubj_FToBe_Being_V3_No_Trans
    Condition_QWSubj_FToBe_Being_V3_Condition_Fin
*/

    public class ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToBeBeingV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Being_V3_TransOrFin;

        public ATNConditionQWSubjFToBeBeingTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeBeingV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeBeingV3TransOrFinNodeAction mInitAction;

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


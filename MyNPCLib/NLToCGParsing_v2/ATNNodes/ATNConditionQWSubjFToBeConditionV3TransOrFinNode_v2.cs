using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionV3TransOrFinNodeAction(ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToBe_Condition_V3_Obj_TransOrFin
    Condition_QWSubj_FToBe_Condition_V3_No_Trans
    Condition_QWSubj_FToBe_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_V3_TransOrFin;

        public ATNConditionQWSubjFToBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionV3TransOrFinNodeAction mInitAction;

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


using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveConditionV3TransOrFinNodeAction(ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_Condition_V3_Obj_TransOrFin
    Condition_QWSubj_FToHave_Condition_V3_No_Trans
    Condition_QWSubj_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Condition_V3_TransOrFin;

        public ATNConditionQWSubjFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

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


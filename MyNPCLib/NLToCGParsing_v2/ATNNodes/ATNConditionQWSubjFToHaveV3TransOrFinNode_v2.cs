using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveV3TransOrFinNodeAction(ATNConditionQWSubjFToHaveV3TransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveV3TransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_V3_Obj_TransOrFin
    Condition_QWSubj_FToHave_V3_No_Trans
    Condition_QWSubj_FToHave_V3_Condition_Fin
*/

    public class ATNConditionQWSubjFToHaveV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveV3TransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_V3_TransOrFin;

        public ATNConditionQWSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveV3TransOrFinNodeAction mInitAction;

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


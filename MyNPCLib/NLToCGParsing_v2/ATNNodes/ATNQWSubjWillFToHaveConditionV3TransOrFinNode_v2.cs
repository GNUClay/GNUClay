using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveConditionV3TransOrFinNodeAction(ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNQWSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveConditionV3TransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveConditionTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Condition_V3_Obj_TransOrFin
    QWSubj_Will_FToHave_Condition_V3_No_Trans
    QWSubj_Will_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNQWSubjWillFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Condition_V3_TransOrFin;

        public ATNQWSubjWillFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveConditionV3TransOrFinNodeAction mInitAction;

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


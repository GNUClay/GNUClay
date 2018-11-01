using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjConditionV3TransOrFinNodeAction(ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 item);

    public class ATNQWObjFToHaveSubjConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjConditionTransNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Condition_V3_Condition_Fin
*/

    public class ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 sameNode, InitATNQWObjFToHaveSubjConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Condition_V3_TransOrFin;

        public ATNQWObjFToHaveSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjConditionV3TransOrFinNodeAction mInitAction;

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


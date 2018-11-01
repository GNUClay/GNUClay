using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeAction(ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToHave_Subj_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Condition_V3_TransOrFin;

        public ATNConditionQWObjFToHaveSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjConditionV3TransOrFinNodeAction mInitAction;

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


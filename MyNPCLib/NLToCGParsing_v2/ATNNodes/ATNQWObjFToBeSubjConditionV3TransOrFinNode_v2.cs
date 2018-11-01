using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjConditionV3TransOrFinNodeAction(ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 item);

    public class ATNQWObjFToBeSubjConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjConditionTransNode_v2 mParentNode;
        private ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToBe_Subj_Condition_V3_Condition_Fin
*/

    public class ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 sameNode, InitATNQWObjFToBeSubjConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Condition_V3_TransOrFin;

        public ATNQWObjFToBeSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjConditionV3TransOrFinNodeAction mInitAction;

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


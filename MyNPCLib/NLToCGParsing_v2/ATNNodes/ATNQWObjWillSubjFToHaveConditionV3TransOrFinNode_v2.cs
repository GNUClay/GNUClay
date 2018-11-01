using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction(ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveConditionTransNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Condition_V3_TransOrFin;

        public ATNQWObjWillSubjFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

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


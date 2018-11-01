using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction(ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Condition_V3_TransOrFin;

        public ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNodeAction mInitAction;

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


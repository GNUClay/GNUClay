using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction(ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 item);

    public class ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjBeenConditionTransNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Been_Condition_V3_Condition_Fin
*/

    public class ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 sameNode, InitATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Been_Condition_V3_TransOrFin;

        public ATNQWObjFToHaveSubjBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction mInitAction;

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


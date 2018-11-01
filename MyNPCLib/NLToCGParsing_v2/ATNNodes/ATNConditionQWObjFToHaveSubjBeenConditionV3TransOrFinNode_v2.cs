using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction(ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToHave_Subj_Been_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_Condition_V3_TransOrFin;

        public ATNConditionQWObjFToHaveSubjBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNodeAction mInitAction;

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


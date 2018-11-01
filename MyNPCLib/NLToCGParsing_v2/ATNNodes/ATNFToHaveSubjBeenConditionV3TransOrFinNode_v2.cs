using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionV3TransOrFinNodeAction(ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2 item);

    public class ATNFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2(ATNFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionV3TransOrFinNodeFactory_v2(ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionTransNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_Condition_V3_Obj_TransOrFin
    FToHave_Subj_Been_Condition_V3_No_Trans
    FToHave_Subj_Been_Condition_V3_Condition_Fin
*/

    public class ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2 sameNode, InitATNFToHaveSubjBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_V3_TransOrFin;

        public ATNFToHaveSubjBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionV3TransOrFinNodeAction mInitAction;

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


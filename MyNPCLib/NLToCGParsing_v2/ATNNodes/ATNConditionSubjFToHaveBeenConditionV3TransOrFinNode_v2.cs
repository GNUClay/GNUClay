using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeAction(ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_Condition_V3_Obj_TransOrFin
    Condition_Subj_FToHave_Been_Condition_V3_No_Trans
    Condition_Subj_FToHave_Been_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Condition_V3_TransOrFin;

        public ATNConditionSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

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


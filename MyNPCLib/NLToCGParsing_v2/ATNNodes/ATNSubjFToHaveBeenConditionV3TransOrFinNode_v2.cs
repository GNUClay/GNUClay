using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenConditionV3TransOrFinNodeAction(ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2 item);

    public class ATNSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Been_Condition_V3_Obj_TransOrFin
    Subj_FToHave_Been_Condition_V3_No_Trans
    Subj_FToHave_Been_Condition_V3_Condition_Fin
*/

    public class ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, InitATNSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Condition_V3_TransOrFin;

        public ATNSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

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

